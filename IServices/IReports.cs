using IPP_Connect.Models;
using NPSS_Connect.Models;
using OpenFinanceWebApi.Models;


namespace OpenFinanceWebApi.IServices
{
    public interface IReports
    {
        Task<List<OutwardCreditTransfer>> OutwardCreditTransferReport(ReportRequest reportRequest);
        List<OutwardCreditTransfer> OutwardCreditTransferReport_Hist(ReportRequest reportRequest);
        List<InwardCreditTransfer> InwardCreditTransferReport(ReportRequest reportRequest);
        List<InWardPayInvestigation> InwardPayInvestigationReport(ReportRequest reportRequest);
        List<OutwardPayInvestigation> OutwardPayInvestigationReport(ReportRequest reportRequest);
        List<InwardReturn> InwardReturnReport(ReportRequest reportRequest);
        List<OutwardReturn> OutwardReturnReport(ReportRequest reportRequest);
        List<InwardReversal> InwardReversalReport(ReportRequest reportRequest);
        List<OutwardReversal> OutwardReversalReport(ReportRequest reportRequest);
        OutwardBatchCreditTransferReport OutwardBatchCreditTransferReport(ReportRequest reportRequest);
        InwardBatchCreditTransferReport InwardBatchCreditTransferReport(ReportRequest reportRequest);
        OutwardBatchPaymentReturnReport OutwardBatchPaymentReturnReport(ReportRequest reportRequest);
        InwardBatchPaymentReturnReport InwardBatchPaymentReturnReport(ReportRequest reportRequest);
        List<Pacs008SuccessfulReport> Pacs008SuccessfulReport(ReportRequest reportRequest);
        List<UserListReportDetail> GetUserDetails(ReportRequest reportRequest);
        List<UserLoginHistory> GetInvalidLoginLogoutHistory(ReportRequest reportRequest);
        List<AuditLogHistoryDetails> GetAuditLogHistoryDetails(ReportRequest reportRequest);
        List<Rolemanagementreport> GetRolemanagementtails(ReportRequest reportRequest);
        List<UserActivityLogreport> GetUserActivityLogdetails(ReportRequest reportRequest);
        PAC002AcceptRejectReport PAC002AcceptRejectReport(ReportRequest reportRequest);
        List<UserAccessReport> GetUserAccessdetails(ReportRequest reportRequest);      
        List<BankToCustomerAccount> BankToCustomerAccountReport(ReportRequest reportRequest);
        
        BankToCustomerStatementReport BankToCustomerStatementReport(ReportRequest reportRequest);
        List<Email> EmailReport(ReportRequest reportRequest);
        List<DailyReconciliations> DailyReconciliationsReport(ReportRequest reportRequest);
        List<DailyReconciliations> GetNewDailyReconciliationsReport(ReportRequest reportRequest);
        List<CBReconciliationsReport> GetNewCBReconciliationsReport(ReportRequest reportRequest);
        List<ChannelTransactionReport> GetChannelTransactionReport(ReportRequest reportRequest);
        List<PaymentListReports> GetPaymentListReport(ReportRequest reportRequest);
        List<AccountListReport> GetAccountListReport(ReportRequest reportRequest);
        List<UserPropertiesReport> GetUserPropertiesReport(ReportRequest reportRequest);
        List<DashBoardReportModel> GetDashBoardReport(ReportRequest reportRequest);
        List<PaymentStatusReportModel> GetPaymentStatusReport(ReportRequest reportRequest);
        List<ParticipantSubscriptionReportModel> GetParticipansubscription_Report(ReportRequest reportRequest);
        List<BatchFileStatusReport> GetBatchFileStatusReport(ReportRequest reportRequest);
        List<CustomerOnboardingReportModel> CustomerOnboardingReport(ReportRequest reportRequest);
        CprEodReport CprEodReport(ReportRequest reportRequest);
        List<Admin004Report> Admin004Report(ReportRequest reportRequest);
        List<InvalidData> GetInvalidDataList();
        List<DailyMessageStatus> GetDailyMessageStatusReport(ReportRequest reportRequest);
        List<DailyPaymentStatus> GetDailyPaymentStatusReport(ReportRequest reportRequest);
        List<DailyBatchFileStatus> GetDailyBatchFileStatusReport(ReportRequest reportRequest);
        List<DailyServiceBilling> GetDailyServiceBillingReport(ReportRequest reportRequest);
        List<TrackingReport> TrackingReport(ReportRequest reportRequest);
        RealtimeTatReport RealtimeTatReport(ReportRequest reportRequest);
        List<CBStaticErrorCodesReport> GetCBStaticErrorCodesReport(ReportRequest reportRequest);
    }
}
