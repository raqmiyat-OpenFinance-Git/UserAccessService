using Entities.General;

namespace OpenFinanceWebApi.Models
{
    public class AccountListReportMdel
    {
        public List<AccountListReport>? accountListReport { get; set; }
        public List<CurrencyCodes>? currencyCodes { get; set; }       
        public List<BankSwiftCode>? bankSwiftCodeList { get; set; }
    }
    public class AccountListReport
    {
        public string? Source { get; set; }
        public string? AccountHolder { get; set; }
        public string? AccountNumber { get; set; }
        public string? AvailableAmount { get; set; }
        public string? Balance { get; set; } 
        public string? Limit { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }

    }

}
