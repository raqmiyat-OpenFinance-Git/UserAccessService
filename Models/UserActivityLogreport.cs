namespace OpenFinanceWebApi.Models
{
    public class UserActivityLogreport
    {
        public string? Action_On { get; set; }
        public string? userid { get; set; }
        public string? Action { get; set; }
        public string? Description { get; set; }
        public string? Source_IP { get; set; }
        public string? Destination_IP { get; set; }
        public string Transaction_Name { get; set; }
    }
}
