namespace OpenFinanceWebApi.Models
{
    public class TrackingReportModel
    {
        public List<TrackingReport>? TrackingReportList { get; set; }
    }
    public class TrackingReport
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? Message_ID { get; set; }
        public string? EndtoEndID { get; set; }
        public string? Payment_Mode { get; set; }
        public string? Amount { get; set; }
        public string? IBan { get; set; }
        public string? Debitor_Name { get; set; }
        public string? Status { get; set; }
        public string? TransactionType { get; set; }


    }
}
