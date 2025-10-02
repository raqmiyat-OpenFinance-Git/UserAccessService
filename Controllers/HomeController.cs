using Entities.Home;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.IServices;
using System.ServiceProcess;
using Newtonsoft.Json;
using OpenFinanceWebApi.Models;
using OpenFinanceWebApi.NLogService;
using UserAccessService.Models;

namespace OpenFinanceWebApi.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IHomeService HomeService;
        private readonly NLogWebApiService _logger;
        public HomeController(IHomeService HomeSer, NLogWebApiService logger)
        {
            HomeService = HomeSer;
            _logger = logger;
        }

        [HttpGet("api/Home/GetServiceStatus")]
        public IActionResult GetServiceStatus()
        {
            try
            {
                var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "services.json");

                if (!System.IO.File.Exists(jsonFilePath))
                {
                    return NotFound("JSON file not found.");
                }

                var jsonContent = System.IO.File.ReadAllText(jsonFilePath);
                var dataArray = JsonConvert.DeserializeObject<ServiceMonitoringModel[]>(jsonContent);

                foreach (var item in dataArray)
                {
                    try
                    {
                        using (var serviceController = new ServiceController(item.ServiceName))
                        {
                            item.ServiceStatus = serviceController.Status.ToString();
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        item.ServiceStatus = "Not Installed";
                        _logger.Error($"Service '{item.ServiceName}' not found or not installed.");
                        _logger.Error($"InvalidOperationException '{ex.Message}'");
                    }
                    catch (Exception ex)
                    {
                        item.ServiceStatus = "Not Installed";
                        _logger.Error($"An error occurred while fetching service status: {ex.Message}");
                    }
                }
                return Ok(dataArray);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Home/ChartDashboard")]
        public ChartDashboard GetChartDashboard(string PaymentModule)
        {
            try
            {
                return HomeService.GetChartDashboard(PaymentModule);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/Home/GetModule")]
        public List<FRMMENU> GetModule(string userCode)
        {
            try
            {
                return HomeService.GetModule(userCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/Home/GetPasswordPolicy")]
        public ValidatePassword GetPasswordPolicy()
        {
            try
            {
                return HomeService.GetPasswordPolicy();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
    }
}
