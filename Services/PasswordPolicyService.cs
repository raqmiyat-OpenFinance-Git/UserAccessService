using Entities.User;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;

//using OpenFinanceWebApi.Custom;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace OpenFinanceWebApi.IServices
{
    public class PasswordPolicyService : IPasswordPolicyService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public PasswordPolicyService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public string AddPasswordPolicy(PasswordPolicyModelView passwordPolicyModelView)
        {
            var Output_Desc = string.Empty;
            var Branch_Id = 6;
            try
            {
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("FRM_sp_insert_Maker_Password_Policy_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Country_Id", SqlDbType.NVarChar));
                Command.Parameters[0].Value = passwordPolicyModelView.CountryName;

                Command.Parameters.Add(new SqlParameter("@Bank_Id", SqlDbType.NVarChar));
                Command.Parameters[1].Value = passwordPolicyModelView.BankName;

                Command.Parameters.Add(new SqlParameter("@Branch_Id", SqlDbType.NVarChar));
                Command.Parameters[2].Value = Branch_Id;/* == null? string.Empty: passwordPolicyModelView.Branch_Id;*/

                Command.Parameters.Add(new SqlParameter("@Password_Id", SqlDbType.NVarChar));
                Command.Parameters[3].Value = passwordPolicyModelView.Password_Id;/* passwordPolicyModelView.Password_Id == null ? string.Empty : passwordPolicyModelView.Password_Id;*/

                Command.Parameters.Add(new SqlParameter("@Complex_YN", SqlDbType.NVarChar));
                Command.Parameters[4].Value = passwordPolicyModelView.Complex;

                Command.Parameters.Add(new SqlParameter("@Minimum_Len", SqlDbType.NVarChar));
                Command.Parameters[5].Value = passwordPolicyModelView.Minimum_Lenth;

                Command.Parameters.Add(new SqlParameter("@Maximun_Len", SqlDbType.NVarChar));
                Command.Parameters[6].Value = passwordPolicyModelView.Maximum_Lenth;

                Command.Parameters.Add(new SqlParameter("@Expiry_Days", SqlDbType.NVarChar));
                Command.Parameters[7].Value = passwordPolicyModelView.ExpiryDate;

                Command.Parameters.Add(new SqlParameter("@Reminder_Days", SqlDbType.NVarChar));
                Command.Parameters[8].Value = passwordPolicyModelView.ReminderDate;

                Command.Parameters.Add(new SqlParameter("@Case_Format", SqlDbType.Int));
                Command.Parameters[9].Value = passwordPolicyModelView.Uppercase;

                Command.Parameters.Add(new SqlParameter("@No_Of_Attempt", SqlDbType.NVarChar));
                Command.Parameters[10].Value = passwordPolicyModelView.NoOfAttempts;

                Command.Parameters.Add(new SqlParameter("History_Records", SqlDbType.NVarChar));
                Command.Parameters[11].Value = passwordPolicyModelView.HistoryRecords; //  == null ? string.Empty : passwordPolicyModelView.HistoryRecords;

                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.NVarChar));
                Command.Parameters[12].Value = passwordPolicyModelView.Action;

                Command.Parameters.Add(new SqlParameter("AppUserID", SqlDbType.NVarChar));
                Command.Parameters[13].Value = passwordPolicyModelView.Action_By;

                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.NVarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);
                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_sp_insert_Maker_Password_Policy_netcore");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }

        public PasswordPolicyModelView GetPassworPolicy()
        {
            PasswordPolicyModelView passwordPolicy = new PasswordPolicyModelView();
            try
            {

                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("FRM_sp_get_Password_Policy_Details_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        passwordPolicy. CountryName = Convert.ToString(objReader["Country_Id"]);
                        passwordPolicy. BankName = Convert.ToString(objReader["Bank_Id"]);
                        passwordPolicy.Branch_Id = Convert.ToString(objReader["Branch_Id"]);
                        passwordPolicy.Password_Id = Convert.ToString(objReader["Password_Id"]);
                        passwordPolicy.Complex = Convert.ToBoolean(objReader["Complex_YN"]);
                        passwordPolicy.Maximum_Lenth = Convert.ToString(objReader["Maximum_Length"]);
                        passwordPolicy.Minimum_Lenth = Convert.ToString(objReader["Minimum_Length"]);
                        passwordPolicy.ExpiryDate = Convert.ToString(objReader["Expiry_Days"]);
                        passwordPolicy.ReminderDate = Convert.ToString(objReader["Reminder_Days"]) ;
                        passwordPolicy.Uppercase = Convert.ToString(objReader["Case_Format"]);
                        passwordPolicy.HistoryRecords = Convert.ToString(objReader["History_Records"]);
                        passwordPolicy.NoOfAttempts = Convert.ToString(objReader["No_Of_Attempts"]);

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_sp_get_Password_Policy_Details_netcore");
                throw;
            }
            return passwordPolicy;
        }

        public IEnumerable<PasswordPolicyModelView> GetPasswordCheckerPolicy()
        {
            List<PasswordPolicyModelView> passwordPolicyList = new List<PasswordPolicyModelView>();
            try
            {

                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("FRM_sp_get_Password_Policy_Check_Details_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        PasswordPolicyModelView passwordPolicy = new PasswordPolicyModelView();
                        passwordPolicy.CountryName = Convert.ToString(objReader["Country_Id"]);
                        passwordPolicy.BankName = Convert.ToString(objReader["Bank_Id"]);
                        passwordPolicy.Branch_Id = Convert.ToString(objReader["Branch_Id"]);
                        passwordPolicy.Password_Id = Convert.ToString(objReader["Password_Id"]);
                        passwordPolicy.Complex = Convert.ToBoolean(objReader["Complex_YN"]);
                        passwordPolicy.Maximum_Lenth = Convert.ToString(objReader["Minimum_Length"]);
                        passwordPolicy.Minimum_Lenth = Convert.ToString(objReader["Maximum_Length"]);
                        passwordPolicy.ExpiryDate = Convert.ToString(objReader["Expiry_Days"]);
                        passwordPolicy.ReminderDate = Convert.ToString(objReader["Reminder_Days"]);
                        passwordPolicy.Uppercase = Convert.ToString(objReader["Case_Format"]);
                        passwordPolicy.HistoryRecords = Convert.ToString(objReader["History_Records"]);
                        passwordPolicy.NoOfAttempts = Convert.ToString(objReader["No_Of_Attempts"]);
                        passwordPolicy.Action = Convert.ToString(objReader["Action"]);
                        passwordPolicy.CreatedBy = Convert.ToString(objReader["Created"]);
                        passwordPolicyList.Add(passwordPolicy);
                       

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_sp_get_Password_Policy_Check_Details_netcore");
                throw;
            }
            return passwordPolicyList;
        }
        public PasswordPolicyModelView GetPasswordDetailsPolicy()
        {
           PasswordPolicyModelView passwordPolicy = new PasswordPolicyModelView();
            try
            {

                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("FRM_sp_get_Password_Policy_Check_Details_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        passwordPolicy.CountryName = Convert.ToString(objReader["Country_Id"]);
                        passwordPolicy.BankName = Convert.ToString(objReader["Bank_Id"]);
                        passwordPolicy.Branch_Id = Convert.ToString(objReader["Branch_Id"]);
                        passwordPolicy.Password_Id = Convert.ToString(objReader["Password_Id"]);
                        passwordPolicy.Complex = Convert.ToBoolean(objReader["Complex_YN"]);
                        passwordPolicy.Maximum_Lenth = Convert.ToString(objReader["Maximum_Length"]);
                        passwordPolicy.Minimum_Lenth = Convert.ToString(objReader["Minimum_Length"]);
                        passwordPolicy.ExpiryDate = Convert.ToString(objReader["Expiry_Days"]);
                        passwordPolicy.ReminderDate = Convert.ToString(objReader["Reminder_Days"]);
                        passwordPolicy.Uppercase = Convert.ToString(objReader["Case_Format"]);
                        passwordPolicy.HistoryRecords = Convert.ToString(objReader["History_Records"]);
                        passwordPolicy.NoOfAttempts = Convert.ToString(objReader["No_Of_Attempts"]);
                        passwordPolicy.Action = Convert.ToString(objReader["Action"]);
                        passwordPolicy.CreatedBy = Convert.ToString(objReader["Created"]);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_sp_get_Password_Policy_Check_Details_netcore");
                throw;
            }
            return passwordPolicy;
        }

        public string Approve(PasswordPolicyModelView passwordPolicyModelView)
        {
            var Output_Desc = string.Empty;
            var Branch_Id = 6;
            try
            {
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("FRM_sp_Approve_Checker_Password_Policy_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Country_Id", SqlDbType.NVarChar));
                Command.Parameters[0].Value = passwordPolicyModelView.CountryName;

                Command.Parameters.Add(new SqlParameter("@Bank_Id", SqlDbType.NVarChar));
                Command.Parameters[1].Value = passwordPolicyModelView.BankName;

                Command.Parameters.Add(new SqlParameter("@Branch_Id", SqlDbType.NVarChar));
                Command.Parameters[2].Value = Branch_Id;/* == null? string.Empty: passwordPolicyModelView.Branch_Id;*/

                Command.Parameters.Add(new SqlParameter("@Password_Id", SqlDbType.NVarChar));
                Command.Parameters[3].Value = passwordPolicyModelView.Password_Id;/* passwordPolicyModelView.Password_Id == null ? string.Empty : passwordPolicyModelView.Password_Id;*/

                Command.Parameters.Add(new SqlParameter("@Complex_YN", SqlDbType.NVarChar));
                Command.Parameters[4].Value = passwordPolicyModelView.Complex;

                Command.Parameters.Add(new SqlParameter("@Minimum_Len", SqlDbType.NVarChar));
                Command.Parameters[5].Value = passwordPolicyModelView.Minimum_Lenth;

                Command.Parameters.Add(new SqlParameter("@Maximun_Len", SqlDbType.NVarChar));
                Command.Parameters[6].Value = passwordPolicyModelView.Maximum_Lenth;

                Command.Parameters.Add(new SqlParameter("@Expiry_Days", SqlDbType.NVarChar));
                Command.Parameters[7].Value = passwordPolicyModelView.ExpiryDate;

                Command.Parameters.Add(new SqlParameter("@Reminder_Days", SqlDbType.NVarChar));
                Command.Parameters[8].Value = passwordPolicyModelView.ReminderDate;

                Command.Parameters.Add(new SqlParameter("@Case_Format", SqlDbType.NVarChar));
                Command.Parameters[9].Value = passwordPolicyModelView.Uppercase;

                Command.Parameters.Add(new SqlParameter("@No_Of_Attempt", SqlDbType.NVarChar));
                Command.Parameters[10].Value = passwordPolicyModelView.NoOfAttempts;

                Command.Parameters.Add(new SqlParameter("History_Records", SqlDbType.NVarChar));
                Command.Parameters[11].Value = passwordPolicyModelView.HistoryRecords; //  == null ? string.Empty : passwordPolicyModelView.HistoryRecords;

                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.NVarChar));
                Command.Parameters[12].Value = passwordPolicyModelView.Action;

                Command.Parameters.Add(new SqlParameter("@AppUserID", SqlDbType.NVarChar));
                Command.Parameters[13].Value = passwordPolicyModelView.Action_By;

                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.NVarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);
                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_sp_Approve_Checker_Password_Policy_netcore");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }

    }
}
