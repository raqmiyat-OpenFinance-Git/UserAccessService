using Entities.Common;
using Microsoft.AspNetCore.Mvc;
using Raqmiyat.Entities.User;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Controllers
{

    public class ChangePasswordController : ControllerBase
    {
        private readonly IChangePasswordService changePasswordService;
        private readonly NLogWebApiService _logger;
        public ChangePasswordController(IChangePasswordService pwd, NLogWebApiService logger)//, IConfiguration config)
        {
            _logger = logger;
            changePasswordService = pwd;
        }
        
        
        [HttpPost]
        [Route("[action]")]
        [Route("api/ChangePassword/UpdatePassword")]
        public bool UpdatePassword([FromBody] ChangePassword changePassword)
        {
            try
            {
                return changePasswordService.UpdatePassword(changePassword);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return changePasswordService.UpdatePassword(changePassword);
            }
          
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/ChangePassword/UpdatePasswordHistory")]
        public ResponseStatus UpdatePasswordHistory([FromBody] ChangePassword changePassword)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = changePasswordService.UpdatePasswordHistory(changePassword);
                if (responseval.ToUpper() != "")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = responseval;
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
    }
}
