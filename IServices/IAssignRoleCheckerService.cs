using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.IServices
{
    public interface IAssignRoleCheckerService
    {
        IEnumerable<TransactionAccessCheck> GetAssignRoleList();
        IEnumerable<AssignRoleListHistory> GetAssignRoleHistory(int roleId);
        string Approve(AssignRoleModel assignRoleModel);
        string Reject(AssignRoleModel assignRoleModel);

    }
}
