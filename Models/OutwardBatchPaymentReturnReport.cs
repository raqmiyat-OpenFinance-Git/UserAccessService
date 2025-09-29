using Entities.General;
using Entities.GeneralModel;

namespace OpenFinanceWebApi.Models
{
    public class OutwardBatchPaymentReturnReport
    {
        public List<OutwardBatchPaymentTransferSummary>? outwardBatchPaymentTransferSummary { get; set; }
        public List<CategoryPurposeCodes>? categoryPurposeCodesList { get; set; }
        public List<General>? reportTypeList { get; set; }
        public List<GeneralFileName>? filenameList { get; set; }
        public string? categoryPurposeCode { get; set; }
        public string? ReportType { get; set; }
        public string? Filename { get; set; }
        public List<OutwardBatchPaymentTransferDetail>? outwardBatchPaymentTransferDetail { get; set; }

    }
    public class OutwardBatchPaymentTransferDetail
    {
        public string? Return_RefNbr { get; set; }
        public string? Original_RefNbr { get; set; }
        public string? Batch_FileName { get; set; }
        public string? SerialNo { get; set; }
        public decimal? Original_Settlement_Amount { get; set; }
        public decimal? Returned_Settlement_Amount { get; set; }
        public string? Debtor_IBAN { get; set; }
        public string? Debtor_Name { get; set; }
        public string? Creditor_Name { get; set; }
        public string? Creditor_IBAN { get; set; }
        public string? CreatedOn { get; set; }
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
    public class OutwardBatchPaymentTransferSummary
    {
        public string? Return_RefNbr { get; set; }
        public string? Original_RefNbr { get; set; }
        public decimal? Total_Return_Amount { get; set; }
        public string? Batch_FileName { get; set; }
        public string? Number_Of_Transactions { get; set; }
        public string? Instructing_Agent_FI_ID { get; set; }
        public string? Instructed_Agent_FI_ID { get; set; }
        public string? CreatedOn { get; set; }
        public string? IPPCore_Status { get; set; }

    }
}
