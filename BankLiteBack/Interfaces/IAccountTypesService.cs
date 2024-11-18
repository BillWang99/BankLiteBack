using BankLiteBack.Models;

namespace BankLiteBack.Interfaces
{
    public interface IAccountTypesService
    {
        //查詢類別
        public List<AccountTypes> GetAccountTypes();

        //查詢選擇的項目
        public AccountTypes GetAccountType(int id);

        //新增類別
        public void AddTypes(string typeName);

        //修改類別名稱
        public void EditTypes(int Id, string typeName);

        //刪除類別
        //刪除前要先檢查是否已被使用
        public string DeleteTypes(int Id);

    }
}
