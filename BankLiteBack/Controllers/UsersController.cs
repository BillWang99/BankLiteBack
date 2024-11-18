using BankLiteBack.Interfaces;
using BankLiteBack.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankLiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //注入Services
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: api/<UsersController>
        //取得帳號清單
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _usersService.GetAccounts();
        }

        // GET api/<UsersController>/5
        //取得對應的帳號
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return _usersService.GetAccount(id);
        }

        // POST api/<UsersController>
        //新增帳號
        [HttpPost]
        public IActionResult Post([FromBody] UserForm data)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            _usersService.CreateAccount(data);

            return Ok();
        }

        // PUT api/<UsersController>/5
        //修改帳號資訊
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserEditForm data)
        {
            _usersService.UpdateAccount(data, id);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usersService.DeleteAccount(id);
        }
    }
}
