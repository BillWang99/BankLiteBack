using BankLiteBack.Interfaces;
using BankLiteBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BankLiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypesController : ControllerBase
    {
        private readonly IAccountTypesService _accountTypesService;

        public AccountTypesController(IAccountTypesService accountTypesService)
        {
            _accountTypesService = accountTypesService;
        }

        //取得類別
        [HttpGet]
        public List<AccountTypes> Get()
        {
            return _accountTypesService.GetAccountTypes();
        }

        //取得選擇的類別
        [HttpGet("{id}")]
        public AccountTypes Get(int id) 
        {
            return _accountTypesService.GetAccountType(id);
        }

        //新增類別
        [HttpPost]
        public IActionResult Post([FromBody] string typeName) 
        {
            if (typeName.IsNullOrEmpty())
            {
                return BadRequest("類別名稱不可為空");
            }

            _accountTypesService.AddTypes(typeName);

            return Ok();
        }

        //編輯
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string typeName)
        {
            if (typeName.IsNullOrEmpty())
            {
                return BadRequest("類別名稱不可為空");
            }

            _accountTypesService.EditTypes(id,typeName);

            return Ok();
        }

        //刪除類別
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            string result = _accountTypesService.DeleteTypes(id);

            return Ok(result);
        }
    }
}
