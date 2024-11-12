using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankLiteBack.Models
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Money {  get; set; }

        [Required]
        public DateTime CreateTime {  get; set; }  

        [Required]
        public DateTime UpdateTime { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDelete { get; set; } 
        

        //關聯
        public ICollection<Transactions> Transactions { get; set; }//交易紀錄
    }
}
