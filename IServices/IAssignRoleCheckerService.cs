using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.IServices
{
    public interface IAssignRoleCheckerService
    {
        Task<IEnumerable<TransactionAccessCheck>> GetAssignRoleListAsync();
        Task<IEnumerable<AssignRoleListHistory>> GetAssignRoleHistoryAsync(int roleId);
        Task<string> Approve(AssignRoleModel assignRoleModel);
        Task<string> Reject(AssignRoleModel assignRoleModel);

    }
}
