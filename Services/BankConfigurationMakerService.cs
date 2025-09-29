using OpenFinanceWebApi.IServices;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using Entities.BankConfiguration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using Entities.BankConfigurationChecker;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Services
{
    public class BankConfigurationMakerService : IBankConfigurationMakerService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getDBConnection());
        private readonly NLogWebApiService _logger;
        public BankConfigurationMakerService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public bool AddBankConfiguration(BankConfigurationMakerModel bankConfigurationModel)
        {
            try
            {

                var command = sqlHelper.GetCommandObject("ipp_sp_insert_BankConfiguration_Maker", CommandType.StoredProcedure);

                AddSqlParameter(command, "@BC_Tat_Interval_sec", SqlDbType.Int, bankConfigurationModel.TatSec);
                AddSqlParameter(command, "@BC_Is_Validate", SqlDbType.Bit, bankConfigurationModel.ValidateMessage);
                AddSqlParameter(command, "@Action_By", SqlDbType.NVarChar, bankConfigurationModel.ActionBy);
                AddSqlParameter(command, "@BC_Status", SqlDbType.NVarChar, bankConfigurationModel.Status);
                AddSqlParameter(command, "@BC_TwoFactor_AuthType", SqlDbType.NVarChar, bankConfigurationModel.TwoFactorAuthType);
                AddSqlParameter(command, "@EnableMessageForwarding", SqlDbType.NVarChar, bankConfigurationModel.EnableMessageForwarding);
                AddSqlParameter(command, "@ConsentEventAction", SqlDbType.Bit, bankConfigurationModel.ConsentEventAction);
                AddSqlParameter(command, "@ConsentManagement", SqlDbType.Bit, bankConfigurationModel.ConsentManagement);
                AddSqlParameter(command, "@DataSharing", SqlDbType.Bit, bankConfigurationModel.DataSharing);
                AddSqlParameter(command, "@ServiceInitiation", SqlDbType.Bit, bankConfigurationModel.ServiceInitiation);
                AddSqlParameter(command, "@BC_BankId", SqlDbType.NVarChar, bankConfigurationModel!.BankId!);
                AddSqlParameter(command, "@BC_ApiVersion", SqlDbType.NVarChar, bankConfigurationModel!.ApiVersion!);
                AddSqlParameter(command, "@BC_TimeZoneLocale", SqlDbType.NVarChar, bankConfigurationModel!.TimeZoneLocale!);
                AddSqlParameter(command, "@BC_CurrencyDefault", SqlDbType.NVarChar, bankConfigurationModel.CurrencyDefault!);
                AddSqlParameter(command, "@BC_ConsentValidityPeriod", SqlDbType.DateTime, bankConfigurationModel.ConsentValidityPeriod!);
                AddSqlParameter(command, "@BC_SessionTimeout", SqlDbType.Int, bankConfigurationModel.SessionTimeout!);
                AddSqlParameter(command, "@BC_RetryCount", SqlDbType.Int, bankConfigurationModel.RetryCount!);
                AddSqlParameter(command, "@BC_AuditTrail", SqlDbType.NVarChar, bankConfigurationModel.AuditTrailEnabled!);
                AddSqlParameter(command, "@BC_DataRetentionPeriod", SqlDbType.NVarChar, bankConfigurationModel.DataRetentionPeriod!);
                AddSqlParameter(command, "@BC_RateLimits", SqlDbType.Int, bankConfigurationModel.RateLimits);
                AddSqlParameter(command, "@BC_BankName", SqlDbType.VarChar, bankConfigurationModel.BankName);
                AddSqlParameter(command, "@BC_SwiftCode", SqlDbType.VarChar, bankConfigurationModel.SwiftCode);
                AddSqlParameter(command, "@BC_RoutingNo", SqlDbType.Int, bankConfigurationModel.RoutingNo);

                SqlParameter outputParameter = new SqlParameter("@OUTMsg", SqlDbType.NVarChar, 500);
                outputParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(outputParameter);

                int rowsAffected = sqlHelper.ExecuteNonQuery(command);
                return rowsAffected == 1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_insert_BankConfiguration_Maker");
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

        public BankConfigurationMakerModel GetBankConfiguration()
        {
            try
            {
                BankConfigurationMakerModel bankConfigurations = new BankConfigurationMakerModel();

                var command = sqlHelper.GetCommandObject("ipp_sp_select_BankConfiguration_Maker", CommandType.StoredProcedure);

                using (var dataReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (dataReader.Read())
                    {
                        bankConfigurations.TatSec = Convert.ToString(dataReader["BC_Tat_Interval_sec"]);
                        bankConfigurations.ValidateMessage = Convert.ToInt32(dataReader["BC_Is_Validate"]);
                        bankConfigurations.Status = Convert.ToString(dataReader["BC_Status"]);
                        bankConfigurations.TwoFactorAuthType = Convert.ToInt32(dataReader["BC_TwoFactor_AuthType"]);
                        bankConfigurations.EnableMessageForwarding = Convert.ToString(dataReader["EnableMessageForwarding"]);
                        bankConfigurations.ConsentEventAction = Convert.ToBoolean(dataReader["Is_Batch_Email"]);
                        bankConfigurations.ConsentManagement = Convert.ToBoolean(dataReader["Is_Realtime_Email"]);
                        bankConfigurations.DataSharing = Convert.ToBoolean(dataReader["Is_Core_Email"]);
                        bankConfigurations.ServiceInitiation = Convert.ToBoolean(dataReader["Is_Channel_Email"]);
                        bankConfigurations.BankId = Convert.ToString(dataReader["BC_BankId"]);
                        bankConfigurations.ApiVersion = Convert.ToString(dataReader["BC_ApiVersion"]);
                        bankConfigurations.TimeZoneLocale = Convert.ToString(dataReader["BC_TimeZoneLocale"]);
                        bankConfigurations.CurrencyDefault = Convert.ToString(dataReader["BC_CurrencyDefault"]);
                        bankConfigurations.ConsentValidityPeriod = Convert.ToDateTime(dataReader["BC_ConsentValidityPeriod"]);
                        bankConfigurations.SessionTimeout = Convert.ToInt32(dataReader["BC_SessionTimeout"]);
                        bankConfigurations.RetryCount = Convert.ToInt32(dataReader["BC_RetryCount"]);
                        bankConfigurations.AuditTrailEnabled = Convert.ToString(dataReader["BC_AuditTrail"]);
                        bankConfigurations.DataRetentionPeriod = Convert.ToString(dataReader["BC_DataRetentionPeriod"]);
                        bankConfigurations.RateLimits = Convert.ToInt32(dataReader["BC_RateLimits"]);
                        bankConfigurations.BankName = Convert.ToString(dataReader["BC_BankName"]);
                        bankConfigurations.SwiftCode = Convert.ToString(dataReader["BC_SwiftCode"]);
                        bankConfigurations.RoutingNo = Convert.ToInt32(dataReader["BC_RoutingNo"]);

                    }

                    return bankConfigurations;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_select_BankConfiguration_Maker");
                throw;
            }
        }

        public IEnumerable<IntegrationTypeList> GetIntegrationTypes()
        {
            List<IntegrationTypeList> integrationTypes = new List<IntegrationTypeList>();

            try
            {
                var command = sqlHelper.GetCommandObject("ipp_sp_get_general_Type_List_netcore", CommandType.StoredProcedure);

                using (var objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {
                        IntegrationTypeList integrationType = new IntegrationTypeList();
                        integrationType.Inte_Type_Name = Convert.ToString(objReader["General_List_Code"]);
                        integrationType.Inte_Type_Value = Convert.ToString(objReader["General_Desc_English"]);
                        integrationTypes.Add(integrationType);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_get_general_Type_List_netcore");
            }

            return integrationTypes;
        }

        public IEnumerable<EnableMessageForwarding> GetEnableMessageForwardingList()
        {
           List<EnableMessageForwarding> enableMessageForwardingList = new List<EnableMessageForwarding>();

            try
            {
                var command = sqlHelper.GetCommandObject("ipp_sp_get_general_Type_List_netcore_MSGFWD", CommandType.StoredProcedure);

                using (var objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {
                        EnableMessageForwarding enableMessageForwarding = new EnableMessageForwarding();
                        enableMessageForwarding.FTS_Type_Name = Convert.ToString(objReader["General_List_Code"]);
                        enableMessageForwarding.IPI_Type_Value = Convert.ToString(objReader["General_Desc_English"]);
                        enableMessageForwardingList.Add(enableMessageForwarding);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_get_general_Type_List_netcore_MSGFWD");
            }

            return enableMessageForwardingList;
        }
    }
}

