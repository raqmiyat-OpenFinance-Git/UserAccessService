using Newtonsoft.Json;

namespace OpenFinanceWebApi.Models
{
    public class CreditorPacs008Manual
    {
        public string? BeneficiaryCustomerAccountNumber { get; set; }
        public string? BeneficiaryCustomerAccountName { get; set; }
        public string? BeneficiaryCustomerAddressLine1 { get; set; }
        public string? BeneficiaryCustomerAddressLine2 { get; set; }
        public string? BeneficiaryCustomerAddressLine3 { get; set; }
        public string? BeneficiaryBankSwiftCode { get; set; }
    }

    public class CreditTransferRequestPacs008Manual
    {
        public RequestHeaderPacs008Manual? RequestHeader { get; set; }
        public RequestDetailsPacs008Manual? RequestDetails { get; set; }
        public string? ReferenceId { get; set; }
    }

    public class DebtorPacs008Manual
    {
        [JsonProperty("CIF")]
        public string? CIF { get; set; }
        public string? OrderingCustomerAccountNumber { get; set; }
        public string? OrderingCustomerAccountName { get; set; }
        public string? OrderingCustomerAddressLine1 { get; set; }
        public string? OrderingCustomerAddressLine2 { get; set; }
        public string? OrderingCustomerAddressLine3 { get; set; }
        public string? DetailsofPaymentLine1 { get; set; }
        public string? DetailsofPaymentLine2 { get; set; }
        public string? DetailsofPaymentLine3 { get; set; }
    }

    public class RequestDetailsPacs008Manual
    {
        public string? CategoryPurposeCode { get; set; }
        public decimal Amount { get; set; }
        public string? ValueDate { get; set; }
        public string? PurposeOfPayment { get; set; }
        public DebtorPacs008Manual? Debtor { get; set; }
        public CreditorPacs008Manual? Creditor { get; set; }
        public string? Currency { get; set; }
    }

    public class RequestHeaderPacs008Manual
    {
        public string? MsgFormat { get; set; }
        public string? RequestorChannelId { get; set; }
        public string? RequestorUserId { get; set; }
        public string? TransactionReference { get; set; }
        public string? RequestorDateTime { get; set; }
        public string? ChannelEnvironment { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
    }
}
