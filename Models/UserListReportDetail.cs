using Entities.General;

namespace OpenFinanceWebApi.Models
{
    public class UserListReportDetail
    {
        public string? Userid { get; set; }
        public string? Username { get; set; }
        public string? Emailid { get; set; }
        public string? Mobileno { get; set; }
        public string? Status { get; set; }
        public string? userAccess { get; set; }
        public string? CreatedOn { get; set; }
        public string? createdby { get; set; }
        public string? ModifiedOn { get; set; }
        public string? Modifiedby { get; set; }
        public string? Password_ChangedOn { get; set; }
        public string? Wrong_Password_Attempt_date { get; set; }
        public string? Wrong_Password_Attempt_Count { get; set; }
        public string? LastLoggedOn { get; set; }
    }
}
