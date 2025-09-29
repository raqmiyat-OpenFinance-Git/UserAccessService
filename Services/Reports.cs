using Dapper;
using IPP_Connect.Models;
using Newtonsoft.Json;
using NPSS_Connect.Models;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.Models;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.SqlClient;

namespace OpenFinanceWebApi.Services
{
    public class Reports(NLogWebApiService logger) : IReports
    {
        public async Task<List<OutwardCreditTransfer>> OutwardCreditTransferReport(ReportRequest reportRequest)
        {
            logger.Debug($"OutwardCreditTransferReport called with ReportRequest: {JsonConvert.SerializeObject(reportRequest)}");

            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Beneficiary_Bank", reportRequest.BeneficiaryBank, DbType.String);
                dp_Param.Add("Cus_IBAN", reportRequest.CusIban, DbType.String);
                dp_Param.Add("creditorIban", reportRequest.creditorIban, DbType.String);
                dp_Param.Add("Cat_PurposeCode", reportRequest.CatPurposeCode == "ALL" ? "0" : reportRequest.CatPurposeCode, DbType.String);
                dp_Param.Add("Status", reportRequest.Status == "ALL" ? "0" : reportRequest.Status, DbType.String);

                logger.Debug($"DynamicParameters created: {JsonConvert.SerializeObject(dp_Param)}");

                using var db = new SqlConnection(ConfigManager.getDBConnection());
                logger.Debug($"Database connection established: {db.ConnectionString}");

                var result = await db.QueryAsync<OutwardCreditTransfer>("USP_GetOutwardCreditTransferReport", dp_Param, commandType: commandType, commandTimeout: 1200);
                logger.Debug($"Stored procedure executed. Result: {JsonConvert.SerializeObject(result)}");

                return result.ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error executing USP_GetOutwardCreditTransferReport");
                throw;
            }
        }

        public List<OutwardCreditTransfer> OutwardCreditTransferReport_Hist(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Beneficiary_Bank", reportRequest.BeneficiaryBank, DbType.String);
                dp_Param.Add("Cus_IBAN", reportRequest.CusIban, DbType.String);
                dp_Param.Add("Cat_PurposeCode", reportRequest.CatPurposeCode, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<OutwardCreditTransfer>("USP_GetOutwardCreditTransferReport_History", dp_Param, commandType: commandType);
                return (List<OutwardCreditTransfer>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetOutwardCreditTransferReport_History");
                throw;
            }

        }

        public List<InwardCreditTransfer> InwardCreditTransferReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Beneficiary_Bank", reportRequest.BeneficiaryBank, DbType.String);
                dp_Param.Add("debtorIban", reportRequest.debtorIban, DbType.String);
                dp_Param.Add("creditorIban", reportRequest.creditorIban, DbType.String);
                dp_Param.Add("Cat_PurposeCode", reportRequest.CatPurposeCode == "ALL" ? "0" : reportRequest.CatPurposeCode, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<InwardCreditTransfer>("USP_GetInwardCreditTransferReport", dp_Param, commandType: commandType);
                return (List<InwardCreditTransfer>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetInwardCreditTransferReport");
                throw;
            }

        }

        public List<InWardPayInvestigation> InwardPayInvestigationReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("debtorIban", reportRequest.debtorIban, DbType.String);
                dp_Param.Add("Beneficiary_Bank", reportRequest.BeneficiaryBank, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<InWardPayInvestigation>("USP_GetInwardPayInvestigationReport", dp_Param, commandType: commandType);
                return (List<InWardPayInvestigation>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetInwardPayInvestigationReport");
                throw;
            }

        }

        public List<OutwardPayInvestigation> OutwardPayInvestigationReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("creditorIban", reportRequest.creditorIban, DbType.String);
                dp_Param.Add("Beneficiary_Bank", reportRequest.BeneficiaryBank, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<OutwardPayInvestigation>("USP_GetOutwardPayInvestigationReport", dp_Param, commandType: commandType);
                return (List<OutwardPayInvestigation>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetOutwardPayInvestigationReport");
                throw;
            }

        }

        public List<InwardReturn> InwardReturnReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Beneficiary_Bank", reportRequest.BeneficiaryBank, DbType.String);
                dp_Param.Add("Cus_IBAN", reportRequest.CusIban, DbType.String);
                dp_Param.Add("Cat_PurposeCode", reportRequest.CatPurposeCode == "ALL" ? "0" : reportRequest.CatPurposeCode, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<InwardReturn>("USP_GetInwardReturnReport", dp_Param, commandType: commandType);
                return (List<InwardReturn>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetInwardReturnReport");
                throw;
            }

        }

        public List<OutwardReturn> OutwardReturnReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Beneficiary_Bank", reportRequest.BeneficiaryBank, DbType.String);
                dp_Param.Add("Cus_IBAN", reportRequest.CusIban, DbType.String);
                dp_Param.Add("Cat_PurposeCode", reportRequest.CatPurposeCode == "ALL" ? "0" : reportRequest.CatPurposeCode, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<OutwardReturn>("USP_GetOutwardReturnReport", dp_Param, commandType: commandType);
                return (List<OutwardReturn>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetOutwardReturnReport");
                throw;
            }

        }

        public List<InwardReversal> InwardReversalReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Beneficiary_Bank", reportRequest.BeneficiaryBank, DbType.String);
                dp_Param.Add("Cus_IBAN", reportRequest.CusIban, DbType.String);
                dp_Param.Add("Cat_PurposeCode", reportRequest.CatPurposeCode == "ALL" ? "0" : reportRequest.CatPurposeCode, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<InwardReversal>("USP_GetInwardReversalReport", dp_Param, commandType: commandType);
                return (List<InwardReversal>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetInwardReversalReport");
                throw;
            }

        }

        public List<OutwardReversal> OutwardReversalReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Beneficiary_Bank", reportRequest.BeneficiaryBank, DbType.String);
                dp_Param.Add("Cus_IBAN", reportRequest.CusIban, DbType.String);
                dp_Param.Add("Cat_PurposeCode", reportRequest.CatPurposeCode == "ALL" ? "0" : reportRequest.CatPurposeCode, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<OutwardReversal>("USP_GetOutwardReversalReport", dp_Param, commandType: commandType);
                return (List<OutwardReversal>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetOutwardReversalReport");
                throw;
            }

        }

        public OutwardBatchCreditTransferReport OutwardBatchCreditTransferReport(ReportRequest reportRequest)
        {
            var oct = new OutwardBatchCreditTransferReport();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Debtor_IBAN", reportRequest.debtorIban, DbType.String);
                dp_Param.Add("FileName", reportRequest.FileName, DbType.String);
                dp_Param.Add("reportType", reportRequest.reportType, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                if (reportRequest.reportType == "1" || reportRequest.reportType == "Summary")
                {
                    var result = db.Query<OutwardBatchCreditTransferSummary>("ipp_sp_Owd_BatchCreditTransfer_Report", dp_Param, commandType: commandType);
                    oct.OutwardBatchCredit_TransferSummary = (List<OutwardBatchCreditTransferSummary>)result;
                }
                else if (reportRequest.reportType == "2" || reportRequest.reportType == "Detail")
                {
                    var result = db.Query<OutwardBatchCreditTransferDetail>("ipp_sp_Owd_BatchCreditTransfer_Report", dp_Param, commandType: commandType);
                    oct.outwardBatchCreditTransferDetail = (List<OutwardBatchCreditTransferDetail>)result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_Owd_BatchCreditTransfer_Report");
            }
            return oct;
        }

        public InwardBatchCreditTransferReport InwardBatchCreditTransferReport(ReportRequest reportRequest)
        {
            var oct = new InwardBatchCreditTransferReport();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Debtor_IBAN", reportRequest.debtorIban, DbType.String);
                dp_Param.Add("Creditor_IBAN", reportRequest.creditorIban, DbType.String);
                dp_Param.Add("FileName", reportRequest.FileName, DbType.String);
                dp_Param.Add("reportType", reportRequest.reportType, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                if (reportRequest.reportType == "1" || reportRequest.reportType == "Summary")
                {
                    var result = db.Query<InwardBatchCreditTransferSummary>("ipp_sp_Iwd_BatchCreditTransfer_Report", dp_Param, commandType: commandType);
                    oct.inwardBatchCreditTransferSummary = (List<InwardBatchCreditTransferSummary>)result;
                }
                else if (reportRequest.reportType == "2" || reportRequest.reportType == "Detail")
                {
                    var result = db.Query<InwardBatchCreditTransferDetail>("ipp_sp_Iwd_BatchCreditTransfer_Report", dp_Param, commandType: commandType);
                    oct.inwardBatchCreditTransferDetail = (List<InwardBatchCreditTransferDetail>)result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_Iwd_BatchCreditTransfer_Report");
            }
            return oct;
        }

        public OutwardBatchPaymentReturnReport OutwardBatchPaymentReturnReport(ReportRequest reportRequest)
        {
            var oct = new OutwardBatchPaymentReturnReport();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("Original_RefNbr", reportRequest.OriginalRefNO, DbType.String);
                dp_Param.Add("Return_RefNbr", reportRequest.ReturnRefNO, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("DebtorIBAN", reportRequest.debtorIban, DbType.String);
                dp_Param.Add("CreditorIBAN", reportRequest.creditorIban, DbType.String);
                dp_Param.Add("FileName", reportRequest.FileName, DbType.String);
                dp_Param.Add("ReportType", reportRequest.reportType, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                if (reportRequest.reportType == "1" || reportRequest.reportType == "Summary")
                {
                    var result = db.Query<OutwardBatchPaymentTransferSummary>("ipp_sp_OutwardBatchPaymentReturn_Report", dp_Param, commandType: commandType);
                    oct.outwardBatchPaymentTransferSummary = (List<OutwardBatchPaymentTransferSummary>)result;
                }
                else if (reportRequest.reportType == "2" || reportRequest.reportType == "Detail")
                {
                    var result = db.Query<OutwardBatchPaymentTransferDetail>("ipp_sp_OutwardBatchPaymentReturn_Report", dp_Param, commandType: commandType);
                    oct.outwardBatchPaymentTransferDetail = (List<OutwardBatchPaymentTransferDetail>)result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_OutwardBatchPaymentReturn_Report");
            }
            return oct;
        }

        public InwardBatchPaymentReturnReport InwardBatchPaymentReturnReport(ReportRequest reportRequest)
        {
            var oct = new InwardBatchPaymentReturnReport();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("Original_RefNbr", reportRequest.OriginalRefNO, DbType.String);
                dp_Param.Add("Return_RefNbr", reportRequest.ReturnRefNO, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("DebtorIBAN", reportRequest.debtorIban, DbType.String);
                dp_Param.Add("FileName", reportRequest.FileName, DbType.String);
                dp_Param.Add("ReportType", reportRequest.reportType, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                if (reportRequest.reportType == "1" || reportRequest.reportType == "Summary")
                {
                    var result = db.Query<InwardBatchPaymentTransferSummary>("ipp_sp_InwardBatchPaymentReturn_Report", dp_Param, commandType: commandType);
                    oct.inwardBatchPaymentTransferSummary = (List<InwardBatchPaymentTransferSummary>)result;
                }
                else if (reportRequest.reportType == "2" || reportRequest.reportType == "Detail")
                {
                    var result = db.Query<InwardBatchPaymentTransferDetail>("ipp_sp_InwardBatchPaymentReturn_Report", dp_Param, commandType: commandType);
                    oct.inwardBatchPaymentTransferDetail = (List<InwardBatchPaymentTransferDetail>)result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_InwardBatchPaymentReturn_Report");
            }
            return oct;
        }

        public List<Pacs008SuccessfulReport> Pacs008SuccessfulReport(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Cus_IBAN", reportRequest.CusIban, DbType.String);
                dp_Param.Add("Cat_PurposeCode", reportRequest.CatPurposeCode, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<Pacs008SuccessfulReport>("USP_Getpacs008successfulreport", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_Getpacs008successfulreport");
            }
            return (List<Pacs008SuccessfulReport>)result;
        }

        public List<UserListReportDetail> GetUserDetails(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("UserID", reportRequest.UserID, DbType.String);
                dp_Param.Add("Username", reportRequest.Username, DbType.String);
                dp_Param.Add("EmailId", reportRequest.EmailId, DbType.String);
                dp_Param.Add("MobileNo", reportRequest.MobileNo, DbType.String);
                using var db = new SqlConnection(ConfigManager.getFrameworkDBConnection());
                result = db.Query<UserListReportDetail>("USP_Get_UserDetails_Report", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_Get_UserDetails_Report");
            }
            return (List<UserListReportDetail>)result;
        }

        public List<UserLoginHistory> GetInvalidLoginLogoutHistory(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("UserID", reportRequest.UserID, DbType.String);

                using var db = new SqlConnection(ConfigManager.getAuditLogConnection());
                result = db.Query<UserLoginHistory>("frm_sp_rpt_Invalid_Login_Logout_History", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "frm_sp_rpt_Invalid_Login_Logout_History");
            }
            return (List<UserLoginHistory>)result;
        }

        public List<AuditLogHistoryDetails> GetAuditLogHistoryDetails(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("UserID", reportRequest.UserID, DbType.String);

                using var db = new SqlConnection(ConfigManager.getAuditLogConnection());
                result = db.Query<AuditLogHistoryDetails>("frm_sp_rpt_Audit_Log_History", dp_Param, commandType: commandType).ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "frm_sp_rpt_Audit_Log_History");
            }
            return (List<AuditLogHistoryDetails>)result;
        }

        public List<Rolemanagementreport> GetRolemanagementtails(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("Roleid", reportRequest.RoleID, DbType.String);
                dp_Param.Add("Rolename", reportRequest.RoleName, DbType.String);
                dp_Param.Add("RoleDesc", reportRequest.RoleDescription, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<Rolemanagementreport>("USP_Get_RoleDetails_Report", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_Get_RoleDetails_Report");
            }
            return (List<Rolemanagementreport>)result;
        }

        public List<UserActivityLogreport> GetUserActivityLogdetails(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("user", reportRequest.UserID, DbType.String);
                dp_Param.Add("transaction_Name", reportRequest.Transactionname, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<UserActivityLogreport>("USP_Get_UserActivityLog_Report", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_Get_UserActivityLog_Report");
            }
            return (List<UserActivityLogreport>)result;
        }

        public PAC002AcceptRejectReport PAC002AcceptRejectReport(ReportRequest reportRequest)
        {
            var oct = new PAC002AcceptRejectReport();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("FileName", reportRequest.FileName, DbType.String);
                dp_Param.Add("Transation_Of_Process_Type", reportRequest.Transactionprocesstype, DbType.String);
                dp_Param.Add("Transaction_Type", reportRequest.Transactiontype, DbType.String);
                dp_Param.Add("ReportType", reportRequest.reportType, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                if (reportRequest.reportType == "1" || reportRequest.reportType == "Summary")
                {
                    var result = db.Query<PAC002AcceptRejectReportSummary>("ipp_sp_Batch_Pacs002_ACCP_RJCT_Report", dp_Param, commandType: commandType);
                    oct.pac002AcceptRejectReportSummary = (List<PAC002AcceptRejectReportSummary>)result;
                }
                else if (reportRequest.reportType == "2" || reportRequest.reportType == "Detail")
                {
                    var result = db.Query<PAC002AcceptRejectReportDetail>("ipp_sp_Batch_Pacs002_ACCP_RJCT_Report", dp_Param, commandType: commandType);
                    oct.pac002AcceptRejectReportDetail = (List<PAC002AcceptRejectReportDetail>)result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_Batch_Pacs002_ACCP_RJCT_Report");
            }
            return oct;
        }

        public List<UserAccessReport> GetUserAccessdetails(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("Userid", reportRequest.UserID, DbType.String);
                using var db = new SqlConnection(ConfigManager.getFrameworkDBConnection());
                result = db.Query<UserAccessReport>("Frm_sp_transaction_Access_report", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Frm_sp_transaction_Access_report");
            }
            return (List<UserAccessReport>)result;
        }

      

        public List<BankToCustomerAccount> BankToCustomerAccountReport(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Iban", reportRequest.IBAN, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<BankToCustomerAccount>("USP_ipp_GetBankToCustomerAccountReport", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_ipp_GetBankToCustomerAccountReport");
            }
            return (List<BankToCustomerAccount>)result;
        }

       
        public BankToCustomerStatementReport BankToCustomerStatementReport(ReportRequest reportRequest)
        {
            var oct = new BankToCustomerStatementReport();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("BeneficiaryBankName", reportRequest.BeneficiaryBankName, DbType.String);
                dp_Param.Add("reportType", reportRequest.reportType, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                if (reportRequest.reportType == "1" || reportRequest.reportType == "Summary")
                {
                    var result = db.Query<BankToCustomerStatementSummary>("USP_ipp_GetBankToCustomerStatementReport", dp_Param, commandType: commandType);
                    oct.bankToCustomerStatementSummary = (List<BankToCustomerStatementSummary>)result;
                }
                else if (reportRequest.reportType == "2" || reportRequest.reportType == "Detail")
                {
                    var result = db.Query<BankToCustomerStatement>("USP_ipp_GetBankToCustomerStatementReport", dp_Param, commandType: commandType);
                    oct.BankToCustomerStatementDetail = (List<BankToCustomerStatement>)result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_ipp_GetBankToCustomerStatementReport");

            }
            return oct;
        }

        public List<Email> EmailReport(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("RefNo", reportRequest.RefNo, DbType.String);
                dp_Param.Add("mail_module", reportRequest.PaymentType, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<Email>("USP_ipp_GetEmailReport", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_ipp_GetEmailReport");
            }
            return (List<Email>)result;
        }

        public List<DailyReconciliations> DailyReconciliationsReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("FromSettelementDate", reportRequest.FromDate, DbType.String);
                dp_Param.Add("ToSettelementDate", reportRequest.ToDate, DbType.String);
                dp_Param.Add("PacsID", reportRequest.PacsID, DbType.String);
                dp_Param.Add("Module", reportRequest.Module, DbType.String);
                dp_Param.Add("Payment", reportRequest.Payment, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Ismatched", reportRequest.IsMatched, DbType.String);
                dp_Param.Add("EndToEndID", reportRequest.endtoendid, DbType.String);
                dp_Param.Add("BenificiaryBankName", reportRequest.BeneficiaryBankName, DbType.String);

                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<DailyReconciliations>("USP_GetDailyReconciliationsReport", dp_Param, commandType: commandType);
                return (List<DailyReconciliations>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetDailyReconciliationsReport");
                throw;
            }

        }

        public List<DailyReconciliations> GetNewDailyReconciliationsReport(ReportRequest reportRequest)
        {
            var result = new List<DailyReconciliations>();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("fromDate", Convert.ToDateTime(reportRequest.FromDate).ToString("dd-MM-yyyy"), DbType.String);
                dp_Param.Add("toDate", Convert.ToDateTime(reportRequest.ToDate).ToString("dd-MM-yyyy"), DbType.String);
                dp_Param.Add("reportType", reportRequest.Module, DbType.String);

                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<DailyReconciliations>("ipp_sp_rpt_Reconciliation", dp_Param, commandType: commandType).ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_rpt_Reconciliation");
            }
            return result;

        }

        public List<CBReconciliationsReport> GetNewCBReconciliationsReport(ReportRequest reportRequest)
        {
            var result = new List<CBReconciliationsReport>();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("fromDate", Convert.ToDateTime(reportRequest.FromDate).ToString("dd-MM-yyyy"), DbType.String);
                dp_Param.Add("toDate", Convert.ToDateTime(reportRequest.ToDate).ToString("dd-MM-yyyy"), DbType.String);
                dp_Param.Add("transactionRefNbr", reportRequest.TransactionID, DbType.String);

                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<CBReconciliationsReport>("ipp_sp_rpt_CB_Reconciliation", dp_Param, commandType: commandType).ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_rpt_CB_Reconciliation");
            }
            return result;

        }

        public List<ChannelTransactionReport> GetChannelTransactionReport(ReportRequest reportRequest)
        {
            var result = new List<ChannelTransactionReport>();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("fromDate", Convert.ToDateTime(reportRequest.FromDate).ToString("dd-MM-yyyy"), DbType.String);
                dp_Param.Add("toDate", Convert.ToDateTime(reportRequest.ToDate).ToString("dd-MM-yyyy"), DbType.String);
                dp_Param.Add("transactionRefNbr", reportRequest.TransactionID, DbType.String);

                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<ChannelTransactionReport>("ipp_sp_rpt_Channel_Transaction_Report", dp_Param, commandType: commandType).ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_rpt_Channel_Transaction_Report");
            }
            return result;

        }

        public List<PaymentListReports> GetPaymentListReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("Settlement_Date_From", reportRequest.SettlementDateFrom, DbType.String);
                dp_Param.Add("Settlement_Date_to", reportRequest.SettlementDateTo, DbType.String);
                dp_Param.Add("Date_From", reportRequest.FromDate, DbType.String);
                dp_Param.Add("Date_to", reportRequest.ToDate, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("Currency", reportRequest.Currency, DbType.String);
                dp_Param.Add("SenderReference", reportRequest.SenderReference, DbType.String);
                dp_Param.Add("PaymentType", reportRequest.PaymentType, DbType.String);
                dp_Param.Add("SystemReference", reportRequest.SystemReference, DbType.String);
                dp_Param.Add("Payer", reportRequest.Payer, DbType.String);
                dp_Param.Add("BatchSystemReference", reportRequest.BatchSystemReference, DbType.String);
                dp_Param.Add("Beneficiary", reportRequest.Beneficiary, DbType.String);
                dp_Param.Add("MessageReference", reportRequest.MessageReference, DbType.String);
                dp_Param.Add("Source", reportRequest.Source, DbType.String);
                dp_Param.Add("SourceEH", reportRequest.Source, DbType.String);
                dp_Param.Add("Status", reportRequest.Status, DbType.String);
                dp_Param.Add("SettlementCycle", reportRequest.SettlementCycle, DbType.String);
                dp_Param.Add("SettlementCycle", reportRequest.SettlementCycle, DbType.String);
                dp_Param.Add("OriginatorReference", reportRequest.OriginatorReference, DbType.String);
                dp_Param.Add("Messagetype", reportRequest.Messagetype, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<PaymentListReports>("USP_GetPaymentListReport", dp_Param, commandType: commandType);
                return (List<PaymentListReports>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetPaymentListReport");
                throw;
            }

        }

        public List<AccountListReport> GetAccountListReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("Source", reportRequest.Source, DbType.String);
                dp_Param.Add("AccountHolder", reportRequest.AccountHolder, DbType.String);
                dp_Param.Add("Currency", reportRequest.Currency, DbType.String);
                dp_Param.Add("status", reportRequest.Status, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<AccountListReport>("USP_GetAccountListReport", dp_Param, commandType: commandType);
                return (List<AccountListReport>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetAccountListReport");
                throw;
            }

        }

        public List<UserPropertiesReport> GetUserPropertiesReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("Participant", reportRequest.Participant, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<AccountListReport>("USP_GetUserPropertiesReport", dp_Param, commandType: commandType);
                return (List<UserPropertiesReport>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetUserPropertiesReport");
                throw;
            }

        }

        public List<DashBoardReportModel> GetDashBoardReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("Product", reportRequest.Product, DbType.String);
                dp_Param.Add("Date_From", reportRequest.FromDate, DbType.String);
                dp_Param.Add("Date_to", reportRequest.ToDate, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<DashBoardReportModel>("USP_GetDashBoardReport", dp_Param, commandType: commandType);
                return (List<DashBoardReportModel>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetDashBoardReport");
                throw;
            }

        }

        public List<PaymentStatusReportModel> GetPaymentStatusReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("Currency", reportRequest.Currency, DbType.String);
                dp_Param.Add("Date_From", reportRequest.FromDate, DbType.String);
                dp_Param.Add("Date_to", reportRequest.ToDate, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<PaymentStatusReportModel>("USP_GetPaymentStatusReport", dp_Param, commandType: commandType);
                return (List<PaymentStatusReportModel>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetPaymentStatusReport");
                throw;
            }

        }

        public List<ParticipantSubscriptionReportModel> GetParticipansubscription_Report(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<ParticipantSubscriptionReportModel>("USP_GetParticipantSubscriptionReport", dp_Param, commandType: commandType);
                return (List<ParticipantSubscriptionReportModel>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetParticipantSubscriptionReport");
                throw;
            }

        }

        public List<BatchFileStatusReport> GetBatchFileStatusReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("FromDate", reportRequest.FromDate, DbType.String);
                dp_Param.Add("ToDate", reportRequest.ToDate, DbType.String);
                dp_Param.Add("Currency", reportRequest.Currency, DbType.String);
                dp_Param.Add("Participant", reportRequest.Participant, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<BatchFileStatusReport>("USP_GetBatchFileStatusReport", dp_Param, commandType: commandType);
                return (List<BatchFileStatusReport>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetBatchFileStatusReport");
                throw;
            }

        }

        public List<CustomerOnboardingReportModel> CustomerOnboardingReport(ReportRequest reportRequest)
        {
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("Customer_BankUserId", string.IsNullOrEmpty(reportRequest.BankUserId) ? null : reportRequest.BankUserId, DbType.String);
                dp_Param.Add("Customer_OperationType", reportRequest.OperationType == "ALL" ? "0" : reportRequest.OperationType, DbType.String);
                dp_Param.Add("Customer_Name", string.IsNullOrEmpty(reportRequest.Name) ? null : reportRequest.Name, DbType.String);
                dp_Param.Add("Customer_Surname", string.IsNullOrEmpty(reportRequest.Customer_Surname) ? null : reportRequest.Customer_Surname, DbType.String);
                dp_Param.Add("Custome_Mobile", string.IsNullOrEmpty(reportRequest.MobileNo) ? null : reportRequest.MobileNo, DbType.String);
                dp_Param.Add("Custome_Status", string.IsNullOrEmpty(reportRequest.Status) ? null : reportRequest.Status, DbType.String);
                dp_Param.Add("Customer_IBAN", string.IsNullOrEmpty(reportRequest.CusIban) ? null : reportRequest.CusIban, DbType.String);
                dp_Param.Add("Customer_Currency", string.IsNullOrEmpty(reportRequest.Customer_Currency) ? null : reportRequest.Customer_Currency, DbType.String);
                dp_Param.Add("Customer_Type", string.IsNullOrEmpty(reportRequest.CustomerType) ? null : reportRequest.CustomerType, DbType.String);
                dp_Param.Add("Customer_Value", string.IsNullOrEmpty(reportRequest.CustomerValue) ? null : reportRequest.CustomerValue, DbType.String);
                dp_Param.Add("Is_Deleted", string.IsNullOrEmpty(reportRequest.Is_Deleted) ? null : reportRequest.Is_Deleted, DbType.String);
                dp_Param.Add("IS_ACTIVE", string.IsNullOrEmpty(reportRequest.is_active) ? null : reportRequest.is_active, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                var result = db.Query<CustomerOnboardingReportModel>("GetCustomerDataReports", dp_Param, commandType: commandType);
                return (List<CustomerOnboardingReportModel>)result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "GetCustomerDataReports");
                throw;
            }
        }

      

        public CprEodReport CprEodReport(ReportRequest reportRequest)
        {
            var oct = new CprEodReport();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date", reportRequest.ToDate, DbType.String);
                dp_Param.Add("Amount", reportRequest.Amount, DbType.String);
                dp_Param.Add("EndtoEndId", reportRequest.endtoendid, DbType.String);
                dp_Param.Add("reportType", reportRequest.reportType, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                if (reportRequest.reportType == "1" || reportRequest.reportType == "Summary")
                {
                    var result = db.Query<CprEodReportSummary>("USP_GetCprEodReport", dp_Param, commandType: commandType);
                    oct.cprEodReportSummary = (List<CprEodReportSummary>)result;
                }
                else if (reportRequest.reportType == "2" || reportRequest.reportType == "Detail")
                {
                    var result = db.Query<CprEodReportDetail>("USP_GetCprEodReport", dp_Param, commandType: commandType);
                    oct.cprEodReportDetail = (List<CprEodReportDetail>)result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetCprEodReport");

            }
            return oct;

        }
        public List<Admin004Report> Admin004Report(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("From_Date", reportRequest.FromDate, DbType.String);
                dp_Param.Add("To_Date ", reportRequest.ToDate, DbType.String);
                dp_Param.Add("BeneficiaryBankName ", reportRequest.BeneficiaryBankName, DbType.String);

                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<Admin004Report>("ipp_sp_getAdmin004_Report", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_getAdmin004_Report");
            }
            return (List<Admin004Report>)result;
        }

        public List<InvalidData> GetInvalidDataList()
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<InvalidData>("USP_GetInvalidDataReport", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetInvalidDataReport");
            }
            return (List<InvalidData>)result;
        }

        public List<DailyPaymentStatus> GetDailyPaymentStatusReport(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("FromDate", reportRequest.FromDate, DbType.String);
                dp_Param.Add("ToDate", reportRequest.ToDate, DbType.String);
                dp_Param.Add("TransactionID", reportRequest.TransactionID, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<DailyPaymentStatus>("USP_GetDailyPaymentStatusReport", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetDailyPaymentStatusReport");
            }
            return (List<DailyPaymentStatus>)result;
        }

        public List<DailyMessageStatus> GetDailyMessageStatusReport(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("FromDate", reportRequest.FromDate, DbType.String);
                dp_Param.Add("ToDate", reportRequest.ToDate, DbType.String);
                dp_Param.Add("TransactionID", reportRequest.TransactionID, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<DailyMessageStatus>("USP_GetDailyMessageStatusReport", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_GetDailyMessageStatusReport");
            }
            return (List<DailyMessageStatus>)result;
        }

        public List<DailyServiceBilling> GetDailyServiceBillingReport(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("FromDate", reportRequest.FromDate, DbType.String);
                dp_Param.Add("ToDate", reportRequest.ToDate, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<DailyServiceBilling>("USP_DailyServiceProcessingReport", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_DailyServiceProcessingReport");
            }
            return (List<DailyServiceBilling>)result;
        }

        public List<DailyBatchFileStatus> GetDailyBatchFileStatusReport(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("FromDate", reportRequest.FromDate, DbType.String);
                dp_Param.Add("ToDate", reportRequest.ToDate, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<DailyBatchFileStatus>("USP_DailyBatchProcessingReport", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "USP_DailyBatchProcessingReport");
            }
            return (List<DailyBatchFileStatus>)result;
        }
        public List<TrackingReport> TrackingReport(ReportRequest reportRequest)
        {
            var result = new object();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("fromDate", reportRequest.FromDate, DbType.String);
                dp_Param.Add("toDate", reportRequest.ToDate, DbType.String);
                dp_Param.Add("endtoend", reportRequest.endtoendid, DbType.String);
                dp_Param.Add("Iban", reportRequest.IBAN, DbType.String);
                dp_Param.Add("transtype", reportRequest.Transactiontype, DbType.String);
                dp_Param.Add("Module", reportRequest.Module, DbType.String);


                using IDbConnection db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<TrackingReport>("ipp_sp_get_tracking_report", dp_Param, commandType: commandType);
            }
            catch (Exception ex)
            {
                logger.Error("Error Occured in TrackingReport():" + ex.Message);
            }
            return (List<TrackingReport>)result;

        }

        public RealtimeTatReport RealtimeTatReport(ReportRequest reportRequest)
        {
            var oct = new RealtimeTatReport();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("fromDate", reportRequest.FromDate, DbType.String);
                dp_Param.Add("toDate", reportRequest.ToDate, DbType.String);
                dp_Param.Add("endToEndId", reportRequest.RefNo, DbType.String);
                dp_Param.Add("module", reportRequest.Module, DbType.String);
                using var db = new SqlConnection(ConfigManager.getDBConnection());
                if (reportRequest.Module == "Outward")
                {
                    var result = db.Query<RealtimeTat>("ipp_sp_rpt_Realtime_Payment_TAT_Analysis", dp_Param, commandType: commandType);
                    oct.Realtime_Tat = (List<RealtimeTat>)result;
                }
                else if (reportRequest.Module == "Inward")
                {
                    var result = db.Query<RealtimeTat>("ipp_sp_rpt_Realtime_Payment_TAT_Analysis", dp_Param, commandType: commandType);
                    oct.Realtime_Tat = (List<RealtimeTat>)result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_sp_rpt_Realtime_Payment_TAT_Analysis");
            }
            return oct;
        }

        public List<CBStaticErrorCodesReport> GetCBStaticErrorCodesReport(ReportRequest reportRequest)
        {
            var result = new List<CBStaticErrorCodesReport>();
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                var dp_Param = new DynamicParameters();
                dp_Param.Add("type", reportRequest.Module, DbType.String);

                using var db = new SqlConnection(ConfigManager.getDBConnection());
                result = db.Query<CBStaticErrorCodesReport>("ipp_rpt_CB_Static_Error_Codes", dp_Param, commandType: commandType).ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_rpt_CB_Static_Error_Codes");
            }
            return result;

        }
    }
}



