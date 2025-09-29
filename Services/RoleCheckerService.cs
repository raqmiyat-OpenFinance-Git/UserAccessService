using OpenFinanceWebApi.IServices;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data.Common;
using System.Data;
using Raqmiyat.Entities.Login;
using System.Data.SqlClient;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Services
{
    public class RoleCheckerService : IRoleCheckerService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public RoleCheckerService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public int ApproveOrReject(Role role)
        {
           int result = 0;
            try
            {
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_update_role_details_check_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@ROLE_ID", SqlDbType.VarChar));
                Command.Parameters[0].Value = role.ROLE_ID;
                
                Command.Parameters.Add(new SqlParameter("@ROLE_NAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = role.ROLE_NAME == null ? string.Empty : role.ROLE_NAME;

                Command.Parameters.Add(new SqlParameter("@ROLE_DESCRIPTION", SqlDbType.VarChar));
                Command.Parameters[2].Value = role.ROLE_DESCRIPTION;

                Command.Parameters.Add(new SqlParameter("@ApprovedBy", SqlDbType.VarChar));
                Command.Parameters[3].Value = role.APPROVED_BY;

                Command.Parameters.Add(new SqlParameter("@ACTION_BY", SqlDbType.VarChar));
                Command.Parameters[4].Value = role.ACTION_BY;

                Command.Parameters.Add(new SqlParameter("@ACTION_ON", SqlDbType.DateTime));
                Command.Parameters[5].Value = role.ACTION_ON;

                Command.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.Bit));
                Command.Parameters[6].Value = role.IsApproved;

                Command.Parameters.Add(new SqlParameter("@IsRejected", SqlDbType.Bit));
                Command.Parameters[7].Value = role.IsRejected;

                Command.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar));
                Command.Parameters[8].Value = role.Status;

                Command.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.VarChar));
                Command.Parameters[9].Value = role.Product_ID;

                Command.Parameters.Add(new SqlParameter("@Rejectreason", SqlDbType.VarChar));
                Command.Parameters[10].Value = role.REJECT_REASON;

                result = sqlHelper.ExecuteNonQuery(Command);


            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_update_role_details_check_netcore");
            }
            return result;
}

        public IEnumerable<Role> GetRole()
        {
            List<Role> objroleviewList = new List<Role>();
            try
            {

                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_role_details_checker_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        Role objroleview = new Role();
                        objroleview.ROLE_ID = Convert.ToInt32(objReader["ROLE_ID"]);
                        objroleview.ROLE_NAME = Convert.ToString(objReader["ROLE_NAME"]);
                        objroleview.ROLE_DESCRIPTION = Convert.ToString(objReader["ROLE_DESCRIPTION"]);
                        objroleview.ACTION_ON = Convert.ToDateTime(objReader["ACTION_ON"].ToString());
                        objroleview.ACTION = Convert.ToString(objReader["ACTION"]);
                        objroleview.Delete_Role = Convert.ToBoolean(objReader["Role_IsDelete"]);
                        objroleview.Status = Convert.ToString(objReader["Status"]);
                        objroleview.ACTION_BY = Convert.ToString(objReader["ACTION_BY"]);
                        objroleview.Product_ID = Convert.ToInt32(objReader["Product_ID"]);
                        objroleview.Product_Name = Convert.ToString(objReader["Product_Name"]);
                        objroleviewList.Add(objroleview);
                    }
                }
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_role_details_checker_netcore");
            }
            return objroleviewList;

        }


        public IEnumerable<Role> GetSearchCheckRoleDetails(Role role)
        {
            List<Role> roleDetailsList = new List<Role>();

            try
            {
                DbCommand command = sqlHelper.GetCommandObject("frm_sp_get_Check_Search_role_details_netcore", CommandType.StoredProcedure);

                command.CommandType = CommandType.StoredProcedure;
                AddSqlParameter(command, "@RoleName", SqlDbType.VarChar, role.ROLE_NAME!);
                AddSqlParameter(command, "@RoleDescription", SqlDbType.VarChar, role.ROLE_DESCRIPTION!);

                using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                {
                    while (reader.Read())
                    {
                        Role roleDetail = new Role
                        {
                            ROLE_ID = Convert.ToInt32(reader["ROLE_ID"]),
                            ROLE_NAME = Convert.ToString(reader["ROLE_NAME"]),
                            ROLE_DESCRIPTION = Convert.ToString(reader["ROLE_DESCRIPTION"]),
                            ACTION_ON = Convert.ToDateTime(reader["CREATEDON"]),
                            Status = Convert.ToString(reader["Status"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"]),
                            Product_Name= Convert.ToString(reader["Product_Name"]),
                            ACTION = Convert.ToString(reader["ACTION"])
                        };

                        roleDetailsList.Add(roleDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in GetSearchRoleDetails");
            }

            return roleDetailsList;
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
