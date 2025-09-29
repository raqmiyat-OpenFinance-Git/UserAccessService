using CsvHelper.Configuration.Attributes;

namespace OpenFinanceWebApi.Models
{
    public class CustomerData
    {
        public string? CustomerName { get; set; }

        public string? SurName { get; set; }

        public string BankUserId { get; set; }

        public string? MobileNumber { get; set; }

        public List<string>? BankAccounts { get; set; }

        public List<string>? Currencies { get; set; }

        public string? ProxyEmirateId { get; set; }
        public string? ProxyMobileNumber { get; set; }
        public string? ProxyEmailId { get; set; }
        public Dictionary<string,string>? ProxyData { get; set; }
        public string? FilePath { get; set; }
        public long? HeaderId { get; set; }
        public int? Customer_RefID { get; set; }
        public string? Status { get; set; }
        public string? FileTypeDescription { get; set; }
    }
}
