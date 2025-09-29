using Entities.Common;
using Entities.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;
//using OpenFinanceWebApi.Custom;

namespace OpenFinanceWebApi.Controllers
{
    public class PasswordPolicyController : Controller
    {
        readonly IPasswordPolicyService ipasswordPolicyService;
        private readonly NLogWebApiService _logger;

        public PasswordPolicyController(IPasswordPolicyService policyService, NLogWebApiService logger)
        {
            ipasswordPolicyService = policyService;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/PasswordPolicy/GetPassworPolicy")]
        public PasswordPolicyModelView GetPassworPolicy()
        {
            try
            {
                return ipasswordPolicyService.GetPassworPolicy();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/PasswordPolicy/AddPasswordPolicy")]
        public ResponseStatus AddPasswordPolicy([FromBody] PasswordPolicyModelView passwordPolicyModelView)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = ipasswordPolicyService.AddPasswordPolicy(passwordPolicyModelView);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if(responseval.ToUpper() == "MAKERSUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "111";
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
        [Route("api/PasswordPolicy/PwdCheckerPolicy")]
        public IEnumerable<PasswordPolicyModelView> GetPasswordCheckerPolicy()
        {
            try
            {
                return ipasswordPolicyService.GetPasswordCheckerPolicy();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/PasswordPolicy/GetPasswordDetailsPolicy")]
        public PasswordPolicyModelView GetPasswordDetailsPolicy()
        {
            try
            {
                return ipasswordPolicyService.GetPasswordDetailsPolicy();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/PasswordPolicy/PasswordPolicyApprove")]
        public ResponseStatus PasswordPolicyApprove([FromBody] PasswordPolicyModelView passwordPolicyModelView)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = ipasswordPolicyService.Approve(passwordPolicyModelView);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
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
    }


}
