using Entities.General;

namespace OpenFinanceWebApi.Models
{
    public class PaymentDetailReport
    {
        public string? Ref_Type { get; set; }
        public string? Ref_No { get; set; }
        public string? senderBic { get; set; }
        public DateTime? paymentDate { get; set; }

        public List<PaymentDetailReportResponse>? PaymentDetail_ReportResponse { get; set; }

    }
    public class PaymentDetailReportResponse
    {
        public string? messageReference { get; set; }
        public string? receiverBIC { get; set; }
        public string? amount { get; set; }
        public string? senderReference { get; set; }
        public string? source { get; set; }
        public string? senderBIC { get; set; }
        public DateTime? dateTimeReceived { get; set; }
        public string? paymentType { get; set; }
        public string? systemReference { get; set; }
        public string? categoryPurpose { get; set; }
        public string? batchReference { get; set; }
        public string? clrSysRef { get; set; }
        public string? beneficiaryBIC { get; set; }
        public string? productCode { get; set; }
        public string? uetr { get; set; }
        public string? payerBIC { get; set; }
        public string? currency { get; set; }
        public string? status { get; set; }
        public string? orgReference { get; set; }

    }

    public class PaymentStatusReport
    {
        public List<PaymentStatusReportModel>? paymentStatusReportModel { get; set; }
        public List<CurrencyCodes>? currencyCodes { get; set; }

    }
    public class PaymentStatusReportModel
    {
        public string? Currency { get; set; }

        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string? Timestamp { get; set; }
        public string? originatorreference { get; set; }
        public string? payer { get; set; }
        public string? sender { get; set; }
        public string? receiver { get; set; }
        public string? beneficary { get; set; }
        public string? amount { get; set; }
        public string? status { get; set; }
        public string? SenderReference { get; set; }
        public string? SystemReference { get; set; }
        public string? SettlementBatchReference { get; set; }
        public string? ReturnId { get; set; }
        public string? ReturnReference { get; set; }
        public string? TransactionId { get; set; }
        public string? UETR { get; set; }
        public string? MessageType { get; set; }
        public string? Direction { get; set; }


    }
}
