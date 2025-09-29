namespace OpenFinanceWebApi.Models
{
    public class ParticipantSubscriptionReport
    {
        public string? BankId { get; set; }
        public string? BankCode { get; set;}
        public string? BankName { get; set; }
        public string? SwiftCode { get; set; }
        public string? IPP_Live { get; set;}
        public string? IPP_Real_Time { get; set; }
        public string? CreatedOn { get;set; }

    }
    public class ParticipantSubscriptionReportModel
    {
        public string? BIC { get; set; }
        public string? EID { get; set; }
        public string? EntityName { get; set; }
        public string? CoreServiceRealtime { get; set; }
        public string? CoreServiceBatch { get; set; }
        public string? OverlayService { get; set; }
    }
}
