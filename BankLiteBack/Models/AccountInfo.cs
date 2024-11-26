using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BankLiteBack.Models
{

    //帳戶首頁資訊
    public class AccountPageData
    {
        public int TotalMoney {  get; set; }
        public List<AccountInfo> AccountInfos { get; set; }
    }

    //顯示於首頁的帳戶資訊
    public class AccountInfo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public string TypeName {  get; set; }
        [Required]
        [DefaultValue(0)]
        public int Money { get; set; }
    }

    //新增帳戶資料
    public class AddAccountForm
    {
        [Required(ErrorMessage = "必須填寫帳戶名稱")]
        public string Name { get; set; }
        [Required(ErrorMessage = "請選擇帳戶類型")]
        public int Type { get; set; }
        [Required]
        [DefaultValue(0)]
        [Range(1, int.MaxValue, ErrorMessage = "金額必須是正整數")]
        public int Money { get; set; }
    }
}
