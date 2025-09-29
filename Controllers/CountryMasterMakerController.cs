using Entities.Common;
using Entities.Master;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;


namespace OpenFinanceWebApi.Controllers
{
    public class CountryMasterMakerController : ControllerBase
    {
        private readonly ICountryMasterMakerService _CountryService;
        private readonly NLogWebApiService _logger;
        public CountryMasterMakerController(ICountryMasterMakerService country, NLogWebApiService logger)//, IConfiguration config)
        {
            _CountryService = country;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/CountryMasterMaker/GetDetails")]
        public IEnumerable<CountryMakerModel> GetDetails()
        {
            try
            {
                return _CountryService.GetDetails();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/CountryMasterMaker/AddCountry")]
        public ResponseStatus AddCountry([FromBody] CountryMakerModel country)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _CountryService.AddCountry(country);
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
        [Route("api/CountryMasterMaker/GetCheckerDetails")]
        public IEnumerable<CountryMakerModel> GetCheckerDetails()
        {
            try
            {
                return _CountryService.GetCheckerDetails();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/CountryMasterMaker/GetCheckIndividualDetails")]
        public CountryMakerModel GetCheckIndividualDetails(string Id)
        {
            try
            {
                return _CountryService.GetCheckIndividualDetails(Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/CountryMasterMaker/ApproveOrRejectCountry")]

        public ResponseStatus ApproveOrRejectCountry([FromBody] CountryMakerModel country)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _CountryService.ApproveOrRejectCountry(country);
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
        [Route("api/CountryMasterMaker/GetMakerIndividualDetails")]
        public CountryMakerModel GetMakerIndividualDetails(string Id)
        {
            try
            {
                return _CountryService.GetMakerIndividualDetails(Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/CountryMasterMaker/DeleteCountry")]

        public ResponseStatus DeleteCountry([FromBody] CountryMakerModel country)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _CountryService.DeleteCountry(country);
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
        [Route("api/CountryMasterMaker/GetFilterMaker")]

        public IEnumerable<CountryMakerModel> GetFilterMaker(string Search_Country_Code)
        {
            try
            {
                return _CountryService.GetFilterMaker(Search_Country_Code);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/CountryMasterMaker/GetFilterChecker")]

        public IEnumerable<CountryMakerModel> GetFilterChecker(string Search_Country_Code)
        {
            try
            {
                return _CountryService.GetFilterCheck(Search_Country_Code);

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/CountryMasterMaker/GetCurrencyList")]
        public IEnumerable<CurrencyCode> GetCurrencyList()
        {
            try
            {
                return _CountryService.getCurrencyCode();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}

