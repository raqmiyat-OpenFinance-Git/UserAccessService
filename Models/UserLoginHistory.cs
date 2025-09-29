namespace OpenFinanceWebApi.Models
{
    public class UserLoginHistory
    {
        public string UserName { get; set; }
        public DateTime LogInDateTime { get; set; }
        public string WorkStationID { get; set; }
        public string LoginStatus { get; set; }
    }
}
