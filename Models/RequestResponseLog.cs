using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFinanceWebApi.Models
{
    [Table("IPP_RequestResponseLogs")]
    public class RequestResponseLog
    {
        public int Id { get; set; }

        // New properties for IP address and request ID
        public string RequestId { get; set; }
        public string IpAddress { get; set; }

        public string RequestPath { get; set; }
        public string RequestMethod { get; set; }
        public string RequestHeaders { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public int ResponseStatusCode { get; set; }

        // Auto-initialized to current timestamp
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
