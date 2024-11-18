using BankLiteBack.Data;
using BankLiteBack.Interfaces;
using BankLiteBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankLiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _filesService;
        private readonly DefaultContext _context;
        private readonly IWebHostEnvironment _env;

        public FilesController(IFilesService filesService, DefaultContext context, IWebHostEnvironment env)
        {
            _filesService = filesService;
            _context = context;
            _env = env;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
           if(files.Count == 0)
            {
                return Ok(0);
            }

            //檢查目錄是否存在
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            //建立GroupId
            int GroupId = _filesService.GetGroupId() + 1;

            //建立List物件
            List<Files> data = new List<Files>();

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    //重新命名檔案
                    string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                    //設定上傳目錄
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    //上傳檔案
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    //存入DB
                    Files fileObj = new Files
                    {
                        GroupId = GroupId,
                        UniqueName = uniqueFileName,
                        OriginName = file.FileName,
                        FilePath = filePath,
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        IsDeleted = false,
                    };
                    data.Add(fileObj);

                }
            }

            _context.Files.AddRange(data);

            await _context.SaveChangesAsync();

            return Ok(GroupId);

            //return Ok(_filesService.UploadFile(files));
        }


    }
}
