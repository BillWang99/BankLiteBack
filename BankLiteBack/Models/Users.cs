using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankLiteBack.Models
{
    public class Users
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //關聯
        public ICollection<Transactions> Transactions { get; set; }
    }
}
