


using Entities.General;

namespace OpenFinanceWebApi.Models
{
    public class PaymentListReport
    {
        public List<PaymentListReportResponse>? PaymentList_ReportResponse { get; set; }

    }
    public class PaymentListReportResponse
    {
        public string? receiverBIC { get; set; }
        public string? amount { get; set; }
        public string? transactionReference { get; set; }
        public string? source { get; set; }
        public string? endToEndId { get; set; }
        public string? senderBIC { get; set; }
        public DateTime? dateTimeReceived { get; set; }
        public string? beneficiaryBIC { get; set; }
        public string? expReference { get; set; }
        public string? uetr { get; set; }
        public string? payerBIC { get; set; }
        public string? currency { get; set; }
        public string? status { get; set; }

    }
    
    public class PaymentListReportModel
    {
        public List<PaymentListReports>? paymentListReports { get; set; }
        public List<BankSwiftCode>? bankSwiftCodeList { get; set; }
        public List<CurrencyCodes>? currencyCodes { get; set; }
      
    }
    public class PaymentListReports
    {
        public string? SourceEH { get; set; }
        public string? OriginatorReference { get; set; }
        public string? Currency { get; set; }
        public string? senderReference { get; set; }
        public string? PaymentType { get; set; }
        public string? SystemReference { get; set; }
        public string? Payer { get; set; }
        public string? BatchSystemReference { get; set; }
        public string? Beneficary { get; set; }
        public string? MessageReference { get; set; }
        public string? Source { get; set; }
        public string? Amount { get; set; }
        public string? Status { get; set; }
        public string? Settlementcycle { get; set; }
        public DateTime? Settlement_Date_From { get; set; }
        public DateTime? Settlement_Date_to { get; set; }
        public DateTime? Date_From { get; set; }
        public DateTime? Date_to { get; set; }

        public DateTime? Timestamp { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public string? SettlementBatchReference { get; set; }
        public string? ReturnReference { get; set; }
        

    }

}
