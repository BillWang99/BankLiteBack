using BankLiteBack.Interfaces;
using BankLiteBack.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankLiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }




        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginForm data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //搜尋帳號
            LoginSuccess result = _loginService.LoginSuccess(data);

            if(result == null)
            {
                //帳號為空，回傳錯誤訊息
                return BadRequest("查無帳號");
            }

            return Ok(result);
        }

 


    }
}
