using BankLiteBack.Data;
using BankLiteBack.Interfaces;
using BankLiteBack.Models;
using System.IO;
using System.Threading.Tasks;

namespace BankLiteBack.Services
{
    public class FilesService:IFilesService
    {
        //資料庫連線
        private readonly DefaultContext _context;
        private readonly IWebHostEnvironment _env;
        public FilesService(DefaultContext context)
        {
            _context = context;
        }

        //取得目前的群組ID
        public int GetGroupId()
        {
            int maxId = _context.Files.Any() ? _context.Files.Max(f => f.GroupId):0;
            return maxId;
        }
    }
}
