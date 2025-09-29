using Entities.Common;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using OpenFinanceWebApi.Services;
using Raqmiyat.Entities.Login;


namespace OpenFinanceWebApi.Controllers
{
    [ApiController]
    [Route("api/RoleMaker")]
    public class RoleMakerController : ControllerBase
    {
        private readonly IRoleMakerService _roleMakerService;
        private readonly NLogWebApiService _logger;
        public RoleMakerController(IRoleMakerService roleMakerService, NLogWebApiService logger)
        {
            _roleMakerService = roleMakerService; 
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateRole")]
        public ResponseStatus CreateRole([FromBody] Role role)
        {
            var responseStatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();

            try
            {
                var responseValue = _roleMakerService.CreateRole(role);

                if (responseValue.ToUpper() == "SUCCESS")
                {
                    responseStatus.status = responseValue.ToUpper();
                    responseStatus.statusMessage = responseValue.ToUpper();

                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseValue.ToUpper() == "MAKERSUCCESS")
                {
                    responseStatus.status = responseValue.ToUpper();
                    responseStatus.statusMessage = responseValue.ToUpper();

                    errorDetail.ErrorCode = "111";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseValue;
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

            responseStatus.errorDetails = errorDetails;
            return responseStatus;
        }


        [HttpGet]
        [Route("GetRoleDetails")]
        public IEnumerable<Role> GetRoleDetails()
        {
            try
            {
                return _roleMakerService.GetRoleDetails();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }

        [HttpPost]
        [Route("GetSearchRoleDetails")]
        public IEnumerable<Role> GetSearchRoleDetails(Role role)
        {
            try
            {
                return _roleMakerService.GetSearchRoleDetails(role);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        [Route("UpdateRole")]
        public ResponseStatus UpdateRole([FromBody] Role role)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();

            try
            {
                var responseval = _roleMakerService.UpdateRole(role);

                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = "SUCCESS";
                    responsestatus.statusMessage = "SUCCESS";
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                }
                else if (responseval.ToUpper() == "MAKERSUCCESS")
                {
                    responsestatus.status = "MAKERSUCCESS";
                    responsestatus.statusMessage = "MAKERSUCCESS";
                    errorDetail.ErrorCode = "111";
                    errorDetail.ErrorDesc = "";
                }
                else
                {
                    responsestatus.status = "FAILURE";
                    responsestatus.statusMessage = "FAILURE";
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseval;
                }
            }
            catch (Exception ex)
            {
                responsestatus.status = "ERROR";
                responsestatus.statusMessage = "ERROR";
                errorDetail.ErrorCode = "400";
                errorDetail.ErrorDesc = "Exception " + ex.Message;
                _logger.Error(ex);
            }

            errorDetails.Add(errorDetail);
            responsestatus.errorDetails = errorDetails;
            return responsestatus;
        }


        [HttpGet]
        [Route("GetProductTypes")]
        public IEnumerable<ProductType> GetProductTypes()
        {
            try
            {
                return _roleMakerService.GetProductTypes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}
