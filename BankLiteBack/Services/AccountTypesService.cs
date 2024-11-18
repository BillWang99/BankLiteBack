using BankLiteBack.Data;
using BankLiteBack.Interfaces;
using BankLiteBack.Models;

namespace BankLiteBack.Services
{
    public class AccountTypesService:IAccountTypesService
    {
        //資料庫連線
        private readonly DefaultContext _context;

        public AccountTypesService(DefaultContext context)
        {
            _context = context;
        }

        //查詢類別
        public List<AccountTypes> GetAccountTypes()
        {
            List<AccountTypes> data = _context.AccountTypes
                .Where(a => a.IsDelete == false)
                .ToList();

            return data;
        }

        //查詢選擇的項目
        public AccountTypes GetAccountType(int id)
        {
            AccountTypes data = _context.AccountTypes
                .Where(a => a.Id == id)
                .First()!;

            return data;
        }

        //新增類別
        public void AddTypes(string typeName)
        {
            AccountTypes data = new AccountTypes
            {
                Name = typeName,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };

            _context.AccountTypes.Add(data);

            _context.SaveChanges();
        }

        //修改類別名稱
        public void EditTypes(int Id, string typeName)
        {
            AccountTypes data = _context.AccountTypes
                .Where(a => a.Id == Id)
                .FirstOrDefault()!;

            data.Name = typeName;

            _context.Update(data);

            _context.SaveChanges();
        }

        //刪除類別
        //刪除前要先檢查是否已被使用
        public string DeleteTypes(int Id)
        {
            bool HasUsed = _context.Accounts
                .Any(a => a.AccountTypesId == Id);

            if (HasUsed == true) 
            {
                return "此類別已被使用，不可刪除";
            }
            else
            {
                AccountTypes data = _context.AccountTypes
                    .Where(a => a.Id == Id)
                    .FirstOrDefault()!;

                data.IsDelete = true;

                _context.Update(data);

                _context.SaveChanges();

                return "已刪除類別";
            }
        }
    }
}
