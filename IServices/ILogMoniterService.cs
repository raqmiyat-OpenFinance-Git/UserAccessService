using Entities.LogMoniter;
using OpenFinanceWebApi.Models;

namespace OpenFinanceWebApi.IServices
{
    public interface ILogMoniterService
    {
        Task SaveLoginLogout(LogMoniterModel loginLogout);
        Task<int> VerifyTransaction(TransactionApprovalRestriction approvalRestriction);
    }
}
