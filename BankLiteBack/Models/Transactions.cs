using BankLiteBack.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankLiteBack.Models
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }//帳戶Id

        [Required]
        public string Event { get; set; }//事件

        [Required]
        public TransactionEnum Method { get; set; } //交易方式

        [Required]
        [MaxLength(100)]
        public string Note { get; set; }//備註

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int Money {  get; set; }//交易金額

        [DefaultValue(0)]
        public int? FileId {  get; set; }//附件Id，可為null

        [Required]
        public int UserId {  get; set; }//使用者Id

        [Required]
        public DateTime CreateTime { get; set; }    

        [Required]
        public DateTime UpdateTime { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDelete { get; set; } 


        //關聯
        public Accounts Account { get; set; }//帳戶
        public Users user { get; set; }//使用者
        public ICollection<Files> files { get; set; }//附件


    }
}
