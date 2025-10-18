using Raqmiyat.Entities.Login;
using UserAccessService.Models;
using User = UserAccessService.Models.User;

namespace OpenFinanceWebApi.IServices
{
    public interface IUserCreationService
    {

        IEnumerable<RoleList> GetRoleLists();
        IEnumerable<ProductLists> GetProductLists();
        IEnumerable<RoleList> GetRoleByUserCode(int Id);
        string AddUser(UserMaker postData);
        string UpdateUser(UserMaker postData);
        string DeleteUser(UserMaker postData);
        User GetUserProfile(string userCode);
        string UpdateUserProfile(User user);
        string RemoveProfileImage(string userCode);
        IEnumerable<UserMaker> GetUserLists();
        IEnumerable<UserMaker> SearchUserLists(string UserName);
        UserMaker GetIndividualUserList(int Id);
        //Checker
        UserMaker GetIndividualCheck(int Id);

        IEnumerable<UserMaker> GetCheckerLists();

        string Approve(UserMaker postData);

        IEnumerable<UserMaker> SearchCheckUserLists(string UserName);
    }
}
