using Entities.BankConfiguration;
using Entities.BankConfigurationChecker;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Controllers
{
    [ApiController]
    [Route("api/BankConfigurationMaker")]
    public class BankConfigurationMakerController : Controller
    {
        private readonly IBankConfigurationMakerService _bankConfigurationMakerService;
        private readonly NLogWebApiService _logger;
        public BankConfigurationMakerController(IBankConfigurationMakerService bankConfigurationMakerService, NLogWebApiService logger)
        {
            _bankConfigurationMakerService = bankConfigurationMakerService;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddBankConfiguration")]
        public bool AddBankConfiguration([FromBody] BankConfigurationMakerModel bankConfigurationModel)
        {
            try
            {
                bool isSuccess = _bankConfigurationMakerService.AddBankConfiguration(bankConfigurationModel);
                return isSuccess;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("GetBankConfiguration")]
        public BankConfigurationMakerModel GetBankConfiguration()
        {
            try
            {
                return _bankConfigurationMakerService.GetBankConfiguration();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }

        [HttpGet]
        [Route("GetIntegrationTypes")]
        public IEnumerable<IntegrationTypeList> GetIntegrationTypes()
        {
            try
            {
                return _bankConfigurationMakerService.GetIntegrationTypes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }

        [HttpGet]
        [Route("GetEnableMessageForwardingList")]
        public IEnumerable<EnableMessageForwarding> GetEnableMessageForwardingList()
        {
            try
            {
                return _bankConfigurationMakerService.GetEnableMessageForwardingList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }
    }
}
