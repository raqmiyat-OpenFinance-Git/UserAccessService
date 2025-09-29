using Entities.General;
using Entities.GeneralModel;


namespace OpenFinanceWebApi.IServices
{
    public interface IGeneralService
    {
        IEnumerable<General> GetGeneralList(string generalType);
        public IEnumerable<General> GetGeneralListforChrgMaster(string generalType, string ActionType);
        string GetNextMesageID(string instrName);
        string GetNext_ENQ_SEQ(string instrName);
        IEnumerable<BankSwiftCode> GetBankSwiftCode();
        IEnumerable<BankSwiftCode> GetRealTimeBankSwiftCode();
        IEnumerable<CategoryPurposeCode> GetCategoryPurposeCodes();
        IEnumerable<IssuerTypeCodes> GetIssuerTypeCodes();
        IEnumerable<EconomicActivityCodes> GetEconomicActivityCodes();
        IEnumerable<ChannelInformationIdentifierCodes> GetChannelInformationIdentifierCodes();
        IEnumerable<AccountTypeIdentifierCodes> GetAccountTypeIdentifierCodes();
        IEnumerable<MasterCurrencyCodes> GetMasterCurrencyCodes();
        IEnumerable<ReversalReasonIdentifierCodes> GetReversalReasonIdentifierCodes();
        IEnumerable<IsoCountry> GetIsoCountries();
        IEnumerable<BankSwiftCode> GetOnBoardBankList();
        IEnumerable<ReversalRejectionCodes> GetReversalRejectionCodes();
        IEnumerable<ReturnReasonCodes> GetReturnReasonCodes();
        IEnumerable<UserProductId> GetUserProductIds();
        IEnumerable<Roleid> GetRoleId();
        IEnumerable<GeneralFileName> GetFileNameList(string fromDate, string toDate, string transName);
        IEnumerable<GeneralFileName> GetAckNakFileNameList(string fromDate, string toDate, string transactionprocesstype, string transactiontype);
        IEnumerable<GeneralUserName> GetTransUserName();
  
        Task<IEnumerable<GeneralBranchlist>> GetGeneralBranchlist(string TransactionName);
    }
}
