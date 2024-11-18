using BankLiteBack.Models;

namespace BankLiteBack.Interfaces
{
    public interface ITransactionsService
    {
        //新增交易紀錄
        public void AddTranscation(TransactionForm data);

        //轉帳
        public int TransferMoney(TransferForm data);
    }
}
