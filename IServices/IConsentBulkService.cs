using OpenFinance.Models;

namespace OpenFinanceWebApi.IServices
{
    public interface IConsentBulkService
    {
        string InsertConsentBulk(ConsentBulkUploadModel consentBulkUpload);
        List<ConsetBulkUploadindividual> FetchConsentBulk();
        ConsetBulkUploadindividual FetchConsentBulkindividual(string id);
    }
}
