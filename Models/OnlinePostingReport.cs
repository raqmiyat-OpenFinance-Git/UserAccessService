namespace OpenFinanceWebApi.Models
{
    public class OnlinePostingReport
    {
        public string? Posting_ipp_ref_nbr { get; set; }
        public string? Posting_Host_RefNbr { get; set; }
        public string? Posting_Dr_Acct { get; set; }
        public string? Posting_Cr_Acct { get; set; }
        public string? Posting_Amount { get; set; }
        public string? Posting_request_type { get; set; }
        public string? Posting_Status { get; set; }
        public string? Posting_return_code { get; set; }
        public string? Posting_return_description { get; set; }
        public string? Posting_sent_datetime { get; set; }
        public string? Posting_recevied_datetime { get; set; }
    }
}
