using Entities.General;



namespace OpenFinanceWebApi.Models
{
    public class UserPropertiesReportModel
    {
        public List<UserPropertiesReport>? userPropertiesReport { get; set; }

        public List<BankSwiftCode>? bankSwiftCodeList { get; set; }
    }
    public class UserPropertiesReport
    {
        public string? Participant { get; set; }
        public string? UserName { get; set; }
        public string? User { get; set; }
        public string? status { get; set; }
        public string? Securityofficer { get; set; }
        public string? Administrator { get; set; }

    }

}
