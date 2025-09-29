using Entities.General;
using Entities.GeneralModel;

namespace OpenFinanceWebApi.Models
{
    public class PAC002AcceptRejectReport
    {
        public List<PAC002AcceptRejectReportSummary>? pac002AcceptRejectReportSummary { get; set; }
        public List<CategoryPurposeCodes>? categoryPurposeCodesList { get; set; }
        public List<General>? reportTypeList { get; set; }
        public List<GeneralFileName>? filenameList { get; set; }
        public string? categoryPurposeCode { get; set; }
        public string? ReportType { get; set; }
        public string? Filename { get; set; }
        public List<PAC002AcceptRejectReportDetail>? pac002AcceptRejectReportDetail { get; set; }

    }
    public class PAC002AcceptRejectReportSummary
    {
        public string? Ref_No { get; set; }
        public string? Processed_Batch_FileName { get; set; }
        public string? Ttl_Processed_Txns { get; set; }       
        public decimal? Ttl_Processed_Amount { get; set; }
        public string? Accepted_Count { get; set; }        
        public decimal? Accepted_Amount { get; set; }
        public string? Rejected_Count { get; set; }
        public decimal? Rejected_Amount { get; set; }
        public string? PSR_ACCP_FileName { get; set; }
        public string? RJCT_FileName { get; set; }
        public string? Creation_Date { get; set; }       
    }
    public class PAC002AcceptRejectReportDetail
    {
        public string? Processed_Batch_FileName { get; set; }
        public string? EndToEnd_Identification { get; set; }        
        public string? SerialNo { get; set; }
        public string? Debtor_Name { get; set; }
        public string? Debtor_IBAN { get; set; }
        public string? Creditor_Name { get; set; }
        public string? Creditor_IBAN { get; set; }
        public decimal? Settlement_Amount { get; set; }
        public string? IsAcceptedOrRejected { get; set; }
        public string? Error_Number { get; set; }
        public string? Error_Description { get; set; }
        public string? Status_Rsn_Add_Inf { get; set; }
        public string? PSR_ACCP_FileName { get; set; }
        public string? RJCT_FileName { get; set; }
        public string? Creation_Date { get; set; }

    }
}
