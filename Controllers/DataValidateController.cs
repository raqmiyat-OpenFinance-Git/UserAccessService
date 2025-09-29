using Microsoft.AspNetCore.Mvc;
using UserAccessService.IServices;
using UserAccessService.Models;

namespace UserAccessService.Controllers
{
    [ApiController]
    public class DataValidateController : ControllerBase
    {
        private readonly IDataValidateService datavalidateservice;

        public DataValidateController(IDataValidateService datavalidate)//, IConfiguration config)
        {

            datavalidateservice = datavalidate;
        }

        [HttpGet("/ValidateCreditorIBAN")]
        public IEnumerable<OwdBankSwiftCode> ValidateCreditorIBAN(string IBAN_NO)
        {
            return datavalidateservice.ValidateCreditorIBAN(IBAN_NO);

        }
    }
}
