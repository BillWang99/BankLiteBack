using BankLiteBack.Enum;
using Microsoft.AspNetCore.Hosting.Server;
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

    //查詢交易紀錄
    public class TransferHistoryForm
    {
        [DefaultValue("")]
        public string? startDate { get; set; }
        [DefaultValue("")]
        public string? endDate { get; set; }
        [DefaultValue(0)]
        public int accountId {  get; set; }
        [DefaultValue(0)]
        public int methodId {  get; set; }
    }


    //回傳的交易紀錄
    public class TransactionHistory
    {
        public int Id { get; set; }
        public int accountId { get; set; }
        public string accountName { get; set; }
        public string Event {  get; set; }
        public string note { get; set; }
        public int method {  get; set; }
        public string methodName {  get; set; }
        public int money { get; set; }
        [DefaultValue(0)]
        public int? GroupId {  get; set; }
        public DateOnly CreateTime { get; set; }
        //public List<string> filePath { get; set; }
    }

    //回傳的交易事件明細
    public class TransactionHistoryInfo
    {
        public int Id { get; set; }
        public string accountName { get; set; }
        public string Event { get; set; }
        public string methodName { get; set; }
        public int money { get; set; }
        public string note { get; set; }
        public DateOnly CreateTime { get; set; }
        public int? GroupId { get; set; }
        public List<string>? filesPath { get; set; }
    }
}
