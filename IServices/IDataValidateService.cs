using UserAccessService.Models;

namespace UserAccessService.IServices
{
    public interface IDataValidateService
    {
        IEnumerable<OwdBankSwiftCode> ValidateCreditorIBAN(string IBAN_NO);
    }
}
