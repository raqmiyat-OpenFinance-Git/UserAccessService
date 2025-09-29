using NPSS_Connect.Models;

namespace OpenFinanceWebApi.IServices
{
    public interface IDashboardService
    {
        Task<IEnumerable<DashBoard>> GetDemoDashboardAsync(string paymentModule, string paymentType, string processType);

        Task<IEnumerable<DashBoardAlert>> GetDemoDashboardAlertAsync(string loginName);

        Task<IEnumerable<DashBoardMasterAlert>> GetDemoDashboardMasterAlertAsync(string loginName);
    }
}