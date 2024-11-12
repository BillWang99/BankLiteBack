using BankLiteBack.Models;
using BankLiteBack.Data;
using System.Text;
using System.Security.Cryptography;
using BankLiteBack.Interfaces;

namespace BankLiteBack.Services
{
    public class UsersService:IUsersService
    {
        //資料庫連線
        private readonly DefaultContext _context;

        public UsersService(DefaultContext context)
        {
            _context = context;
        }

        //查詢所有帳號
        public List<Users> GetAccounts()
        {
            List<Users> accounts = _context.Users
                .Where(a => a.IsDelete == false)
                .ToList();

            return accounts;
        }

        //查詢選擇的帳號
        public Users GetAccount(int id)
        {
            return _context.Users
                .Where(a => a.Id == id && a.IsDelete == false)
                .FirstOrDefault();
        }

        //建立帳號
        public void CreateAccount(UserForm data)
        {  
            Users NewUser = new Users
            {
                Name = data.Name,
                Account = data.Account,
                Password = HashPassword(data.Password),
                Token = Guid.NewGuid(),
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };

            _context.Users.Add(NewUser);

            _context.SaveChanges();
        }

        //修改帳號
        public void UpdateAccount(UserForm data, int Id) 
        {
            Users user = _context.Users
                .Where(u => u.Id == Id && u.IsDelete == false)
                .FirstOrDefault();

            if(user != null)
            {
                user.Name = data.Name;

                user.Password = HashPassword(data.Password);

                user.UpdateTime = DateTime.Now;

                _context.Update(user);

                _context.SaveChanges();
            }
        }

        //刪除帳號
        public void DeleteAccount(int Id) 
        {
            Users user = _context.Users
                .Where(u => u.Id == Id)
                .FirstOrDefault();

            if (user != null) 
            {
                user.IsDelete = true;
            }

            _context.Update(user);

            _context.SaveChanges();
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
