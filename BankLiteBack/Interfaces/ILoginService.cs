using BankLiteBack.Models;

namespace BankLiteBack.Interfaces
{
    public interface ILoginService
    {
        //登入
        public LoginSuccess LoginSuccess(LoginForm loginForm);
    }
}
