using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankLiteBack.Models
{
    public class Files
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GroupId {  get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string OriginName {  get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //關聯
        public Transactions Transactions { get; set; }//交易紀錄
    }
}
