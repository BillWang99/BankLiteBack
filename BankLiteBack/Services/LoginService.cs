using BankLiteBack.Data;
using BankLiteBack.Interfaces;
using BankLiteBack.Models;
using System.Security.Cryptography;
using System.Text;

namespace BankLiteBack.Services
{
    public class LoginService:ILoginService
    {
        //資料庫連線
        private readonly DefaultContext _context;

        public LoginService(DefaultContext context) 
        {
            _context = context;
        }

        //登入
        public LoginSuccess LoginSuccess(LoginForm loginForm)
        {
            loginForm.Password = UsersService.HashPassword(loginForm.Password);

            LoginSuccess result = _context.Users
                .Where(r => r.Account == loginForm.Account 
                && r.Password == loginForm.Password
                && r.IsDelete == false)
                .Select(r => new LoginSuccess
                {
                    Id = r.Id,
                    Name = r.Name,
                    Token = r.Token,
                })
                .FirstOrDefault();

            return result;

        }

       
    }
}
