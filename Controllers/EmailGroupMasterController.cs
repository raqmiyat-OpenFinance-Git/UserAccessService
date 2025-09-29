using Entities.Common;
using Microsoft.AspNetCore.Mvc;
using Entities.Master;
using OpenFinanceWebApi.NLogService;
using OpenFinanceWebApi.IServices;

namespace OpenFinanceWebApi.Controllers
{
    public class EmailGroupMasterController : ControllerBase
    {
        private readonly IEmailGroupMasterService _EmailGroupService;
        private readonly NLogWebApiService _logger;
        public EmailGroupMasterController(IEmailGroupMasterService emailGroup, NLogWebApiService logger)//, IConfiguration config)
        {
            _EmailGroupService = emailGroup;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/GetEmailGroupDetails")]
        public IEnumerable<EmailGroupMasterModel> GetEmailGroupDetails()
        {
            try
            {
                return _EmailGroupService.GetEmailGroupDetails();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/AddEmailGroup")]
        public ResponseStatus AddEmailGroup([FromBody] EmailGroupMasterModel country)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _EmailGroupService.AddEmailGroup(country);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseval.ToUpper() == "Already updated, Waiting for approval")
                {
                    errorDetail.ErrorCode = "111";
                    errorDetail.ErrorDesc = responseval;
                    errorDetails.Add(errorDetail);
                }
                else if (responseval.ToUpper() == "MAKER SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "222";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseval;
                    errorDetails.Add(errorDetail);
                }
            }
            catch (Exception ex)
            {
                errorDetail.ErrorCode = "400";
                errorDetail.ErrorDesc = "Exception " + ex.Message;
                errorDetails.Add(errorDetail); 
                _logger.Error(ex);
            }
            responsestatus.errorDetails = errorDetails;
            return responsestatus;

        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/GetEmailGroupCheckerDetails")]
        public IEnumerable<EmailGroupMasterModel> GetEmailGroupCheckerDetails()
        {
            try
            {
                return _EmailGroupService.GetEmailGroupCheckerDetails();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/GetEmailGroupCheckIndividualDetails")]
        public EmailGroupMasterModel GetEmailGroupCheckIndividualDetails(string EmailId, string EmailModule)
        {
            try
            {
                return _EmailGroupService.GetEmailGroupCheckIndividualDetails(EmailId, EmailModule);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/ApproveOrRejectEmailGroup")]

        public ResponseStatus ApproveOrRejectEmailGroup([FromBody] EmailGroupMasterModel country)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _EmailGroupService.ApproveOrRejectEmailGroup(country);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "SUCCESS";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseval;
                    errorDetails.Add(errorDetail);
                }
            }
            catch (Exception ex)
            {
                errorDetail.ErrorCode = "400";
                errorDetail.ErrorDesc = "Exception " + ex.Message;
                errorDetails.Add(errorDetail);
                _logger.Error(ex);
            }
            responsestatus.errorDetails = errorDetails;
            return responsestatus;

        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/GetMakerEmailGroupIndividualDetails")]
        public EmailGroupMasterModel GetMakerEmailGroupIndividualDetails(string Id,string email,string Module, string status)
        {
            try
            {
                return _EmailGroupService.GetMakerEmailGroupIndividualDetails(Id, email, Module, status);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/DeleteEmailGroup")]

        public ResponseStatus DeleteEmailGroup([FromBody] EmailGroupMasterModel country)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _EmailGroupService.DeleteEmailGroup(country);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseval == "The item Already processed, Waiting for approval!")
                {
                    errorDetail.ErrorCode = "111";
                    errorDetail.ErrorDesc = responseval;
                    errorDetails.Add(errorDetail);
                }
                else if (responseval.ToUpper() == "MAKER SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "222";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseval;
                    errorDetails.Add(errorDetail);
                }
            }
            catch (Exception ex)
            {
                errorDetail.ErrorCode = "400";
                errorDetail.ErrorDesc = "Exception " + ex.Message;
                errorDetails.Add(errorDetail);
                _logger.Error(ex);
            }
            responsestatus.errorDetails = errorDetails;
            return responsestatus;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/GetFilterEmailGroupMaker")]

        public IEnumerable<EmailGroupMasterModel> GetFilterEmailGroupMaker(string Search_Country_Code)
        {
            try
            {
                return _EmailGroupService.GetFilterEmailGroupMaker(Search_Country_Code);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/GetFilterEmailGroupChecker")]

        public IEnumerable<EmailGroupMasterModel> GetFilterEmailGroupChecker(string Search_Country_Code)
        {
            try
            {
                return _EmailGroupService.GetFilterEmailGroupChecker(Search_Country_Code);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/EmailGroupMaster/GetEmailModuleCode")]
        public IEnumerable<EmailModule> getEmailModuleCode()
        {
            try
            {
                return _EmailGroupService.getEmailModuleCode();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}

