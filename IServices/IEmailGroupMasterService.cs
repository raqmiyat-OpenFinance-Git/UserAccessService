using Entities.Master;

namespace OpenFinanceWebApi.IServices
{
    public interface IEmailGroupMasterService
    {
        IEnumerable<EmailGroupMasterModel> GetEmailGroupDetails();
        string AddEmailGroup(EmailGroupMasterModel email);
        IEnumerable<EmailGroupMasterModel> GetEmailGroupCheckerDetails();
        EmailGroupMasterModel GetEmailGroupCheckIndividualDetails(string emailaddress, string EmailModule);
        string ApproveOrRejectEmailGroup(EmailGroupMasterModel email);
        EmailGroupMasterModel GetMakerEmailGroupIndividualDetails(string Id, string emailID, string Module, string status);
        string DeleteEmailGroup(EmailGroupMasterModel country);
        IEnumerable<EmailGroupMasterModel> GetFilterEmailGroupMaker(string Search_Country_Code);
        public IEnumerable<EmailGroupMasterModel> GetFilterEmailGroupChecker(string Search_Country_Code);
        public IEnumerable<EmailModule> getEmailModuleCode();
    }
}
