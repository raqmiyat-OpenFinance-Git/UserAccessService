using Entities.Error_Master;
using OpenFinance.Models;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.IServices;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenFinanceWebApi.Services
{
    public class ConsentBulkService : IConsentBulkService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getDBConnection());

        public string InsertConsentBulk(ConsentBulkUploadModel consentBulkUpload)
        {
            ConsetBulkUploadindividual consetBulkUploadindividual = new ConsetBulkUploadindividual();
            var Output_Desc = string.Empty;
            foreach (var item in consentBulkUpload.ConsentBulkList)
            {
                try
                {
                    DbCommand Command = null;
                    Command = sqlHelper.GetCommandObject("openf_sp_Insert_Consent_Bulk_Upload", CommandType.StoredProcedure);

                    Command.Parameters.Add(new SqlParameter("@PSUID", SqlDbType.VarChar));
                    Command.Parameters[0].Value = item.PSUID;

                    Command.Parameters.Add(new SqlParameter("@TPPName", SqlDbType.VarChar));
                    Command.Parameters[1].Value = item.TPPName;

                    Command.Parameters.Add(new SqlParameter("@ScopedGranted", SqlDbType.VarChar));
                    Command.Parameters[2].Value = item.ScopedGranted;

                    Command.Parameters.Add(new SqlParameter("@LinkedAccounts", SqlDbType.VarChar));
                    Command.Parameters[3].Value = item.linkedAccounts;

                    Command.Parameters.Add(new SqlParameter("@ConsentValidity", SqlDbType.VarChar));
                    Command.Parameters[4].Value = item.ConsentValidity;

                    Command.Parameters.Add(new SqlParameter("@Multi_User", SqlDbType.Bit));
                    Command.Parameters[5].Value = item.Multi_User;

                    Command.Parameters.Add(new SqlParameter("@Comments", SqlDbType.VarChar));
                    Command.Parameters[6].Value = item.Comments;

                    Command.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar));
                    Command.Parameters[7].Value = item.Status;

                    Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                    Command.Parameters[8].Value = item.Action;

                    SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                    prm1.Direction = ParameterDirection.Output;
                    Command.Parameters.Add(prm1);

                    int i = sqlHelper.ExecuteNonQuery(Command);
                    Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);


                }
                catch (Exception ex)
                {
                    NLogger.GetNLogger.Error("Error Occured in ConsentBulkService - InsertConsentBulk():" + ex.Message);
                }

            }
            return Output_Desc;
        }


        public List<ConsetBulkUploadindividual> FetchConsentBulk()
        {
            List<ConsetBulkUploadindividual> List = new List<ConsetBulkUploadindividual>();
            try
            {

                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("openf_Fetch_Consent_Bulk_Upload", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        List.Add(new ConsetBulkUploadindividual
                        {
                            PSUID = objReader["PSUID"].ToString(),
                            TPPName = objReader["TPPName"].ToString(),
                            ScopedGranted = objReader["ScopedGranted"].ToString(),
                            linkedAccounts = objReader["linkedAccounts"].ToString(),
                            ConsentValidity = objReader["ConsentValidity"].ToString(),
                            Multi_User = Convert.ToBoolean(objReader["Multi_User"]),
                            Comments = objReader["Comments"].ToString(),
                            Status = objReader["Status"].ToString(),
                            Action = objReader["Action"].ToString(),

                        });


                    }
                    return List;
                }

            }
            catch (Exception ex)
            {
                //_logger.Error(ex, "frm_sp_select_error_master");
            }
            return List;
        }


        public ConsetBulkUploadindividual FetchConsentBulkindividual(string id)
        {
            ConsetBulkUploadindividual bulkUploadindividual = new ConsetBulkUploadindividual();
            try
            {
                DbCommand Command = sqlHelper.GetCommandObject("openf_Fetch_Consent_Bulk_Upload_individual", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@PSUID", SqlDbType.VarChar) { Value = id });

                using (IDataReader objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    if (objReader.Read())
                    {
                        bulkUploadindividual = new ConsetBulkUploadindividual
                        {
                            PSUID = objReader["PSUID"].ToString(),
                            TPPName = objReader["TPPName"].ToString(),
                            ScopedGranted = objReader["ScopedGranted"].ToString(),
                            linkedAccounts = objReader["linkedAccounts"].ToString(),
                            ConsentValidity = objReader["ConsentValidity"].ToString(),
                            Multi_User = Convert.ToBoolean(objReader["Multi_User"]),
                            Comments = objReader["Comments"].ToString(),
                            Status = objReader["Status"].ToString(),
                            Action = objReader["Action"].ToString()
                        };
                    }
                }

                return bulkUploadindividual;
            }
            catch (Exception ex)
            {
                //_logger.Error(ex, "frm_sp_select_error_master");
            }
            return bulkUploadindividual;
        }
    }
}
