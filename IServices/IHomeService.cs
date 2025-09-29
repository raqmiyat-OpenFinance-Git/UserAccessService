using Entities.Home;
using System.Data;

namespace OpenFinanceWebApi.IServices
{
    public interface IHomeService
    {
        ChartDashboard GetChartDashboard(string PaymentModule);
        List<FullMenu> GetModule(string userCode);
        ValidatePassword GetPasswordPolicy();
    }
}
