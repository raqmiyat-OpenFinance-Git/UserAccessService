using IPP_Connect.Models;
using Microsoft.AspNetCore.Mvc;
using NPSS_Connect.Models;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.Models;
using OpenFinanceWebApi.NLogService;



namespace NPSSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : Controller
    {
        
        private readonly IReports _reports;
        private readonly NLogWebApiService _logger;
        public ReportsController(IReports accountmanager, NLogWebApiService logger)
        {
            _reports = accountmanager;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetOutwardCreditTransferReport")]
        public Task<List<OutwardCreditTransfer>> OutwardCreditTransferReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var OutwardCreditTransferReport = _reports.OutwardCreditTransferReport(reportRequest);
                return OutwardCreditTransferReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        
        [Route("GetInwardCreditTransferReport")]
        public List<InwardCreditTransfer> InwardCreditTransferReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var InwardCreditTransferReport = _reports.InwardCreditTransferReport(reportRequest);
                return InwardCreditTransferReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]

        [Route("GetInwardPayInvestigationReport")]
        public List<InWardPayInvestigation> InwardPayInvestigationReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var InwardPayInvestigationReport = _reports.InwardPayInvestigationReport(reportRequest);
                return InwardPayInvestigationReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
      
        [Route("GetOutwardPayInvestigationReport")]
        public List<OutwardPayInvestigation> OutwardPayInvestigationReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var OutwardPayInvestigationReport = _reports.OutwardPayInvestigationReport(reportRequest);
                return OutwardPayInvestigationReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
      
        [Route("GetInwardReturnReport")]
        public List<InwardReturn> InwardReturnReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var InwardReturnReport = _reports.InwardReturnReport(reportRequest);
                return InwardReturnReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetOutwardReturnReport")]
        public List<OutwardReturn> OutwardReturnReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var OutwardReturnReport = _reports.OutwardReturnReport(reportRequest);
                return OutwardReturnReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        
        [Route("GetInwardReversalReport")]
        public List<InwardReversal> InwardReversalReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var InwardReversalReport = _reports.InwardReversalReport(reportRequest);
                return InwardReversalReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
 
        [Route("GetOutwardReversalReport")]
        public List<OutwardReversal> OutwardReversalReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var OutwardReversalReport = _reports.OutwardReversalReport(reportRequest);
                return OutwardReversalReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetOutwardCreditTransferReportHistory")]
        public List<OutwardCreditTransfer> OutwardCreditTransferReport_Hist([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var OutwardCreditTransferReport_Hist = _reports.OutwardCreditTransferReport_Hist(reportRequest);
                return OutwardCreditTransferReport_Hist;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost] 
        [Route("GetOutwardBatchCreditTransferReport")]
        public OutwardBatchCreditTransferReport OutwardBatchCreditTransferReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var OutwardBatchCreditTransferReport = _reports.OutwardBatchCreditTransferReport(reportRequest);
                return OutwardBatchCreditTransferReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        
        [Route("GetInwardBatchCreditTransferReport")]
        public InwardBatchCreditTransferReport InwardBatchCreditTransferReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var InwardBatchCreditTransferReport = _reports.InwardBatchCreditTransferReport(reportRequest);
                return InwardBatchCreditTransferReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
    
        [Route("RealtimeTatReport")]
        public RealtimeTatReport RealtimeTatReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var OutwardBatchCreditTransferReport = _reports.RealtimeTatReport(reportRequest);
                return OutwardBatchCreditTransferReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
   
        [Route("GetCBStaticErrorCodesReport")]
        public List<CBStaticErrorCodesReport> GetCBStaticErrorCodesReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var OutwardBatchCreditTransferReport = _reports.GetCBStaticErrorCodesReport(reportRequest);
                return OutwardBatchCreditTransferReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetOutwardBatchPaymentReturnReport")]
        public OutwardBatchPaymentReturnReport OutwardBatchPaymentReturnReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var OutwardBatchPaymentReturnReport = _reports.OutwardBatchPaymentReturnReport(reportRequest);
                return OutwardBatchPaymentReturnReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetInwardBatchPaymentReturnReport")]
        public InwardBatchPaymentReturnReport InwardBatchPaymentReturnReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var InwardBatchPaymentReturnReport = _reports.InwardBatchPaymentReturnReport(reportRequest);
                return InwardBatchPaymentReturnReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetPacs008SuccessfulReport")]
        public List<Pacs008SuccessfulReport> Pacs008SuccessfulReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var Pacs008SuccessfulReport = _reports.Pacs008SuccessfulReport(reportRequest);
                return Pacs008SuccessfulReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetUserdetails")]
        public List<UserListReportDetail> GetUserdetails([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var GetUserdetails = _reports.GetUserDetails(reportRequest);
                return GetUserdetails;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetInvalidLoginLogoutHistory")]
        public List<UserLoginHistory> GetInvalidLoginLogoutHistory([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var GetUserdetails = _reports.GetInvalidLoginLogoutHistory(reportRequest);
                return GetUserdetails;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        
        [Route("GetAuditLogHistoryDetails")]
        public List<AuditLogHistoryDetails> GetAuditLogHistoryDetails([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var GetUserdetails = _reports.GetAuditLogHistoryDetails(reportRequest);
                return GetUserdetails;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
   
        [Route("GetRolemanagementreport")]
        public List<Rolemanagementreport> GetRolemanagementtails([FromBody] ReportRequest reportRequest)
        {

            try
            {
                var GetRolemanagementtails = _reports.GetRolemanagementtails(reportRequest);
                return GetRolemanagementtails;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        [Route("GetUserActivityLogdetails")]
        public List<UserActivityLogreport> GetUserActivityLogdetails([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var GetUserActivityLogdetails = _reports.GetUserActivityLogdetails(reportRequest);
                return GetUserActivityLogdetails;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetPAC002AcceptRejectReport")]
        public PAC002AcceptRejectReport PAC002AcceptRejectReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var PAC002AcceptRejectReport = _reports.PAC002AcceptRejectReport(reportRequest);
                return PAC002AcceptRejectReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetUserAccessdetails")]
        public List<UserAccessReport> GetUserAccessdetails([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var GetUserAccessdetails = _reports.GetUserAccessdetails(reportRequest);
                return GetUserAccessdetails;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
       
        [HttpPost]
       
        [Route("BankToCustomerAccountReport")]
        public List<BankToCustomerAccount> BankToCustomerAccountReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var BankToCustomerAccountReport = _reports.BankToCustomerAccountReport(reportRequest);
                return BankToCustomerAccountReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("BankToCustomerStatementReport")]
        public BankToCustomerStatementReport BankToCustomerStatementReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var BankToCustomerStatementReport = _reports.BankToCustomerStatementReport(reportRequest);
                return BankToCustomerStatementReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("EmailReport")]
        public List<Email> EmailReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var EmailReport = _reports.EmailReport(reportRequest);
                return EmailReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetDailyReconciliationsReport")]

        public List<DailyReconciliations> DailyReconciliationsReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var DailyReconciliationsReport = _reports.DailyReconciliationsReport(reportRequest);
                return DailyReconciliationsReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetNewDailyReconciliationsReport")]

        public List<DailyReconciliations> GetNewDailyReconciliationsReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var DailyReconciliationsReport = _reports.GetNewDailyReconciliationsReport(reportRequest);
                return DailyReconciliationsReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetNewCBReconciliationsReport")]
        public List<CBReconciliationsReport> GetNewCBReconciliationsReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var DailyReconciliationsReport = _reports.GetNewCBReconciliationsReport(reportRequest);
                return DailyReconciliationsReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetChannelTransactionReport")]
        public List<ChannelTransactionReport> GetChannelTransactionReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var DailyReconciliationsReport = _reports.GetChannelTransactionReport(reportRequest);
                return DailyReconciliationsReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetPaymentListReport")]
        public List<PaymentListReports> GetPaymentListReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var PaymentListReport = _reports.GetPaymentListReport(reportRequest);
                return PaymentListReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetAccountListReport")]
        public List<AccountListReport> GetAccountListReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var AccountListReport = _reports.GetAccountListReport(reportRequest);
                return AccountListReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetUserPropertiesReport")]
        public List<UserPropertiesReport> GetUserPropertiesReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var UserPropertiesReport = _reports.GetUserPropertiesReport(reportRequest);
                return UserPropertiesReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetDashBoardReport")]
        public List<DashBoardReportModel> GetDashBoardReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var DashBoardReport = _reports.GetDashBoardReport(reportRequest);
                return DashBoardReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetPaymentStatusReport")]
        public List<PaymentStatusReportModel> GetPaymentStatusReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var PaymentStatusReportModel = _reports.GetPaymentStatusReport(reportRequest);
                return PaymentStatusReportModel;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetParticipansubscription_Report")]
        public List<ParticipantSubscriptionReportModel> GetParticipansubscription_Report([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var ParticipantSubscriptionReportModel = _reports.GetParticipansubscription_Report(reportRequest);
                return ParticipantSubscriptionReportModel;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
       
        [Route("GetBatchFileStatusReport")]
        public List<BatchFileStatusReport> GetBatchFileStatusReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var BatchFileStatusReport = _reports.GetBatchFileStatusReport(reportRequest);
                return BatchFileStatusReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        
        

        [HttpPost]
       
        [Route("CustomerOnboardingReport")]
        public List<CustomerOnboardingReportModel> CustomerOnboardingReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var CustomerOnboardingReport = _reports.CustomerOnboardingReport(reportRequest);
                return CustomerOnboardingReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpPost]
       
        [Route("CprEodReport")]
        public CprEodReport CprEodReport([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var CprEodReport = _reports.CprEodReport(reportRequest);
                return CprEodReport;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "CprEodReport");
                throw;
            }

        }
        [HttpPost]
       
        [Route("GetAdmin004Report")]
        public List<Admin004Report> Admin004Report([FromBody] ReportRequest reportRequest)
        {
            try
            {
                var admin004Report = _reports.Admin004Report(reportRequest);
                return admin004Report;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "CprEodReport");
                throw;
            }

        }

        [HttpGet]
       
        [Route("GetInvalidDataList")]
        public List<InvalidData> GetInvalidDataList()
        {
            List<InvalidData> InvalidData = new List<InvalidData>();
            try
            {
                InvalidData = _reports.GetInvalidDataList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return InvalidData;
        }

        [HttpPost]
       
        [Route("GetDailyMessageStatusReport")]
        public List<DailyMessageStatus> GetDailyMessageStatusRepor([FromBody] ReportRequest reportRequest)
        {
            List<DailyMessageStatus> dailyMessageStatus = new List<DailyMessageStatus>();
            try
            {
                dailyMessageStatus = _reports.GetDailyMessageStatusReport(reportRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return dailyMessageStatus;
        }

        [HttpPost]
       
        [Route("GetDailyPaymentStatusReport")]
        public List<DailyPaymentStatus> GetDailyPaymentStatusReport([FromBody] ReportRequest reportRequest)
        {
            List<DailyPaymentStatus> dailyMessageStatus = new List<DailyPaymentStatus>();
            try
            {
                dailyMessageStatus = _reports.GetDailyPaymentStatusReport(reportRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return dailyMessageStatus;
        }

        [HttpPost]
       
        [Route("GetDailyBatchFileStatusReport")]
        public List<DailyBatchFileStatus> GetDailyBatchFileStatusReport([FromBody] ReportRequest reportRequest)
        {
            List<DailyBatchFileStatus> dailyBatchFileStatuse = new List<DailyBatchFileStatus>();
            try
            {
                dailyBatchFileStatuse = _reports.GetDailyBatchFileStatusReport(reportRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return dailyBatchFileStatuse;
        }

        [HttpPost]
       
        [Route("GetDailyServiceBillingReport")]
        public List<DailyServiceBilling> GetDailyServiceBillingReport([FromBody] ReportRequest reportRequest)
        {
            List<DailyServiceBilling> dailyServiceBilling = new List<DailyServiceBilling>();
            try
            {
                dailyServiceBilling = _reports.GetDailyServiceBillingReport(reportRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return dailyServiceBilling;
        }

        [HttpPost]
       
        [Route("TrackingReport")]
        public List<TrackingReport> TrackingReport([FromBody] ReportRequest reportRequest)
        {
            var TrackingReport = _reports.TrackingReport(reportRequest);
            return TrackingReport;
        }
    }
}
