using BankLiteBack.Interfaces;
using BankLiteBack.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankLiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsServices _accountsServices;

        public AccountsController(IAccountsServices accountsServices)
        {
            _accountsServices = accountsServices;
        }
        // GET: api/<AccountController>
        //取得帳戶資訊
        [HttpGet]
        public ActionResult<AccountPageData> Get()
        {
            return Ok(_accountsServices.AccountInfo());
        }

        // GET api/<AccountController>/5
        //檢視單一帳戶
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        //新增帳戶
        [HttpPost]
        public IActionResult Post([FromBody] AddAccountForm data)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            _accountsServices.AddAccount(data);

            return Ok();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        //刪除帳戶
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _accountsServices.DeleteAccount(id);

            return Ok();
        }
    }
}
