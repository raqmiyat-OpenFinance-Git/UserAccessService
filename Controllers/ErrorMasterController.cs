
using Entities.Common;
using Entities.Error_Master;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
namespace OpenFinanceWebApi.Controllers
{
    public class ErrorMasterController : ControllerBase
    {
        private readonly IErrorMasterService _ErrorService;
        private readonly NLogWebApiService _logger;
        public ErrorMasterController(IErrorMasterService error, NLogWebApiService logger)//, IConfiguration config)
        {
            _ErrorService = error;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/ErrorMaster/GetErrorDetails")]
        public IEnumerable<ErrorMasterModel> GetErrorDetails()
        {
            try
            {
                return _ErrorService.GetDetails();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/ErrorMaster/GetErrorDetailsInd")]
        public ErrorMasterModel GetErrorDetailsInd(string Id)
        {
            try
            {
                return _ErrorService.GetErrorIndDetails(Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/ErrorMaster/CreateErrorDetails")]
        public ResponseStatus CreateErrorDetails([FromBody] ErrorMasterModel error)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _ErrorService.AddErrorDetails(error);
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

        [HttpPost]
        [Route("[action]")]
        [Route("api/ErrorMaster/EditErrorMaker")]

        public ResponseStatus EditErrorMaker([FromBody] ErrorMasterModel error)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _ErrorService.EditErrorMaster(error);
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

        [HttpGet]
        [Route("[action]")]
        [Route("api/ErrorMaster/GetErrorsFilterMaker")]
        public IEnumerable<ErrorMasterModel> GetErrorsFilterMaker(string Search_Error_Code)
        {
            try
            {
                return _ErrorService.GetErrorFilter(Search_Error_Code);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/ErrorMaster/GetErrorCheckerDetails")]
        public IEnumerable<ErrorMasterModel> GetErrorCheckerDetails()
        {
            try
            {
                return _ErrorService.GetErrorChecker();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/ErrorMaster/GetCheckerIndErrorDetail")]
        public ErrorMasterModel GetCheckerIndErrorDetail(string Id)
        {
            try
            {
                return _ErrorService.GetCheckerIndErrorDetail(Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/ErrorMaster/DeleteErrorDetails")]
        public ResponseStatus DeleteErrorDetails([FromBody] ErrorMasterModel error)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _ErrorService.DeleteErrorDetails(error);
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

        [HttpPost]
        [Route("[action]")]
        [Route("api/ErrorMaster/ApproveOrRejectError")]
        public ResponseStatus ApproveOrRejectError([FromBody] ErrorMasterModel error)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _ErrorService.ApproveOrRejectError(error);
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
        [Route("api/ErrorMaster/GetErrorList")]
        public IEnumerable<ErrorTypeModel> GetErrorList()
        {
            try
            {
                return _ErrorService.GetErrorList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/ErrorMaster/GetErrorCheckList")]
        public IEnumerable<ErrorCode> GetErrorCheckList(string id)
        {
            try
            {
                return _ErrorService.GetErrorCheckList(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
          
        }
    }
}
