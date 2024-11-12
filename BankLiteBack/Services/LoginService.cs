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
            loginForm.Password = HashPassword(loginForm.Password);

            LoginSuccess result = _context.Users
                .Where(r => r.Account == loginForm.Account 
                && r.Password == loginForm.Password
                && r.IsDelete == false)
                .Select(r => new LoginSuccess
                {
                    Name = r.Name,
                    Token = r.Token,
                })
                .FirstOrDefault();

            return result;

        }

        //密碼加密
        private string HashPassword(string Password)
        {
            //雜湊演算法
            var sha256 = SHA256.Create();

            //讀取密碼前3個字元
            var salt = Password.Substring(0, 3);

            //原始密碼加工
            var passwordSalt = Password + salt;

            //使用UTF8編碼
            var byteValue = Encoding.UTF8.GetBytes(passwordSalt);

            //進行加密
            var byteHash = sha256.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}
