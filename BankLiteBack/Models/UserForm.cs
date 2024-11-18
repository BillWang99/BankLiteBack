using System.ComponentModel.DataAnnotations;

namespace BankLiteBack.Models
{
    //註冊表單
    public class UserForm
    {
        [Required(ErrorMessage ="姓名不得為空")]
        public string Name { get; set; }
        [Required(ErrorMessage = "帳號不得為空")]
        public string Account {  get; set; }
        [Required(ErrorMessage = "密碼不得為空")]
        public string Password {  get; set; }
    }

    //登入表單
    public class LoginForm
    {
        [Required(ErrorMessage = "帳號不得為空")]
        [Display(Name = "帳號")]
        public string Account { set; get; }
        [Required(ErrorMessage ="密碼不得為空")]
        [Display(Name = "密碼")]
        public string Password { set; get; }
    }

    //登入成功回傳資料
    public class LoginSuccess
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public Guid Token { set; get; }
    }

    //修改表單
    public class UserEditForm 
    {
        [Required(ErrorMessage ="姓名不得為空")]
        public string Name { get; set; }
        [Required(ErrorMessage ="密碼不得為空")]
        public string Password { set; get; }
    }

}
