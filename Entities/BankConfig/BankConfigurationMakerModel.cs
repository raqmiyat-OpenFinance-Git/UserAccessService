using Entities.BankConfigurationChecker;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.BankConfiguration
{
    public class BankConfigurationMakerModel
    {
        public string? TatSec { get; set; }
        public int ValidateMessage { get; set; }
        public int LogMsgAfterCBResponse { get; set; }
        public int AutoReturn { get; set; }
        public int AutoReverse { get; set; }
        public int SendPaymentInvestigationBeforeResend { get; set; }
        public int Enable4Eye { get; set; }
        public int Checkpariticpantavailbilityminutes { get; set; }
        public int OutwardPosting { get; set; }
        public int Inwardposting { get; set; }
        public string? Action { get; set; }
        public int CBCutoffHour { get; set; }
        public int CBCutoffMin { get; set; }
        public string? ReturnTATHours { get; set; }
        public string? CPRCutofftime { get; set; }
        public string? CPRMaxRecords { get; set; }
        public string? Outmsg { get; set; }

        public List<IntegrationTypeList>? IntegartionTypeList { get; set; }
        public string? IntegrationType { get; set; }
        public List<EnableMessageForwarding>? EnableMessageForwardinglist { get; set; }
        public string? EnableMessageForwarding { get; set; }
        public string? ActionBy { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedOn { get; set; }
        public string? Status { get; set; }


        public string? Approved_By { get; set; }
        public string? Approved_On { get; set; }
        public string? IsApproved { get; set; }
        public int TwoFactorAuthType { get; set; }
        public int BankExclude { get; set; }
        public int BatchIntervel { get; set; }
        public int BatchSize { get; set; }
        public string? BatchOption { get; set; }
        public string? Batch_SpecTime { get; set; }

        public bool Channel { get; set; }
        public bool Core { get; set; }
        public bool Batch { get; set; }
        public bool Realtime { get; set; }
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
        public int RateLimits { get; set; }

        public string? BankName { get; set; }
        public string? SwiftCode { get; set; }
        public int RoutingNo { get; set; }


    }
}
