using Entities.BankConfigurationChecker;
using OpenFinanceWebApi.IServices;
using Raqmiyat.Infrastructure.Data;
using System.Data.Common;
using System.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data.SqlClient;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Services
{
    public class BankConfigurationCheckerService : IBankConfigurationCheckerService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getDBConnection());
        private readonly NLogWebApiService _logger;
        public BankConfigurationCheckerService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public BankConfigurationCheckerModel GetBankConfiguration()
        {
            try
            {

                var bankConfigurations = new BankConfigurationCheckerModel();

                var command = sqlHelper.GetCommandObject("ipp_sp_select_BankConfiguration_Checker", CommandType.StoredProcedure);

                using (var objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {
                        bankConfigurations.BC_ID = Convert.ToInt32(objReader["BC_ID"]);
                        bankConfigurations.TatSec = Convert.ToInt32(objReader["BC_Tat_Interval_sec"]);
                        bankConfigurations.ValidateMessage = Convert.ToInt32(objReader["BC_Is_Validate"]);
                        bankConfigurations.ActionBy = Convert.ToString(objReader["BC_Created_By"]);
                        bankConfigurations.Action = Convert.ToString(objReader["BC_Action"]);
                        bankConfigurations.TwoFactorAuthType = Convert.ToInt32(objReader["BC_TwoFactor_AuthType"]);
                        bankConfigurations.EnableMessageForwarding = Convert.ToString(objReader["EnableMessageForwarding"]);
                        bankConfigurations.ConsentEventAction= Convert.ToBoolean(objReader["Is_Batch_Email"]);
                        bankConfigurations.ConsentManagement = Convert.ToBoolean(objReader["Is_Realtime_Email"]);
                        bankConfigurations.DataSharing = Convert.ToBoolean(objReader["Is_Core_Email"]);
                        bankConfigurations.ServiceInitiation = Convert.ToBoolean(objReader["Is_Channel_Email"]);
                        bankConfigurations.BankId = Convert.ToString(objReader["BC_BankId"]);
                        bankConfigurations.ApiVersion = Convert.ToString(objReader["BC_ApiVersion"]);
                        bankConfigurations.TimeZoneLocale = Convert.ToString(objReader["BC_TimeZoneLocale"]);
                        bankConfigurations.CurrencyDefault = Convert.ToString(objReader["BC_CurrencyDefault"]);
                        bankConfigurations.ConsentValidityPeriod = Convert.ToDateTime(objReader["BC_ConsentValidityPeriod"]);
                        bankConfigurations.SessionTimeout = Convert.ToInt32(objReader["BC_SessionTimeout"]);
                        bankConfigurations.RetryCount = Convert.ToInt32(objReader["BC_RetryCount"]);
                        bankConfigurations.AuditTrailEnabled = Convert.ToString(objReader["BC_AuditTrail"]);
                        bankConfigurations.DataRetentionPeriod = Convert.ToString(objReader["BC_DataRetentionPeriod"]);
                        bankConfigurations.RateLimits = Convert.ToInt32(objReader["BC_RateLimits"]);
                        bankConfigurations.BankName = Convert.ToString(objReader["BC_BankName"]);
                        bankConfigurations.SwiftCode = Convert.ToString(objReader["BC_SwiftCode"]);
                        bankConfigurations.RoutingNo = Convert.ToInt32(objReader["BC_RoutingNo"]);
                    }
                }

                return bankConfigurations;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_select_BankConfiguration_Checker");
                throw;
            }
        }

        public bool ApproveRejectBankConfiguration(BankConfigurationCheckerModel bankConfigurationCheckerModel)
        {
            try
            {
                var command = sqlHelper.GetCommandObject("ipp_sp_insert_BankConfiguration_Checker", CommandType.StoredProcedure);

                AddSqlParameter(command, "@BC_Tat_Interval_sec", SqlDbType.Int, bankConfigurationCheckerModel.TatSec);
                AddSqlParameter(command, "@BC_Is_Validate", SqlDbType.Bit, bankConfigurationCheckerModel.ValidateMessage);
                AddSqlParameter(command, "@Action_By", SqlDbType.NVarChar, bankConfigurationCheckerModel.CreatedBy!);
                AddSqlParameter(command, "@BC_Action", SqlDbType.NVarChar, bankConfigurationCheckerModel.Action!);
                AddSqlParameter(command, "@BC_TwoFactor_AuthType", SqlDbType.NVarChar, bankConfigurationCheckerModel.TwoFactorAuthType);
                AddSqlParameter(command, "@BC_ID", SqlDbType.Int, bankConfigurationCheckerModel.BC_ID);
                AddSqlParameter(command, "@EnableMessageForwarding", SqlDbType.NVarChar, bankConfigurationCheckerModel!.EnableMessageForwarding!);
                AddSqlParameter(command, "@ConsentEventAction", SqlDbType.Bit, bankConfigurationCheckerModel.ConsentEventAction);
                AddSqlParameter(command, "@ConsentManagement", SqlDbType.Bit, bankConfigurationCheckerModel.ConsentManagement);
                AddSqlParameter(command, "@DataSharing", SqlDbType.Bit, bankConfigurationCheckerModel.DataSharing);
                AddSqlParameter(command, "@ServiceInitiation", SqlDbType.Bit, bankConfigurationCheckerModel.ServiceInitiation);
                AddSqlParameter(command, "@BC_BankId", SqlDbType.NVarChar, bankConfigurationCheckerModel!.BankId!);
                AddSqlParameter(command, "@BC_ApiVersion", SqlDbType.NVarChar, bankConfigurationCheckerModel!.ApiVersion!);
                AddSqlParameter(command, "@BC_TimeZoneLocale", SqlDbType.NVarChar, bankConfigurationCheckerModel!.TimeZoneLocale!);
                AddSqlParameter(command, "@BC_CurrencyDefault", SqlDbType.NVarChar, bankConfigurationCheckerModel.CurrencyDefault!);
                AddSqlParameter(command, "@BC_ConsentValidityPeriod", SqlDbType.DateTime, bankConfigurationCheckerModel.ConsentValidityPeriod!);
                AddSqlParameter(command, "@BC_SessionTimeout", SqlDbType.Int, bankConfigurationCheckerModel.SessionTimeout!);
                AddSqlParameter(command, "@BC_RetryCount", SqlDbType.Int, bankConfigurationCheckerModel.RetryCount!);
                AddSqlParameter(command, "@BC_AuditTrail", SqlDbType.NVarChar, bankConfigurationCheckerModel.AuditTrailEnabled!);
                AddSqlParameter(command, "@BC_DataRetentionPeriod", SqlDbType.NVarChar, bankConfigurationCheckerModel.DataRetentionPeriod!);
                AddSqlParameter(command, "@BC_RateLimits", SqlDbType.Int, bankConfigurationCheckerModel.RateLimits!);
                AddSqlParameter(command, "@BC_BankName", SqlDbType.VarChar, bankConfigurationCheckerModel.BankName!);
                AddSqlParameter(command, "@BC_SwiftCode", SqlDbType.VarChar, bankConfigurationCheckerModel.SwiftCode!);
                AddSqlParameter(command, "@BC_RoutingNo", SqlDbType.Int, bankConfigurationCheckerModel.RoutingNo!);

                int rowsAffected = sqlHelper.ExecuteNonQuery(command);
                bool isApproved = rowsAffected >= 1;

                return isApproved;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_insert_BankConfiguration_Checker");
                throw;
            }
        }

        private void AddSqlParameter(DbCommand command, string paramName, SqlDbType paramType, object paramValue)
        {
            try
            {
                command.Parameters.Add(new SqlParameter(paramName, paramType));
                command.Parameters[command.Parameters.Count - 1].Value = paramValue ?? DBNull.Value;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }
    }
}
