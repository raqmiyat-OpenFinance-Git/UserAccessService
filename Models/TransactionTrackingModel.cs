namespace OpenFinanceWebApi.Models
{
    public class TransactionTrackingModel
    {
        public DateTime? ArrivedOn { get; set; }
        public string? Module { get; set; }
        public string? FullModule { get; set; }
        public string? TranType { get; set; }
        public string? EndToEndId { get; set; }
        public string? TransactionId { get; set; }
        public string? MessageId { get; set; }
        public string? Uetr { get; set; }
        public decimal Amount { get; set; }
        public string? DbtrName { get; set; }
        public string? DbtrAccount { get; set; }
        public string? DbtrAgent { get; set; }
        public string? CdtrName { get; set; }
        public string? CdtrAccount { get; set; }
        public string? CdtrAgent { get; set; }
        public string? SttlmtDate { get; set; }
        public List<TrackingDetails>? trackingDetails { get; set; }
    }
    public class TrackingDetails
    {
        public string? ProcessOfSection { get; set; }
        public string? ProcessStatus { get; set; }
        public string? ProcessDescription { get; set; }
        public string? ProcessAddInfo { get; set; }
        public DateTime? ProcessAt { get; set; }
     
    }
}
