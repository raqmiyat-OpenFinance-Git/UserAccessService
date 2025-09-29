namespace OpenFinanceWebApi.Models
{

    public class InwardReversal
    {

        public string? Creation_Date { get; set; }
        public string? Ref_No { get; set; }
        public string? Amount { get; set; }
        public string? Beneficiary_Bank { get; set; }
        public string? Creditor_IBAN { get; set; }
        public string? Debtor_IBAN { get; set; }
        public string? CatPurposeCode { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }
        public string? PaymentReferenceNumber { get; set; }
        public string? Vaulet_Date { get; set; }
        public string? Payment_Platform { get; set; }
        public string? Returned_Amount { get; set; }
        public string? Return_Message_Identification { get; set; }
        public string? Creditor_Name { get; set; }
        public string? Debtor_Name { get; set; }
        public string? Message_Identification { get; set; }
        public string? Reversal_Message_identification { get; set; }

        public string? Narration { get; set; }
        public string? ExternalRefno { get; set; }
        public string? Postingstatus { get; set; }

    }
}
