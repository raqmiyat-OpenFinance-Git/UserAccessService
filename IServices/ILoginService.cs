using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.IServices
{
    public interface ILoginService
    {
        Login GetLogin(string userCode);
        IEnumerable<Logontime> lastlogontime(string usercode);
        int SaveSession(UserSession userSession);
        int DeleteSession(UserSession userSession);
        int GetSession(UserSession userSession);
        LoginValidation GetInitialPwd(string userCode);
        string InactivateUser(string userCode);
        int ResetPasswordCount(string userCode);
        string UpdatePasswordFailedCount(string userCode);
        //added by kiruthiga start
        int GetUserSession(string sessionID, string UserName);
        int GetUserStatus(string UserName);
        //added by kiruthiga end
        string GetSourceVersion();
    }
}
