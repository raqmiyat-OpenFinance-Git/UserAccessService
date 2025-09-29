using Entities.Master;

namespace OpenFinanceWebApi.IServices
{
    public interface IBankOnboardingService
    {
        BankOnboardingModel GetDetails();

        BankOnboarding GetIndDet(string Bank_Id);
        BankOnboarding GetIndDetid(string id);
        string Add(BankOnboarding user);

        string EditUser(BankOnboarding user);
        string EditUserReject(BankOnboarding user);


     

        IEnumerable<BankOnboarding> CheckerDetail();

        BankOnboarding GetCheckIndDetails(string Id);

        string Approve(BankOnboarding obj);
        string Reject(BankOnboarding obj);
        string UploadOnboard(List<BankOnboarding> obj);


        IEnumerable<BankOnboarding> GetBankOnboardSearch(string BankName,string BankCode);
    }
}
