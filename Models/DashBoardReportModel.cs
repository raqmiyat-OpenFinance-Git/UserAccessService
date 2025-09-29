using System.ComponentModel.DataAnnotations;
using System.Security.Policy;


namespace NPSS_Connect.Models
{
    public class DashBoardReport
    {
        public List<DashBoardReportModel>? dashBoardReportModel { get; set; }

    }
    public class DashBoardReportModel
    {
        public string? Product { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
        public string? participant { get; set; }
        public string? processedtotalcount { get; set; }
        public string? processedtotalvalue { get; set; }
        public string? Rejectedtotalcount { get; set; }
        public string? Rejectedtotalvalue { get; set; }

        

    }

}
