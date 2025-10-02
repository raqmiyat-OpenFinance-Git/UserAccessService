using Entities.Home;
using System.Data;
using UserAccessService.Models;

namespace OpenFinanceWebApi.IServices
{
    public interface IHomeService
    {
        ChartDashboard GetChartDashboard(string PaymentModule);
        List<FRMMENU> GetModule(string userCode);
        ValidatePassword GetPasswordPolicy();
    }
}
