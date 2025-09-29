using Raqmiyat.Framework.Model;

namespace OpenFinanceWebApi.Models
{
    public class CoreBankRequestManual
    {
        public CreditTransferRequestPacs008Manual? CreditTransferRequest { get; set; }
        public string? MsgId { get; set; }
        public DateTime? Posting_sent_datetime { get; set; }
        public DateTime? Posting_recevied_datetime { get; set; }
        public bool IsBatch { get; set; }
       // public CustomerEnquiryResponseBody? CustomerEnquiryResponseBody { get; set; }
    }
}
