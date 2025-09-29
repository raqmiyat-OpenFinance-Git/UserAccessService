using Microsoft.AspNetCore.Mvc;
using NPSS_Connect.Models;
using OpenFinanceWebApi.Data;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.Models;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService dashboardService;
        private readonly NPSSDbContext _context;
        private readonly NLogWebApiService _logger;
        public DashboardController(IDashboardService dashboard, NPSSDbContext context, NLogWebApiService logger)
        {
            dashboardService = dashboard;
            _context = context;
            _logger = logger;
        }

        [HttpGet("GetDashBoardNewDesign")]
        public async Task<List<Dictionary<string, object>>> GetReportDataAsync()
        {
            DateTime date = DateTime.Today;
            return await _context.GetReportDataAsync(date);
        }


        [HttpGet("GetDashBoardNew")]
        public async Task<List<List<DashBoardResultModel>>> GetDashBoardNew()
        {
            try
            {
                DateTime date = DateTime.Today;
                return await _context.GetDashBoardResults(date);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }

        [HttpGet("GetDashBoardByCategory")]
        public async Task<List<List<DashBoardResultModel>>> GetDashBoardByCategory()
        {
            try
            {
                DateTime date = DateTime.Today;
                return await _context.GetDashBoardByCategory(date);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }

        [HttpGet("GetDemoDashboard")]
        public async Task<IEnumerable<DashBoard>> GetDemoDashboard(string paymentModule, string paymentType, string processType)
        {
            try
            {
                return await dashboardService.GetDemoDashboardAsync(paymentModule, paymentType, processType);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }

        [HttpGet("GetDashboardAlert")]
        public async Task<IEnumerable<DashBoardAlert>> GetDashboardAlert(string loginName)
        {
            try
            {
                return await dashboardService.GetDemoDashboardAlertAsync(loginName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }

        [HttpGet("GetDashboardMasterAlert")]
        public async Task<IEnumerable<DashBoardMasterAlert>> GetDashboardMasterAlert(string loginName)
        {
            try
            {
                return await dashboardService.GetDemoDashboardMasterAlertAsync(loginName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }
    }
}
