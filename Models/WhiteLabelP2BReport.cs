namespace OpenFinanceWebApi.Models
{
    public class WhiteLabelP2BReport
    {
   
        public string? Currency { get; set; }
        public string? ErrMsg { get; set; }
        public string? ReceivedDate { get; set; }
        public string? SentDate { get; set; }
        public string? Amount { get; set; }
        public string? SenderIBan { get; set; }
        public string? RecipientIBan { get; set; }
        public string? SenderBankCode { get; set; }
        public string? RecipientBankCode { get; }
        public string? TransactionType { get; }
        public string? TransactionID { get; set; }
        public string? RecipientMobile { get; set; }
 
        public string? RecipientName { get; set; }
        public string? Status { get; set; }
        public string? Transaction_No { get; set; }

    }
}
