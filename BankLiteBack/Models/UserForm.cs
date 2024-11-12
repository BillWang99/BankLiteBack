namespace BankLiteBack.Models
{
    //註冊表單
    public class UserForm
    {
        public string Name { get; set; }
        public string Account {  get; set; }
        public string Password {  get; set; }
    }

    //登入表單
    public class LoginForm
    {
        public string Account { set; get; }
        public string Password { set; get; }
    }

    //登入成功回傳資料
    public class LoginSuccess
    {
        public string Name { set; get; }
        public Guid Token { set; get; }
    }
}
