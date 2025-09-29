using Entities.Master;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenFinanceWebApi.Services
{
    public class EmailGroupMasterService : IEmailGroupMasterService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        SqlHelper sqlHelperDB = new SqlHelper(ConfigManager.getDBConnection());
        private readonly NLogWebApiService _logger;
        public EmailGroupMasterService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public IEnumerable<EmailGroupMasterModel> GetEmailGroupDetails()
        {
            List<EmailGroupMasterModel> countryList = new List<EmailGroupMasterModel>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelperDB.GetCommandObject("IPP_sp_select_Email_Group_master", CommandType.StoredProcedure);
                using (objReader = sqlHelperDB.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        EmailGroupMasterModel objUser = new EmailGroupMasterModel();
                        objUser.ID = objReader["ID"].ToString();
                        objUser.emailaddress = objReader["Email_Address"].ToString();
                        objUser.ACTION = objReader["Action"].ToString();
                        objUser.EmailModule = objReader["Module"].ToString();
                        objUser.Created_On = Convert.ToDateTime(objReader["Created_On"].ToString());
                        objUser.Created_By = objReader["Created_BY"].ToString();
                        objUser.STATUS = objReader["Status"].ToString();
                        
                        countryList.Add(objUser);
                    }

                }
                return countryList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Email_Group_master");
            }
            return countryList;


        }
        public string AddEmailGroup(EmailGroupMasterModel email)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;


                Command = sqlHelper.GetCommandObject("IPP_sp_insert_update_Email_Group_master", CommandType.StoredProcedure);

                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                Command.Parameters[0].Value = email.ID;

                Command.Parameters.Add(new SqlParameter("@Email_Address", SqlDbType.VarChar));
                Command.Parameters[1].Value = email.emailaddress;

                Command.Parameters.Add(new SqlParameter("@Module", SqlDbType.VarChar));
                Command.Parameters[2].Value = email.EmailModule;

                Command.Parameters.Add(new SqlParameter("@ACTION", SqlDbType.VarChar));
                Command.Parameters[3].Value = email.ACTION;

                Command.Parameters.Add(new SqlParameter("@ACTION_BY", SqlDbType.VarChar));
                Command.Parameters[4].Value = email.ACTION_BY;


                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelperDB.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_insert_update_Email_Group_master");
                Output_Desc = ex.Message;
            }
            return Output_Desc;

        }

        public IEnumerable<EmailGroupMasterModel> GetEmailGroupCheckerDetails()
        {
            List<EmailGroupMasterModel> countryList = new List<EmailGroupMasterModel>();

            try
            {

                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelperDB.GetCommandObject("IPP_sp_get_Email_Group_master_check", CommandType.StoredProcedure);
                using (objReader = sqlHelperDB.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        EmailGroupMasterModel objUser = new EmailGroupMasterModel();
                        objUser.ID = objReader["ID"].ToString();
                        objUser.emailaddress = objReader["Email_Address"].ToString();
                        objUser.ACTION = objReader["Action"].ToString();
                        objUser.Created_By = objReader["Created_BY"].ToString();
                        objUser.Created_On = Convert.ToDateTime(objReader["Created_On"].ToString());
                        objUser.EmailModule = objReader["Module"].ToString();

                        countryList.Add(objUser);
                    }

                }
                return countryList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_get_Email_Group_master_check");
            }
            return countryList;
        }

        public EmailGroupMasterModel GetEmailGroupCheckIndividualDetails(string emailaddress, string EmailModule)
        {
            EmailGroupMasterModel objUser = new EmailGroupMasterModel();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_get_IND_Email_Group_master_check", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar));
                Command.Parameters[0].Value = emailaddress;
                Command.Parameters.Add(new SqlParameter("@EmailModule", SqlDbType.NVarChar));
                Command.Parameters[1].Value = EmailModule;
                using (objReader = sqlHelperDB.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        objUser.ID = objReader["ID"].ToString();
                        objUser.emailaddress = objReader["Email_Address"].ToString();
                        objUser.ACTION = objReader["Action"].ToString();
                        objUser.Created_By = objReader["Created_BY"].ToString();
                        objUser.Created_On = Convert.ToDateTime(objReader["Created_On"].ToString());
                        objUser.EmailModule = objReader["Module"].ToString();

                    }

                }
                return objUser;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_get_IND_Email_Group_master_check");
            }
            return objUser;


        }


        public string ApproveOrRejectEmailGroup(EmailGroupMasterModel email)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand Command = null;

                Command = sqlHelperDB.GetCommandObject("IPP_sp_approve_Email_Group_master_check", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                Command.Parameters[0].Value = email.ID;

                Command.Parameters.Add(new SqlParameter("@Email_Address", SqlDbType.VarChar));
                Command.Parameters[1].Value = email.emailaddress;

                Command.Parameters.Add(new SqlParameter("@Email_Module", SqlDbType.VarChar));
                Command.Parameters[2].Value = email.EmailModule;

                Command.Parameters.Add(new SqlParameter("@ACTION", SqlDbType.VarChar));
                Command.Parameters[3].Value = email.ACTION;

                Command.Parameters.Add(new SqlParameter("@Approved_By", SqlDbType.VarChar));
                Command.Parameters[4].Value = email.APPROVED_BY;

                Command.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.Bit));
                Command.Parameters[5].Value = email.ISAPPROVED;

                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelperDB.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_approve_Email_Group_master_check");
            }
            return Output_Desc;
        }

        public EmailGroupMasterModel GetMakerEmailGroupIndividualDetails(string Id, string emailID, string Module,string status)
        {
           EmailGroupMasterModel objUser = new EmailGroupMasterModel();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelperDB.GetCommandObject("IPP_sp_get_IND_Email_Group_master_maker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.NVarChar));
                Command.Parameters[0].Value = Id;
                Command.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar));
                Command.Parameters[1].Value = emailID;
                Command.Parameters.Add(new SqlParameter("@EmailModule", SqlDbType.NVarChar));
                Command.Parameters[2].Value = Module;
                Command.Parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar));
                Command.Parameters[3].Value = status;
                using (objReader = sqlHelperDB.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        objUser.ID = objReader["ID"].ToString();
                        objUser.emailaddress = objReader["Email_Address"].ToString();
                        objUser.Created_On = Convert.ToDateTime(objReader["Created_On"].ToString());
                        objUser.ACTION = objReader["Action"].ToString();
                        objUser.EmailModule = objReader["Module"].ToString();
                        objUser.Created_By = objReader["Created_BY"].ToString();
                        objUser.STATUS = objReader["status"].ToString();
                        

                    }
                }
                return objUser;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_get_IND_Email_Group_master_maker");
            }
            return objUser;
        }
        public string DeleteEmailGroup(EmailGroupMasterModel country)
        {
            var OutputDesc = string.Empty;
            try
            {
                DbCommand Command = null;
                Command = sqlHelperDB.GetCommandObject("IPP_sp_delete_Email_Group_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.NVarChar));
                Command.Parameters[0].Value = country.ID;
                Command.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar));
                Command.Parameters[1].Value = country.emailaddress;
                Command.Parameters.Add(new SqlParameter("@EmailModule", SqlDbType.NVarChar));
                Command.Parameters[2].Value = country.EmailModule;
                Command.Parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar));
                Command.Parameters[3].Value = country.STATUS;

                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[4].Value = country.ACTION;

                Command.Parameters.Add(new SqlParameter("@ACTION_BY", SqlDbType.VarChar));
                Command.Parameters[5].Value = country.ACTION_BY;

                SqlParameter prm1 = new SqlParameter("@OutputDesc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelperDB.ExecuteNonQuery(Command);
                OutputDesc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_delete_Email_Group_master");
                OutputDesc = ex.Message;
            }
            return OutputDesc;
        }

        public IEnumerable<EmailGroupMasterModel> GetFilterEmailGroupMaker(string Search_Country_Code)
        {
            List<EmailGroupMasterModel> countryMakers = new List<EmailGroupMasterModel>();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_filter_details_country_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar));
                Command.Parameters[0].Value = Search_Country_Code;



                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                        countryMakers.Add(new EmailGroupMasterModel
                        {
                            COUNTRY_ID = Convert.ToInt32(objReader["COUNTRY_ID"].ToString()),
                            COUNTRY_CODE = objReader["COUNTRY_CODE"].ToString(),
                            COUNTRY_NAME = objReader["COUNTRY_NAME"].ToString(),
                            CURRENCY_CODE = objReader["CURRENCY_CODE"].ToString(),
                            ACTION = objReader["ACTION"].ToString(),
                            STATUS = objReader["STATUS"].ToString(),
                        });
                }

                return countryMakers;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_filter_details_country_master");
            }
            return countryMakers;

        }
        public IEnumerable<EmailGroupMasterModel> GetFilterEmailGroupChecker(string Search_Country_Code)
        {
           List<EmailGroupMasterModel> countryChecker = new List<EmailGroupMasterModel>();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_filter_details_country_master_Check", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar));
                Command.Parameters[0].Value = Search_Country_Code;



                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                        countryChecker.Add(new EmailGroupMasterModel
                        {
                            COUNTRY_ID = Convert.ToInt32(objReader["COUNTRY_ID"].ToString()),
                            COUNTRY_CODE = objReader["COUNTRY_CODE"].ToString(),
                            COUNTRY_NAME = objReader["COUNTRY_NAME"].ToString(),
                            CURRENCY_CODE = objReader["CURRENCY_CODE"].ToString(),
                            ACTION = objReader["ACTION"].ToString(),
                        });
                }

                return countryChecker;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_filter_details_country_master_Check");
            }
            return countryChecker;

        }
        public IEnumerable<EmailModule> getEmailModuleCode()
        {
            List<EmailModule> objEmailModuleList = new List<EmailModule>();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;


                Command = sqlHelper.GetCommandObject("frm_sp_get_Email_Module_List", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        EmailModule objEmailModule = new EmailModule();

                        objEmailModule.Email_Module = Convert.ToString(objReader["Email_Module"]);

                        objEmailModuleList.Add(objEmailModule);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_Email_Module_List");
            }
            return objEmailModuleList;
        }
    }
}



