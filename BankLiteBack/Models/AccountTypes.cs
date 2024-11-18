using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankLiteBack.Models
{
    public class AccountTypes
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name {  get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]
        public DateTime UpdateTime { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsDelete {  get; set; }

    }
}
