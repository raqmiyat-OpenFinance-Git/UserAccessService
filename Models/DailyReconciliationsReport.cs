
using Entities.General;

namespace OpenFinanceWebApi.Models
{
    public class DailyReconciliations
    {

        public string MOP { get; set; }
        public string MsgType { get; set; }
        public string CB_E2E_Id { get; set; }
        public string CB_Sttlmt_Dt { get; set; }
        public string CB_Ref { get; set; }
        public decimal CB_Sttlmt_Amt { get; set; }
        public string CB_Status { get; set; }
        public string C53_Reference { get; set; }
        public string C53_Cr_Dr { get; set; }
        public decimal C53_Amt { get; set; }
        public string CBS_Req_Ref { get; set; }
        public string CBS_Host_Ref { get; set; }
        public string CBS_Cr_Acct { get; set; }
        public string CBS_Dr_Acct { get; set; }
        public string CBS_Sent_Time { get; set; }
    }

}
