using BankLiteBack.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankLiteBack.Models
{
    public class TransactionForm
    {
        public int AccountId { get; set; }//帳戶Id
        
        public string Event { get; set; }//事件
        
        public TransactionEnum Method { get; set; } //交易方式
        
        [MaxLength(100)]
        public string Note { get; set; }//備註

        [Range(0, int.MaxValue)]
        public int Money {  get; set; }//金額

        [DefaultValue(0)]
        public int? FileId { get; set; }//附件Id，可為null
        
        public int UserId { get; set; }//使用者Id
    }

    public class TransferForm
    {
        public int OriginId { get; set; }
        public int TargetId { get; set; }
        public int money { get; set; }
        public int UserId { get; set; }
    }
}
