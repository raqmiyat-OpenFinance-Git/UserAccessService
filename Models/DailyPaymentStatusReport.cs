namespace IPP_Connect.Models
{
    public class DailyPaymentStatusReport
    {
        public List<DailyPaymentStatus> dailyPaymentStatuseList { get; set; }
    }

    public class DailyPaymentStatus
    {
        public string? Timestamp { get; set; }
        public string? OriginatorReference { get; set; }
        public string? Sender { get; set; }
        public string? Payer { get; set; }
        public string? Receiver { get; set; }
        public string? Beneficiary { get; set; }
        public string? Currency { get; set; }
        public string? Amount { get; set; }  
        public string? Status { get; set; }
        public string? SenderReference { get; set; }
        public string? SystemReference { get; set; }
        public string? SettlementBatchReference { get; set; }
        public string? ReturnID { get; set; }
        public string? ReturnReference { get; set; }
        public string? TransactionID { get; set; }
        public string? UETR { get; set; }
        public string? MessageType { get; set; }
        public string? CreationDateTime { get; set; } 
        public string? FileName { get; set; } 
    }
}
