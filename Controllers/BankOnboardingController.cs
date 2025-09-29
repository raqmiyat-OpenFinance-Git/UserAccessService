using Entities.Common;
using Entities.Master;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Controllers
{
    public class BankOnboardingController : ControllerBase
    {
        private readonly IBankOnboardingService UserService;
        private readonly NLogWebApiService _logger;
        public BankOnboardingController(IBankOnboardingService user, NLogWebApiService logger)
        {
            UserService = user;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/BankOnboarding/GetBankOnboardDetails")]
        public BankOnboardingModel GetBankOnboardDetails()
        {
            try
            {
                return UserService.GetDetails();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return default;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/BankOnboarding/GetIndDetOnboarding")]

        public BankOnboarding GetIndDetOnboarding(string Bank_Id)
        {
            try
            {
                return UserService.GetIndDet(Bank_Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return default;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/BankOnboarding/GetIndDetOnboardingid")]

        public BankOnboarding GetIndDetOnboardingid(string id)
        {
            try
            {
                return UserService.GetIndDetid(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

            }
            return default;
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/BankOnboarding/AddBank")]
        public ResponseStatus AddBank([FromBody] BankOnboarding user)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = UserService.Add(user);

                responsestatus.status = responseval.ToUpper();
                responsestatus.statusMessage = responseval.ToUpper();
                errorDetail.ErrorCode = "000";
                errorDetail.ErrorDesc = responseval.ToUpper();
                errorDetails.Add(errorDetail);

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
        [Route("api/BankOnboarding/EditBanKOnboard")]
        public ResponseStatus EditBanKOnboard([FromBody] BankOnboarding user)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = UserService.EditUser(user);

                responsestatus.status = responseval.ToUpper();
                responsestatus.statusMessage = responseval.ToUpper();
                errorDetail.ErrorCode = "000";
                errorDetail.ErrorDesc = responseval.ToUpper();
                errorDetails.Add(errorDetail);

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
        [Route("api/BankOnboarding/EditBanKOnboardReject")]
        public ResponseStatus EditBanKOnboardReject([FromBody] BankOnboarding user)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = UserService.EditUserReject(user);

                responsestatus.status = responseval.ToUpper();
                responsestatus.statusMessage = responseval.ToUpper();
                errorDetail.ErrorCode = "000";
                errorDetail.ErrorDesc = responseval.ToUpper();
                errorDetails.Add(errorDetail);

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
        [Route("api/BankOnboarding/CheckerBankOnboardingDetails")]
        public IEnumerable<BankOnboarding> CheckerBankOnboardingDetails()
        {
            try
            {
                return UserService.CheckerDetail();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

            }
            return default;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/BankOnboarding/GetCheckOnboardIndividualDetails")]
        public BankOnboarding GetCheckIndDetailsOnboard(string Id)
        {
            try
            {
                return UserService.GetCheckIndDetails(Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

            }
            return default;
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/BankOnboarding/Approve")]

        public ResponseStatus OnboardApprove([FromBody] BankOnboarding obj)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = UserService.Approve(obj);

                responsestatus.status = responseval.ToUpper();
                responsestatus.statusMessage = responseval.ToUpper();
                errorDetail.ErrorCode = "000";
                errorDetail.ErrorDesc = responseval.ToUpper();
                errorDetails.Add(errorDetail);

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
        [Route("api/BankOnboarding/Reject")]

        public ResponseStatus OnboardReject([FromBody] BankOnboarding obj)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = UserService.Reject(obj);

                responsestatus.status = responseval.ToUpper();
                responsestatus.statusMessage = responseval.ToUpper();
                errorDetail.ErrorCode = "000";
                errorDetail.ErrorDesc = responseval.ToUpper();
                errorDetails.Add(errorDetail);

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
        [Route("api/BankOnboarding/UploadOnboard")]
        public ResponseStatus UploadOnboard([FromBody] List<BankOnboarding> banks)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = UserService.UploadOnboard(banks);

                responsestatus.status = responseval.ToUpper();
                responsestatus.statusMessage = responseval.ToUpper();
                errorDetail.ErrorCode = "000";
                errorDetail.ErrorDesc = responseval.ToUpper();
                errorDetails.Add(errorDetail);

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
        [Route("api/BankOnboarding/GetBankOnboardSearch")]

        public IEnumerable<BankOnboarding> GetBankOnboardSearch(string BankName,string BankCode)
        {
            try
            {
                return UserService.GetBankOnboardSearch(BankName,BankCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}