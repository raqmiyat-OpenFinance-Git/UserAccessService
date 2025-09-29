namespace OpenFinanceWebApi.Models
{
    public class CBReconciliationsReport
    {
        public string? PostingRequestId { get; set; }
        public string? EndToEndId { get; set; }
        public string? ValueDate { get; set; }
        public string? PostingDate { get; set; }
        public string? Posting_Dr_Acct { get; set; }
        public string? Posting_Cr_Acct { get; set; }
        public decimal Posting_Amount { get; set; }
        public string? Posting_DR_CR { get; set; }
        public string? Narration1 { get; set; }
        public string? Narration2 { get; set; }
        public string? Posting_Status { get; set; }
        public string? Posting_sent_datetime { get; set; }
        public string? Posting_Host_RefNbr { get; set; }
        public string? Posting_Cr_Name { get; set; }
        public string? Posting_Dr_Name { get; set; }
        public string? Posting_Cr_Bank_Code { get; set; }
        public string? Posting_Dr_Bank_Code { get; set; }
        public string? Posting_For { get; set; }
        public string? TxnId { get; set; }
        public string? Uetr { get; set; }
    }
}
