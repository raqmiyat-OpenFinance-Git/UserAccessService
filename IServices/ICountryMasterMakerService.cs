using Entities.Master;

namespace OpenFinanceWebApi.IServices
{
    public interface ICountryMasterMakerService
    {
        IEnumerable<CountryMakerModel> GetDetails();
        string AddCountry(CountryMakerModel country);
        IEnumerable<CountryMakerModel> GetCheckerDetails();
        CountryMakerModel GetCheckIndividualDetails(string Id);
        string ApproveOrRejectCountry(CountryMakerModel country);
        CountryMakerModel GetMakerIndividualDetails(string Id);
        string DeleteCountry(CountryMakerModel country);
        IEnumerable<CountryMakerModel> GetFilterMaker(string Search_Country_Code);
        public IEnumerable<CountryMakerModel> GetFilterCheck(string Search_Country_Code);
        public IEnumerable<CurrencyCode> getCurrencyCode();
    }
}
