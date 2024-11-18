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
        public string UniqueName { get; set; }

        [Required]
        public string OriginName {  get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
