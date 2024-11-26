using BankLiteBack.Models;

namespace BankLiteBack.Interfaces
{
    public interface ITransactionsService
    {
        //新增交易紀錄
        public void AddTranscation(TransactionForm data);

        //轉帳
        public int TransferMoney(TransferForm data);

        //查詢交易紀錄
        public List<TransactionHistory> TransferHistory(TransferHistoryForm data);

        //取得交易事件明細(包含圖檔)
        public TransactionHistoryInfo TransactionHistoryInfo(int id);
    }
}
