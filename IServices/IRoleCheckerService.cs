using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.IServices
{
    public interface IRoleCheckerService 
    {
        int ApproveOrReject(Role role);
        public IEnumerable<Role> GetRole();
        IEnumerable<Role> GetSearchCheckRoleDetails(Role role);
    }
}
