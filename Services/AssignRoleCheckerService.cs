using Amqp.Framing;
using Dapper;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Spreadsheet;
using Entities.General;
using k8s.KubeConfigModels;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Entities.Login;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenFinanceWebApi.Services
{
    public class AssignRoleCheckerService : IAssignRoleCheckerService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public AssignRoleCheckerService(NLogWebApiService logger)
        {
            _logger = logger;
        }

        public IEnumerable<TransactionAccessCheck> GetAssignRoleList()
        {
            List<TransactionAccessCheck> transactionAccessChecks = new List<TransactionAccessCheck>();
            try
            {
                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_GetAssignRoleChecker", CommandType.StoredProcedure))
                {

                    using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                    {
                        while (reader.Read())
                        {
                            TransactionAccessCheck item = new TransactionAccessCheck
                            {
                                RoleId = (int)reader["Role_Id"],
                                TranId = (int)reader["Tran_Id"],
                                ModuleId = (int)reader["Module_Id"],
                                Role_Name = reader["ROLE_NAME"].ToString(),
                                ActionBy = reader["User_Name"].ToString(),
                                UserAction = reader["UserAction"].ToString(),
                                ActionOn = reader["Action_On"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Action_On"])
                            };
                            transactionAccessChecks.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in frm_sp_GetRolesByProductId");
            }

            return transactionAccessChecks;
        }

        public IEnumerable<AssignRoleListHistory> GetAssignRoleHistory(int roleId)
        {
            List<AssignRoleListHistory> listHistories = new List<AssignRoleListHistory>();
            try
            {
                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_GetAssignRoleHistoryChecker", CommandType.StoredProcedure))
                {
                    command.Parameters.Add(new SqlParameter("@RoleId", SqlDbType.Int) { Value = roleId });

                    using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                    {
                        while (reader.Read())
                        {
                            AssignRoleListHistory item = new AssignRoleListHistory
                            {
                                ModuleName = reader["ModuleName"].ToString(),
                                MenuName = reader["MenuName"].ToString(),
                                OAccess = (bool)reader["OAccess"],
                                NAccess = (bool)reader["NAccess"],
                            };
                            listHistories.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in frm_sp_GetRolesByProductId");
            }

            return listHistories;
        }

        public string Approve(AssignRoleModel assignRoleModel)
        {
            return UpdateAssignRole(assignRoleModel);
        }

        public string Reject(AssignRoleModel assignRoleModel)
        {
            return UpdateAssignRole(assignRoleModel);
        }

        private string UpdateAssignRole(AssignRoleModel assignRoleModel)
        {
            string result = string.Empty;

            try
            {
                using (DbCommand command = sqlHelper.GetCommandObject("FRM_SP_ASSIGNROLE_CHECKER_UPDATE", CommandType.StoredProcedure))
                {
                    command.Parameters.Add(new SqlParameter("@Role_Id", SqlDbType.Int) { Value = assignRoleModel.RoleId });
                    command.Parameters.Add(new SqlParameter("@Module_Id", SqlDbType.Int) { Value = assignRoleModel.ModuleId });
                    command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = assignRoleModel.UserName });
                    command.Parameters.Add(new SqlParameter("@Action", SqlDbType.NVarChar) { Value = assignRoleModel.Action });

                    var prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 2000)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(prm1);

                    int i = sqlHelper.ExecuteNonQuery(command);
                    result = prm1.Value == null ? string.Empty : prm1.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in FRM_SP_ASSIGNROLE_CHECKER_UPDATE");
                result = ex.Message;
            }

            return result;
        }
    }
}







