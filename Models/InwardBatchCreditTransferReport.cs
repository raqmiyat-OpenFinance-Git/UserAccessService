using Entities.General;
using Entities.GeneralModel;

namespace OpenFinanceWebApi.Models
{
    public class InwardBatchCreditTransferReport
    {
        public List<InwardBatchCreditTransferSummary>? inwardBatchCreditTransferSummary { get; set; }
        public List<CategoryPurposeCodes>? categoryPurposeCodesList { get; set; }
        public List<General>? reportTypeList { get; set; }
        public List<GeneralFileName>? filenameList { get; set; }
        public string? categoryPurposeCode { get; set; }
        public string? ReportType { get; set; }
        public string? Filename { get; set; }
        public List<InwardBatchCreditTransferDetail>? inwardBatchCreditTransferDetail { get; set; }
    }
    public class InwardBatchCreditTransferDetail
    {
        public string? Ref_No { get; set; }
        public string? Batch_FileName { get; set; }
        public string? SerialNo { get; set; }
        public string? EndToEnd_Identification { get; set; }
        public string? Debtor_Name { get; set; }
        public string? Debtor_IBAN { get; set; }
        public string? Creditor_Name { get; set; }
        public string? Creditor_IBAN { get; set; }
        public decimal? Settlement_Amount { get; set; }
        public string? Creation_Date { get; set; }
        public string? IPPCore_Status { get; set; }
        public string? Posting_Status { get; set; }
        public string? PaymentReferenceNumber { get; set; }
        public string? BeneficiaryBankName { get; set; }
        public string? Message_Identification { get; set; }
        public string? ExternalRefno { get; set; }
        public string? Interbank_Settlement_Date { get; set; }
        public string? Payment_plateform { get; set; }
        public string? CategoryPurpose_Code { get; set; }
        public string? Status { get; set; }
    }
    public class InwardBatchCreditTransferSummary
    {
        public string? Creation_Date { get; set; }
        public string? Ref_No { get; set; }
        public decimal? Amount { get; set; }
        public string? BATHDR_Interbank_Settlement_Date { get; set; }
        public string? BATHDR_Settlement_Method { get; set; }
        public string? BATHDR_Clearing_System_Proprietary { get; set; }
        public string? BATHDR_IsAuto { get; set; }
        public string? BATHDR_Instructing_Agent_FI_ID { get; set; }
        public string? BATHDR_Instructed_Agent_FI_ID { get; set; }
        public string? BATHDR_IPPCore_Status { get; set; }
        public string? BATDET_Creditor_IBAN { get; set; }
        public int? Number_Of_Transactions { get; set; }
        public string? Batch_FileName { get; set; }


    }
}
