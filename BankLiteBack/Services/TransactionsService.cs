using BankLiteBack.Data;
using BankLiteBack.Enum;
using BankLiteBack.Interfaces;
using BankLiteBack.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankLiteBack.Services
{
    public class TransactionsService:ITransactionsService
    {
        private readonly DefaultContext _context;

        public TransactionsService(DefaultContext context)
        {
            _context = context;
        }

        //新增交易事件
        public void AddTranscation(TransactionForm data)
        {
            Transactions result = new Transactions
            {
                AccountId = data.AccountId,
                Event = data.Event,
                Method = data.Method,
                Money = data.Money,
                Note = data.Note,
                FileId = data.FileId,
                UserId = data.UserId,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };

            //異動金額
            EditAccountMoney(data.AccountId, data.Method, data.Money);

            //儲存異動
            _context.Transactions.Add(result);

            _context.SaveChanges();
        }

        //異動金額
        public void EditAccountMoney (int  accountId, TransactionEnum method, int money)
        {
            //取出Account
            Accounts account = _context.Accounts
                .Where(a => a.Id == accountId && a.IsDelete == false)
                .First();

            //異動金額
            if(method == TransactionEnum.income)
            {
                account.Money += money; 
            }else if(method == TransactionEnum.spend)
            {
                account.Money -= money;
            }

            //儲存異動
            _context.Accounts.Update(account);

            _context.SaveChanges();
        }

        //轉帳
        public int TransferMoney(TransferForm data)
        {
            //建立交易事件紀錄
            List<Transactions> result  = new List<Transactions>();

            //取出轉出帳號
            Accounts OriginAccount = _context.Accounts
                .Where(o => o.Id == data.OriginId && o.IsDelete == false)
                .First();

            //取出轉入帳號
            Accounts TargetAccount = _context.Accounts
                .Where(t => t.Id ==  data.TargetId && t.IsDelete == false)
                .First();

            //比較轉出金額
            if(OriginAccount.Money < data.money)
            {
                return (int)TransferStatus.fail;
            }
            else if (data.money == 0)
            {
                return (int)TransferStatus.fail;
            }
            else
            {
                OriginAccount.Money -= data.money;
                TargetAccount.Money += data.money;
            }

            //製作交易紀錄
            Transactions OriginAccountTransfer = new Transactions
            {
                AccountId = data.OriginId,
                Event = "自帳戶:" + OriginAccount.Name + "轉出" + data.money + "元至帳戶:" + TargetAccount.Name,
                Method = TransactionEnum.transfer,
                Money = data.money,
                Note = "自帳戶:" + OriginAccount.Name + "轉出" + data.money + "元至帳戶:" + TargetAccount.Name,
                FileId = 0,
                UserId = data.UserId,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };

            Transactions TargetAccountTransfer = new Transactions
            {
                AccountId = data.TargetId,
                Event = "來自帳戶:"+OriginAccount.Name+"的"+data.money +"轉帳",
                Method = TransactionEnum.transfer,
                Money = data.money,
                Note = "來自帳戶:" + OriginAccount.Name + "的" + data.money + "元轉帳",
                FileId = 0,
                UserId = data.UserId,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };

            //儲存交易紀錄與修改帳戶金額
            result.Add( OriginAccountTransfer );
            result.Add( TargetAccountTransfer );
            
            _context.Transactions.AddRange(result);
            _context.Accounts.Update(OriginAccount);
            _context.Accounts.Update(TargetAccount);

            _context.SaveChanges();

            return (int)TransferStatus.success;
        }
    }
}
