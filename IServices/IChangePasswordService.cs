using Raqmiyat.Entities.User;


namespace OpenFinanceWebApi.IServices
{
    public interface IChangePasswordService
    {        
        bool UpdatePassword(ChangePassword changePassword);
        string UpdatePasswordHistory(ChangePassword changePassword);
    }
}
