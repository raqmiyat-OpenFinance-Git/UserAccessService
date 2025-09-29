using Entities.Common;
using Microsoft.AspNetCore.Mvc;
using OpenFinance.Models;
using OpenFinanceWebApi.IServices;

namespace OpenFinanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsentBulkUploadController : ControllerBase
    {

        private readonly IConsentBulkService _service;

        public ConsentBulkUploadController(IConsentBulkService service)
        {
            _service = service;
        }
     
        [HttpPost]
        [Route("[action]")]
        [Route("api/ConsentBulkUpload/InsertConsentBulk")]

        
        public ResponseStatus InsertConsentBulk([FromBody] ConsentBulkUploadModel consentBulkUpload)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = _service.InsertConsentBulk(consentBulkUpload);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseval.ToUpper() == "DUPLICATE")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "111";
                    errorDetail.ErrorDesc = "DUPLICATE";
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
            }
            responsestatus.errorDetails = errorDetails;
            return responsestatus;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/ConsentBulkUpload/FetchConsentBulk")]

        public IEnumerable<ConsetBulkUploadindividual> FetchConsentBulk()
        {
            return _service.FetchConsentBulk();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/ConsentBulkUpload/FetchConsentBulkindividual")]

        public ConsetBulkUploadindividual FetchConsentBulkindividual(string id)
        {
            return _service.FetchConsentBulkindividual(id);
        }



    }
}
