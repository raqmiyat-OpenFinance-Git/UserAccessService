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
    public class TransactionAccessMakerService : ITransactionAccessMakerService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public TransactionAccessMakerService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public string AssignTxn(Txn txn)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_insert_txnaccess_check_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@TXN_ID", SqlDbType.VarChar));
                Command.Parameters[0].Value = txn.TXNATTRIBS_TXNID;

                Command.Parameters.Add(new SqlParameter("@TXN_NAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = txn.TXNATTRIBS_TXNNAME;

                Command.Parameters.Add(new SqlParameter("@TXN_ACCESS", SqlDbType.VarChar));
                Command.Parameters[2].Value = txn.TXN_ACCESS;

                Command.Parameters.Add(new SqlParameter("@ACTION_BY", SqlDbType.VarChar));
                Command.Parameters[3].Value = txn.ACTION_BY;

                Command.Parameters.Add(new SqlParameter("@ACTION", SqlDbType.VarChar));
                Command.Parameters[4].Value = txn.ACTION;

                //Command.Parameters.Add(new SqlParameter("@TXN_PRODUCT_ID", SqlDbType.Int));
                //Command.Parameters[5].Value = txn.Product_Id;
                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);


                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
               _logger.Error(ex, "frm_sp_insert_txnaccess_check_netcore");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }



        public IEnumerable<Txn> GetTransactionList(int id)
        {
            List<Txn> txnList = new List<Txn>();
            try
            {

               
                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_Ind_txn_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@TXNATTRIBS_PRODUCT_ID", SqlDbType.Int));
                Command.Parameters[0].Value = id;


                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        Txn objTxn = new Txn();
                        objTxn.TXNATTRIBS_TXNID = Convert.ToInt32(objReader["TXNATTRIBS_TXNID"].ToString());
                        objTxn.TXNATTRIBS_TXNNAME = objReader["TXNATTRIBS_TXNNAME"].ToString();
                        txnList.Add(objTxn);
                    }

                }
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_Ind_txn_details_netcore");
            }
            return txnList;
        }

        public IEnumerable<Role> GetTxnRole(int id)
        {
            List<Role> roleList = new List<Role>();
            try
            {
    
                
                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_Txn_role_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@TXNATTRIBS_TXNID", SqlDbType.VarChar));
                Command.Parameters[0].Value = id;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        Role role = new Role();
                        role.ROLE_ID = Convert.ToInt32(objReader["ROLE_ID"].ToString());
                        role.ROLE_NAME = objReader["ROLE_NAME"].ToString();
                        roleList.Add(role);
                    }

                }
               
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_Txn_role_details_netcore");
            }
            return roleList;
        }

        public IEnumerable<Txn> GetTxnRoles(int id)
        {
            List<Txn> txnList = new List<Txn>();
            try
            {


                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_Txn_roles_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@TXNATTRIBS_TXNID", SqlDbType.VarChar));
                Command.Parameters[0].Value = id;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        Txn objTxn = new Txn();
                        objTxn.TXNATTRIBS_TXNID = Convert.ToInt32(objReader["TXNATTRIBS_TXNID"].ToString());
                        objTxn.TXNATTRIBS_TXNNAME = objReader["TXNATTRIBS_TXNNAME"].ToString();
                        txnList.Add(objTxn);
                    }

                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_Txn_role_details_netcore");
            }
            return txnList;
        }
        public IEnumerable<Role> GetRole(int id)
        {
            List<Role> roleList = new List<Role>();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_role_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@PRODUCT_ID", SqlDbType.Int));
                Command.Parameters[0].Value = id;
               

                    using (objReader = sqlHelper.ExecuteDataReader(Command))
                    {
                        while (objReader.Read())
                        {
                            Role objRole = new Role();
                            objRole.ROLE_ID = Convert.ToInt32(objReader["ROLE_ID"].ToString());
                            objRole.ROLE_NAME = objReader["ROLE_NAME"].ToString();
                            objRole.ROLE_DESCRIPTION = objReader["ROLE_DESCRIPTION"].ToString();
                            roleList.Add(objRole);
                        }

                    }

                
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_role_details_netcore");
            }
            return roleList;
        }



        public IEnumerable<ProductList_Tnx> GetPrdList()
        {
            List<ProductList_Tnx> roleList = new List<ProductList_Tnx>();
            try
            {
               // List<ProductList_Tnx> roleList = new List<ProductList_Tnx>();

                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_Prd_List_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {

                    
                        while (objReader.Read())
                        {
                            ProductList_Tnx objprd = new ProductList_Tnx();
                            objprd.Product_Id = Convert.ToInt32(objReader["Product_ID"]);
                            objprd.Product_Name = Convert.ToString(objReader["Product_Name"]);
                            roleList.Add(objprd);
                        }

                    
                    //return roleList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_Prd_List_netcore");
                throw;
            }
            return roleList;
        }
    }
}







