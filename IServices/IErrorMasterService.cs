using Entities.Error_Master;

namespace OpenFinanceWebApi.IServices
{
    public interface IErrorMasterService
    {
        IEnumerable<ErrorMasterModel> GetDetails();
        ErrorMasterModel GetErrorIndDetails(string Id);
        string AddErrorDetails(ErrorMasterModel error);
        string EditErrorMaster(ErrorMasterModel error);
        IEnumerable<ErrorMasterModel> GetErrorFilter(string Search_Error_Code);
        IEnumerable<ErrorMasterModel> GetErrorChecker();
        ErrorMasterModel GetCheckerIndErrorDetail(string Id);
        string DeleteErrorDetails(ErrorMasterModel error);
        string ApproveOrRejectError(ErrorMasterModel error);
        IEnumerable<ErrorTypeModel> GetErrorList();
        IEnumerable<ErrorCode> GetErrorCheckList(string id);
    }
}
