using Entities.General;

namespace OpenFinanceWebApi.Models
{
    public class Admin004Report
    {
        public List<BankSwiftCode>? bankSwiftCodeList { get; set; }
        public string? BeneficiaryBankName { get; set; }
        public string? Bank_Swift_Code { get; set; }
        public string? Event_StartTime { get; set; }
        public string? Event_EndTime { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? RecordType { get; set; }
    }
}
