using BankLiteBack.Models;

namespace BankLiteBack.Interfaces
{
    public interface IAccountsServices
    {
        //取得帳戶資訊
        public AccountPageData AccountInfo();

        //新增帳戶
        public void AddAccount(AddAccountForm account);

        //刪除帳號
        public void DeleteAccount(int id);
    }
}
