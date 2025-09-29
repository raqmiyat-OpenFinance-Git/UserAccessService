using Dapper;
using Entities.LogMoniter;
using OpenFinanceWebApi.Models;
using OpenFinanceWebApi.NLogService;
using System.Data;

namespace OpenFinanceWebApi.IServices
{
    public class LogMoniterService : ILogMoniterService
    {
        private readonly IDbConnection _connection;
        private readonly NLogWebApiService _logger;
        public LogMoniterService(NLogWebApiService logger, IDbConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }
        public async Task SaveLoginLogout(LogMoniterModel loginLogout)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                var parameters = new DynamicParameters();
                parameters.Add("@User_Id", loginLogout.User_Id ?? string.Empty);
                parameters.Add("@Access_SourceIP", loginLogout.AccessSourceIP ?? string.Empty);
                parameters.Add("@Access_SourceHost", loginLogout.AccessSourceHost ?? string.Empty);
                parameters.Add("@SessionID", loginLogout.SessionID ?? string.Empty);
                parameters.Add("@Access_action", loginLogout.Access_action ?? string.Empty);
                parameters.Add("@Access_Description", loginLogout.Access_Description ?? string.Empty);
                parameters.Add("@Server_HostName", loginLogout.Server_HostName ?? string.Empty);
                parameters.Add("@ServerIP", loginLogout.ServerIP ?? string.Empty);
                parameters.Add("@ServerIPMAC", loginLogout.ServerIPMac ?? string.Empty);
                parameters.Add("@Access_transaction", loginLogout.TransactionName ?? string.Empty);

                await _connection.ExecuteAsync("Frm_sp_insert_Login_Logout_History", parameters, transaction: null, commandTimeout: 5000, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Frm_sp_insert_Login_Logout_Histry");
            }
        }
        public async Task<int> VerifyTransaction(TransactionApprovalRestriction approvalRestriction)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.Add("@Tran_Ref_Id", approvalRestriction.RefId, DbType.String);
                dbParam.Add("@Tran_Name", approvalRestriction.TrnName, DbType.String);
                dbParam.Add("@ActionBy", approvalRestriction.ActionBy, DbType.String);
                dbParam.Add("@Action", approvalRestriction.Action, DbType.String);
                return await _connection.ExecuteScalarAsync<int>("ipp_sp_Verify_Transaction_Restriction", dbParam, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_Verify_Transaction_Restriction");
            }
            return 0;
        }
    }
}
