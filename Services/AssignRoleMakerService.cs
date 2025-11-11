using Amqp.Framing;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public class AssignRoleMakerService : IAssignRoleMakerService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public AssignRoleMakerService(NLogWebApiService logger)
        {
            _logger = logger;
        }

        public IEnumerable<ProductList> GetProductLists()
        {
            List<ProductList> productLists = new List<ProductList>();
            try
            {
                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_get_Prd_List_netcore", CommandType.StoredProcedure))
                using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                {
                    while (reader.Read())
                    {
                        ProductList productList = new ProductList
                        {
                            ProductId = (int)reader["Product_ID"],
                            ProductName = reader["Product_Name"].ToString()
                        };
                        productLists.Add(productList);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while fetching product list using frm_sp_get_Prd_List_netcore");
                throw;
            }

            return productLists;
        }


        public IEnumerable<Modules> GetModulesById(int productId)
        {
            List<Modules> modules = new List<Modules>();
            try
            {
                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_GetModulesByProductId", CommandType.StoredProcedure))
                {
                    command.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int) { Value = productId });

                    using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                    {
                        while (reader.Read())
                        {
                            Modules item = new Modules
                            {
                                ModuleId = (int)reader["ModuleId"],
                                ModuleName = reader["ModuleName"].ToString()
                            };
                            modules.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in frm_sp_GetModulesByProductId");
            }

            return modules;
        }

        public IEnumerable<Menus> GetMenusById(int productId)
        {
            List<Menus> menus = new List<Menus>();
            try
            {
                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_GetMenusByProductId", CommandType.StoredProcedure))
                {
                    command.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int) { Value = productId });

                    using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                    {
                        while (reader.Read())
                        {
                            Menus item = new Menus
                            {
                                MenuId = (decimal)reader["Menu_Id"],
                                ModuleName = reader["ModuleName"].ToString(),
                                MenuName = reader["MenuName"].ToString(),
                                ControllerName = reader["Controller_Name"].ToString(),
                                IndexName = reader["Index_Name"].ToString(),
                                ItemOrder = Convert.ToInt16(reader["ITEM_ORDER"].ToString()),
                                ModuleOrder = Convert.ToInt16(reader["MODULE_ORDER"].ToString()),

                            };


                            menus.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in frm_sp_GetModulesByProductId");
            }

            return menus;
        }


        public IEnumerable<Role> GetRolesById(int productId)
        {
            List<Role> roles = new List<Role>();
            try
            {
                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_GetRolesByProductId", CommandType.StoredProcedure))
                {
                    command.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int) { Value = productId });

                    using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                    {
                        while (reader.Read())
                        {
                            Role item = new Role
                            {
                                ROLE_ID = (int)reader["ROLE_ID"],
                                ROLE_NAME = reader["ROLE_NAME"].ToString()
                            };
                            roles.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in frm_sp_GetRolesByProductId");
            }

            return roles;
        }

        public IEnumerable<TransactionAccess> GetTransactionAccesses(int productId, int moduleId, int roleId)
        {
            List<TransactionAccess> transactionAccesses = new List<TransactionAccess>();
            try
            {
                using (DbCommand command = sqlHelper.GetCommandObject("frm_sp_GetAssignRoleMakerByProductId", CommandType.StoredProcedure))
                {
                    command.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int) { Value = productId });
                    command.Parameters.Add(new SqlParameter("@ModuleId", SqlDbType.Int) { Value = moduleId });
                    command.Parameters.Add(new SqlParameter("@ROLE_ID", SqlDbType.Int) { Value = roleId });

                    
                    using (IDataReader reader = sqlHelper.ExecuteDataReader(command))
                    {
                        while (reader.Read())
                        {
                            TransactionAccess item = new TransactionAccess
                            {
                                TranId = (int)reader["Menu_Id"],
                                RoleId = (int)reader["Role_Id"],
                                ModuleId = (int)reader["Module_Id"],
                                MenuName = reader["MenuName"].ToString(),
                                ModuleName = reader["ModuleName"].ToString(),
                                AccessValue = (bool)reader["AccessValue"],
                                ProductId = (int)reader["ProductId"],
                            };
                            transactionAccesses.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in frm_sp_GetRolesByProductId");
            }

            return transactionAccesses;
        }

        public string SaveAssignRole(AssignRoleModel assignRoleModel)
        {
            var result = string.Empty;
            try
            {
                DataTable roleTable = ToDataTable(assignRoleModel);

               

                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("FRM_SP_ASSIGNROLE_MAKER_UPDATE", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@ASSIGNROLE_MAKER", SqlDbType.Structured));
                Command.Parameters[0].Value = roleTable;

         
                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);


                int i = sqlHelper.ExecuteNonQuery(Command);
                result = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_SP_ASSIGNROLE_MAKER_UPDATE");
                result = ex.Message;
            }
            return result;
        }

        private DataTable ToDataTable(AssignRoleModel assignRoleModel)
        {
            var table = new DataTable();
            table.Columns.Add("Tran_Id", typeof(int));
            table.Columns.Add("Role_Id", typeof(int));
            table.Columns.Add("Module_Id", typeof(int));
            table.Columns.Add("Product_Id", typeof(int));
            table.Columns.Add("IsAccess", typeof(bool));
            table.Columns.Add("Action_By", typeof(string));
            table.Columns.Add("User_Action", typeof(string));



            foreach (var item in assignRoleModel.transactionAccesses)
            {
                table.Rows.Add(
                    item.TranId,
                    item.RoleId,
                    item.ModuleId,
                    item.ProductId,
                    item.AccessValue,
                    assignRoleModel.ActionBy,
                    item.UserAction
                );
            }

            return table;
        }
    }
}







