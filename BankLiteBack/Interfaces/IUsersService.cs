using BankLiteBack.Models;

namespace BankLiteBack.Interfaces
{
    public interface IUsersService
    {
        //查詢所有帳號
        public List<Users> GetAccounts();

        //查詢選擇的帳號
        public Users GetAccount(int id);

        //建立帳號
        public void CreateAccount(UserForm data);

        //修改帳號
        public void UpdateAccount(UserEditForm data, int Id);

        //刪除帳號
        public void DeleteAccount(int Id);
    }
}
