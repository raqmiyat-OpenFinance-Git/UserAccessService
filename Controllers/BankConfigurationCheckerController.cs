using Entities.BankConfigurationChecker;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Controllers
{
    [ApiController]
    [Route("api/BankConfigurationChecker")]
    public class BankConfigurationCheckerController : Controller
    {
        private readonly IBankConfigurationCheckerService _bankConfigurationCheckerService;
        private readonly NLogWebApiService _logger;

        public BankConfigurationCheckerController(IBankConfigurationCheckerService bankconfigurationchecker, NLogWebApiService logger)
        {
            _bankConfigurationCheckerService = bankconfigurationchecker;
            _logger = logger;
        }

        [HttpPost]
        [Route("ApproveRejectBankConfiguration")]
        public bool ApproveRejectBankConfiguration([FromBody] BankConfigurationCheckerModel bankConfigurationCheckerModel)
        {
            try
            {
                return _bankConfigurationCheckerService.ApproveRejectBankConfiguration(bankConfigurationCheckerModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }


        [HttpGet]
        [Route("GetBankConfiguration")]
        public BankConfigurationCheckerModel GetBankConfiguration()
        {
            try
            {
                return _bankConfigurationCheckerService.GetBankConfiguration();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}
