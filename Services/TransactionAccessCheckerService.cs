using Raqmiyat.Entities.Login;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Services
{
    public class TransactionAccessCheckerService : ITransactionAccessCheckerService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public TransactionAccessCheckerService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public IEnumerable<Txn> GetTransactionList()
        {
            List<Txn> txnList = new List<Txn>();
            try
            {
               

                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_txnaccess_check_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        Txn objTxn = new Txn();
                        objTxn.TXNATTRIBS_TXNID = Convert.ToInt32(objReader["TXN_ID"].ToString());
                        objTxn.TXNATTRIBS_TXNNAME = objReader["TXN_NAME"].ToString();
                        objTxn.TXN_ACCESS = objReader["TXN_ACCESS"].ToString();
                        objTxn.ACTION_BY = objReader["ACTION_BY"].ToString();
                        objTxn.ACTION_ON = Convert.ToDateTime(objReader["ACTION_ON"].ToString());
                        objTxn.ACTION = objReader["ACTION"].ToString();
                        objTxn.Product_Id = Convert.ToInt32(objReader["TXNATTRIBS_PRODUCT_ID"]);
                        objTxn.Product_Name = Convert.ToString(objReader["Product_Name"]);
                        txnList.Add(objTxn);
                    }
                }
                return txnList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_txnaccess_check_netcore");
            }
            return txnList;

        }

        public string ApproveTxn(Txn txn)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_update_assign_txn_role_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@TxnID", SqlDbType.VarChar));
                Command.Parameters[0].Value = txn.TXNATTRIBS_TXNID;

                Command.Parameters.Add(new SqlParameter("@TXN_NAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = txn.TXNATTRIBS_TXNNAME;

                Command.Parameters.Add(new SqlParameter("@TXN_ACCESS", SqlDbType.VarChar));
                Command.Parameters[2].Value = txn.TXN_ACCESS;

                Command.Parameters.Add(new SqlParameter("@ACTION_BY", SqlDbType.VarChar));
                Command.Parameters[3].Value = txn.ACTION_BY;

                Command.Parameters.Add(new SqlParameter("@ACTION_ON", SqlDbType.VarChar));
                Command.Parameters[4].Value = txn.ACTION_ON;

                Command.Parameters.Add(new SqlParameter("@ACTION", SqlDbType.VarChar));
                Command.Parameters[5].Value = txn.ACTION;

                Command.Parameters.Add(new SqlParameter("@APPROVED_BY", SqlDbType.VarChar));
                Command.Parameters[6].Value = txn.APPROVED_BY;

                //Command.Parameters.Add(new SqlParameter("@APPROVED_ON", SqlDbType.VarChar));
                //Command.Parameters[7].Value = txn.APPROVED_ON;


                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);


                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_update_assign_txn_role_netcore");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }
        public Txn GetTxnRole(int id)
        {
            Txn txn = new Txn();

            try
            {

                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_individual_txnaccess_check_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@TxnID",SqlDbType.VarChar));
                Command.Parameters[0].Value = id;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        txn.TXNATTRIBS_TXNID = Convert.ToInt32(objReader["TXN_ID"].ToString());
                        txn.TXNATTRIBS_TXNNAME = objReader["TXN_NAME"].ToString();
                        txn.TXN_ACCESS = objReader["TXN_ACCESS"].ToString();
                        txn.ACTION_BY = objReader["ACTION_BY"].ToString();
                        txn.ACTION_ON = Convert.ToDateTime(objReader["ACTION_ON"].ToString());
                        txn.ACTION = objReader["ACTION"].ToString();
                        txn.Product_Id = Convert.ToInt32(objReader["TXN_PRODUCT_ID"]);
                        txn.Product_Name = Convert.ToString(objReader["Product_Name"]);

                    }
                }
               
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_individual_txnaccess_check_netcore");
            }
            return txn;
        }
    }

}
