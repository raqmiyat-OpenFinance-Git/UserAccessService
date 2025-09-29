using Entities.GeneralModel;

namespace OpenFinanceWebApi.Models
{
    public class CprEodReport
    {
        public List<CprEodReportDetail>? cprEodReportDetail { get; set; }
        public List<CprEodReportSummary>? cprEodReportSummary { get; set; }
        public List<General>? reportTypeList { get; set; }
        public string? ReportType { get; set; }

    }
    public class CprEodReportSummary
    {
        public string? MessageId { get; set; }
        public string? CreationDatetime { get; set; }
        public string? InstgAgent { get; set; }
        public string? InstdAgent { get; set; }
        public string? OrgMsgNameId { get; set; }
        public string? TtlNoTxns { get; set; }
        public string? TtlSumAmt { get; set; }
        public string? Generated_FileName { get; set; }

    }
    public class CprEodReportDetail
    {
        public string? Status_ID { get; set; }
        public string? OrgMsgId { get; set; }
        public string? OrgEndToEnd { get; set; }
        public string? OrgTxnId { get; set; }
        public string? StsRsn { get; set; }
        public string? OrgIntrBkSttlAmt { get; set; }
        public string? OrgIntrBkSttlDt { get; set; }
        public string? OrgDbtrAgent { get; set; }
        public string? OrgCdtrAgent { get; set; }
        public string? CreditorName { get; set; }
        public string? CreditorIBAN { get; set; }
        public string? OrgMsgName { get; set; }
        public string? PaymentType { get; set; }


    }


}
