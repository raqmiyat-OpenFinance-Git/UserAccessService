using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.BankConfigurationChecker
{
    public class BankConfigurationCheckerModel
    {
        public int BC_ID { get; set; }
        public int TatSec { get; set; }
        public int ValidateMessage { get; set; }
        public string? Action { get; set; }
        public string? EnableMessageForwarding { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedOn { get; set; }
        public string? Status { get; set; }
        public string? Approved_By { get; set; }
        public string? Approved_On { get; set; }
        public string? IsApproved { get; set; }
        public string? IsRejected { get; set; }
        public string? UserName { get; set; }
        public object? ActionBy { get; set; }
        public int TwoFactorAuthType { get; set; }
        public int BankExclude { get; set; }
        public bool ConsentEventAction { get; set; }
        public bool ConsentManagement { get; set; }
        public bool DataSharing { get; set; }
        public bool ServiceInitiation { get; set; }
        public string? AuditTrailEnabled { get; set; }
        public string? BankId { get; set; }
        public string? ApiVersion { get; set; }
        public string? TimeZoneLocale { get; set; }
        public string? CurrencyDefault { get; set; }

        public string? ConsentValidityPeriod { get; set; }
        public int? SessionTimeout { get; set; }
        public int? RetryCount { get; set; }
        public string? DataRetentionPeriod { get; set; }
        public int? RateLimits { get; set; }
        public string? BankName { get; set; }
        public string? SwiftCode { get; set; }
        public int RoutingNo { get; set; }
    }

    public class IntegrationTypeList
    {
        public string? Inte_Type_Name { get; set; }
        public string? Inte_Type_Value { get; set; }
    }

    public class EnableMessageForwarding
    {
        public string? FTS_Type_Name { get; set; }
        public string? IPI_Type_Value { get; set; }
    }

    public class bankconChekfigList
    {
        public string? TatSec { get; set; }
        public string? ValidateMessage { get; set; }
        public string? LogMsgAfterCBResponse { get; set; }
        public string? AutoReturn { get; set; }
        public string? AutoReverse { get; set; }
        public string? SendPaymentInvestigationBeforeResend { get; set; }
        public string? Enable4Eye { get; set; }
        public string? Checkpariticpantavailbilityminutes { get; set; }
        public string? OutwardPosting { get; set; }
        public string? Inwardposting { get; set; }
        public string? IntegrationType { get; set; }
    }
}


