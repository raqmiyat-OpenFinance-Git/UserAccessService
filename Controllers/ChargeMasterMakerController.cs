using Entities.Master;
using Microsoft.AspNetCore.Mvc;
using Entities.Common;
using OpenFinanceWebApi.NLogService;
using OpenFinanceWebApi.IServices;

namespace OpenFinanceWebApi.Controllers
{
    public class ChargeMasterMakerController : ControllerBase
    {
        private readonly IChargeMasterMakerService Services;
        private readonly NLogWebApiService _logger;
        public ChargeMasterMakerController(IChargeMasterMakerService user, NLogWebApiService logger)//, IConfiguration config)
        {
            Services = user;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/ChargeMasterMaker/GetMakerDetails")]
        public IEnumerable<ChargeMasterMakerModel> GetMakerDetails()
        {
            try
            {
                return Services.GetMakerDetails();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/ChargeMasterMaker/AddCharge")]
        public ResponseStatus Addcharge([FromBody] ChargeMasterMakerModel user)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = Services.Addcharge(user);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseval.ToUpper() == "MAKER SUCCESS")
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
        [Route("api/ChargeMasterMaster/ViewMaster")]

        public ChargeMasterMakerModel GetIndDetails(string SegmentID)
        {
            try
            {
                return Services.GetIndDetails(SegmentID);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/ChargeMasterMaker/EditMaster")]
        public ResponseStatus EditMaster([FromBody] ChargeMasterMakerModel user)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = Services.EditMaster(user);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseval.ToUpper() == "MAKER SUCCESS")
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


        [HttpPost]
        [Route("[action]")]
        [Route("api/ChargeMasterMaker/DeleteAccountManager")]

        public ResponseStatus DeleteCharge([FromBody] ChargeMasterMakerModel model)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = Services.DeleteCharge(model);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseval.ToUpper() == "MAKERSUCCESS")
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
        [Route("api/ChargeMasterChecker/GetCheckerDetails")]
        public IEnumerable<ChargeMasterMakerModel> ChargeCheckerDetail()
        {
            try
            {
                return Services.ChargeCheckerDetail();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/ChargeMasterChecker/ChargeApproveOrReject")]

        public ResponseStatus ChargeApproveOrReject([FromBody] ChargeMasterMakerModel CheckerApprRej)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = Services.ChargeApproveOrReject(CheckerApprRej);
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
        [Route("api/ChargeMasterMaster/GetCheckerIndDetails")]

        public ChargeMasterMakerModel GetCheckerIndDetails(string SegmentID)
        {
            try
            {
                return Services.GetCheckerIndDetails(SegmentID);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/ChargeMasterMaker/GetSearch")]

        public IEnumerable<ChargeMasterMakerModel> GetSearch(string SegmentID)
        {
            try
            {
                return Services.GetSearch(SegmentID);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

    }
}
    

