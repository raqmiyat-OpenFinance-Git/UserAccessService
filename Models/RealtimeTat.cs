namespace NPSS_Connect.Models
{
    public class RealtimeTatReport
    {
        public List<RealtimeTat>? Realtime_Tat { get; set; }
        public string? Module { get; set; }
    }
    public class RealtimeTat
    {
        public string? Org_Reference { get; set; }
        public string? Pmt_Via { get; set; }
        public string? Pmt_Date { get; set; }
        public string? Acc_Enq_At { get; set; }
        public string? Amt_Rsrvd_At { get; set; }
        public string? Sent_To_Cb_At { get; set; }
        public string? Pmt_Svd_At { get; set; }
        public string? CB_Reply_At { get; set; }
        public string? Amt_Dbtd_At { get; set; }
        public string? Amt_Rlsd_At { get; set; }
        public string? CB_Status { get; set; }
        public string? CB_RefNbr { get; set; }
        public string? Rcvd_Ipp_At { get; set; }
        public string? Acc_Valid_Res_At { get; set; }
        public string? CB_Ack_At { get; set; }
        public string? Amt_Crtd_At { get; set; }
        public string? CB_Ref { get; set; }
        public string? Acc_Status { get; set; }
        public string? CB_Ack_Status { get; set; }
    }
}
