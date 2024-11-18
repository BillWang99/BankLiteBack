using BankLiteBack.Data;
using BankLiteBack.Interfaces;
using BankLiteBack.Models;

namespace BankLiteBack.Services
{
    public class AccountsService:IAccountsServices
    {
        //資料庫連線
        private readonly DefaultContext _context;

        public AccountsService(DefaultContext context)
        {
            _context = context;
        }

        //取得帳戶資訊
        public AccountPageData AccountInfo()
        {
            int totalMoney = _context.Accounts
                .Where(a => a.IsDelete == false)
                .Sum(a => a.Money);

            //List<AccountInfo> accountInfos = _context.Accounts
            //    .Select(a => new AccountInfo
            //    {
            //        Name = a.Name,
            //        Type = a.Type,
            //        Money = a.Money,
            //    }).ToList();

            var query = from Accounts in _context.Accounts
                                         join AccountTypes in _context.AccountTypes on Accounts.AccountTypesId equals AccountTypes.Id
                                         select new AccountInfo
                                         {
                                             Name = Accounts.Name,
                                             Type = Accounts.AccountTypesId,
                                             TypeName = AccountTypes.Name,
                                             Money = Accounts.Money,
                                         };
            List<AccountInfo> accounts = query.ToList();

            AccountPageData data = new AccountPageData
            {
                TotalMoney = totalMoney,
                AccountInfos = accounts
            };

            return data;
        }

        //新增帳戶
        public void AddAccount(AddAccountForm account) 
        {
            Accounts data = new Accounts
            {
                Name = account.Name,
                AccountTypesId = account.Type,
                Money = account.Money,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };

            _context.Accounts.Add(data);

            _context.SaveChanges();
        }

        //刪除帳號
        public void DeleteAccount(int id)
        {
            Accounts account = _context.Accounts
                .Where (a => a.Id == id)
                .FirstOrDefault()!;

            account.IsDelete = true;

            _context.Update(account);

            _context.SaveChanges();
        }
    }
}
