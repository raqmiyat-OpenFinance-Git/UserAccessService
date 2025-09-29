using OpenFinanceWebApi.IServices;
using Raqmiyat.Infrastructure.Data;
using System.Data.Common;
using System.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data.SqlClient;
using Raqmiyat.Entities.Login;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;


namespace OpenFinanceWebApi.Services
{
    public class RoleMakerService : IRoleMakerService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public RoleMakerService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public string CreateRole(Role role)
        {
           
            try
            {
                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_insert_role_details_netcore", CommandType.StoredProcedure))
                {

                    AddSqlParameter(command, "@ROLE_ID", SqlDbType.VarChar, role.ROLE_ID);
                    AddSqlParameter(command, "@Role_Name", SqlDbType.VarChar, role.ROLE_NAME);
                    AddSqlParameter(command, "@Role_Description", SqlDbType.VarChar, role.ROLE_DESCRIPTION);
                    AddSqlParameter(command, "@ACTION_BY", SqlDbType.VarChar, role.ACTION_BY);
                    AddSqlParameter(command, "@Action", SqlDbType.VarChar, role.ACTION);
                    AddSqlParameter(command, "@Role_IsDelete", SqlDbType.VarChar, role.Delete_Role);
                    AddSqlParameter(command, "@Product_ID", SqlDbType.VarChar, role.Product_ID);

                    SqlParameter outputParam = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 200);
                    outputParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParam);

                    sqlHelper.ExecuteNonQuery(command);

                    return outputParam.Value.ToString()!;
                }
            }
            catch (Exception ex)
            {
               _logger.Error(ex, "frm_sp_insert_role_details_netcore");
                return "Error";
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

        public IEnumerable<Role> GetRoleDetails()
        {
            List<Role> roleDetailsList = new List<Role>();

            try
            {
                DbCommand command = sqlHelper.GetCommandObject("frm_sp_get_role_details_netcore", CommandType.StoredProcedure);
               
                using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                {
                    while (reader.Read())
                    {
                        Role roleDetail = new Role();
                        roleDetail.ROLE_ID = Convert.ToInt32(reader["ROLE_ID"]);
                        roleDetail.ROLE_NAME = Convert.ToString(reader["ROLE_NAME"]);
                        roleDetail.ROLE_DESCRIPTION = Convert.ToString(reader["ROLE_DESCRIPTION"]);
                        roleDetail.ACTION_ON = Convert.ToDateTime(reader["CREATEDON"].ToString());
                        roleDetail.Status = Convert.ToString(reader["Status"]);
                        roleDetail.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        roleDetail.Product_ID = Convert.ToInt32(reader["Product_ID"]);
                        roleDetail.Product_Name = Convert.ToString(reader["Product_Name"]);
                        roleDetail.IsAssigned = Convert.ToInt32(reader["IsAssigned"]);
                        roleDetail.REJECT_REASON = Convert.ToString(reader["RejectReason"]);
                        roleDetailsList.Add(roleDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_role_details_netcore");
            }
           
            return roleDetailsList;
        }

        public IEnumerable<Role> GetSearchRoleDetails(Role role)
        {
            List<Role> roleDetailsList = new List<Role>();

            try
            {
                DbCommand command = sqlHelper.GetCommandObject("frm_sp_get_Search_role_details_netcore", CommandType.StoredProcedure);

                command.CommandType = CommandType.StoredProcedure;
                AddSqlParameter(command, "@RoleName", SqlDbType.VarChar, role.ROLE_NAME);
                AddSqlParameter(command, "@RoleDescription", SqlDbType.VarChar, role.ROLE_DESCRIPTION);

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

        public string UpdateRole(Role role)
        {
            try
            {
                NLogger.GetNLogger.Debug("SQL Stored Procedure (frm_sp_update_role_details_netcore)");

                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_update_role_details_netcore", CommandType.StoredProcedure))
                {
                    AddSqlParameter(command, "@ROLE_ID", SqlDbType.VarChar, role.ROLE_ID);
                    AddSqlParameter(command, "@ROLE_NAME", SqlDbType.VarChar, role.ROLE_NAME);
                    AddSqlParameter(command, "@ROLE_DESCRIPTION", SqlDbType.VarChar, role.ROLE_DESCRIPTION);
                    AddSqlParameter(command, "@ACTION_BY", SqlDbType.VarChar, role.ACTION_BY);
                    AddSqlParameter(command, "@Action", SqlDbType.VarChar, role.ACTION);
                    AddSqlParameter(command, "@Isdelete", SqlDbType.VarChar, role.Delete_Role);
                    AddSqlParameter(command, "@IsActive", SqlDbType.VarChar, role.Status);
                    AddSqlParameter(command, "@Product_ID", SqlDbType.VarChar, role.Product_ID);

                    SqlParameter outputParam = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                    outputParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParam);

                    sqlHelper.ExecuteNonQuery(command);

                    return outputParam.Value.ToString()!;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_update_role_details_netcore");
                return "Error";
            }
           
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            List<ProductType> productTypes = new List<ProductType>();

            try
            {
                NLogger.GetNLogger.Debug("SQL Stored Procedure (frm_sp_get_product_List)");

                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_get_product_List", CommandType.StoredProcedure))
                {
                    using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                    {
                        while (reader.Read())
                        {
                            ProductType productType = new ProductType();
                            productType.Product_Id = Convert.ToInt32(reader["Product_ID"]);
                            productType.Product_Name = Convert.ToString(reader["Product_Name"]);
                            productTypes.Add(productType);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_product_List");
            }
           

            return productTypes;
        }
    }
}
