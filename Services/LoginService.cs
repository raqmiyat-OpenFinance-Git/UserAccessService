using OpenFinanceWebApi.NLogService;
using Raqmiyat.Entities.Login;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenFinanceWebApi.IServices
{
    public class LoginService : ILoginService
    {

        private readonly SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public LoginService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public Login GetLogin(string userCode)
        {
            var login = new Login();
            try
            {

                IDataReader objReader;
                DbCommand Command;

                Command = sqlHelper.GetCommandObject("frm_sp_get_user_login", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar));
                Command.Parameters[0].Value = userCode;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        login = new Login
                        {
                            UserID = objReader["UserID"] == null ? 0 : Convert.ToInt32(objReader["UserID"]),
                            UserCode = objReader["UserCode"] == null ? string.Empty : Convert.ToString(objReader["UserCode"]),
                            UserPassword = objReader["UserPassword"] == null ? string.Empty : Convert.ToString(objReader["UserPassword"]),
                            UserStatus = objReader["UserStatus"] == null ? string.Empty : Convert.ToString(objReader["UserStatus"]),

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_user_login");
                throw;
            }
            return login;
        }
        public int SaveSession(UserSession userSession)
        {

            int result = 0;
            try
            {
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_save_user_session", CommandType.StoredProcedure);

                Command.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.VarChar));
                Command.Parameters[0].Value = userSession.SessionID == null ? string.Empty : userSession.SessionID;

                Command.Parameters.Add(new SqlParameter("@SessionUserID", SqlDbType.VarChar));
                Command.Parameters[1].Value = userSession.SessionUserID == null ? string.Empty : userSession.SessionUserID;

                Command.Parameters.Add(new SqlParameter("@SessionLoginTime", SqlDbType.VarChar));
                Command.Parameters[2].Value = userSession.SessionLoginTime == null ? string.Empty : userSession.SessionLoginTime;

                Command.Parameters.Add(new SqlParameter("@SessionWrkStnID", SqlDbType.VarChar));
                Command.Parameters[3].Value = userSession.SessionWrkStnID == null ? string.Empty : userSession.SessionWrkStnID;

                Command.Parameters.Add(new SqlParameter("@SessionCommChannel", SqlDbType.VarChar));
                Command.Parameters[4].Value = userSession.SessionCommChannel == null ? string.Empty : userSession.SessionCommChannel;

                result = sqlHelper.ExecuteNonQuery(Command);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_save_user_session");
                return 0;
            }
            return result;
        }
        public int GetSession(UserSession userSession)
        {
            int count = 0;
            try
            {


                DbCommand Command;

                Command = sqlHelper.GetCommandObject("frm_sp_get_user_session", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.VarChar));
                Command.Parameters[0].Value = userSession.SessionID;

                Command.Parameters.Add(new SqlParameter("@SessionUserID", SqlDbType.VarChar));
                Command.Parameters[1].Value = userSession.SessionUserID;

                count = (int)sqlHelper.ExecuteScalar(Command);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_user_session");
                throw;
            }
            return count;
        }
        public LoginValidation GetInitialPwd(string userCode)
        {
            var loginValidation = new LoginValidation();
            try
            {
                loginValidation.UserCode = userCode;

                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_Initial_PWD_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@language", SqlDbType.VarChar));
                Command.Parameters[0].Value = "en-GB";

                Command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar));
                Command.Parameters[1].Value = userCode;

                string userMsg = (string)sqlHelper.ExecuteScalar(Command);

                loginValidation.UserMsg = userMsg;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_Initial_PWD_netcore");
                throw new InvalidOperationException(ex.Message, ex);
            }
            return loginValidation;
        }
        public string InactivateUser(string userCode)
        {
            string userMsg = string.Empty;
            try
            {
                DbCommand Command;
                Command = sqlHelper.GetCommandObject("FRM_SP_INACTIVATEUSERS_IF_IDLE", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar));
                Command.Parameters[0].Value = userCode;

                Command.Parameters.Add(new SqlParameter("@language", SqlDbType.VarChar));
                Command.Parameters[1].Value = "en-GB";

                SqlParameter prm1 = new SqlParameter("@userMsg", SqlDbType.VarChar, 100);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                sqlHelper.ExecuteNonQuery(Command);

                userMsg = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_SP_INACTIVATEUSERS_IF_IDLE");
            }
            return userMsg;
        }
        public int ResetPasswordCount(string userCode)
        {
            int result = 0;
            try
            {
                DbCommand Command;

                Command = sqlHelper.GetCommandObject("FRM_SP_RESET_PWD_COUNT", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar));
                Command.Parameters[0].Value = userCode;

                Command.Parameters.Add(new SqlParameter("@language", SqlDbType.VarChar));
                Command.Parameters[1].Value = "en-GB";

                result = sqlHelper.ExecuteNonQuery(Command);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_SP_RESET_PWD_COUNT");
                return result;
            }
            return result;
        }
        public string UpdatePasswordFailedCount(string userCode)
        {
            string userMsg = string.Empty;
            try
            {
                DbCommand Command;
                Command = sqlHelper.GetCommandObject("frm_sp_pwd_failed_count", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar));
                Command.Parameters[0].Value = userCode;

                Command.Parameters.Add(new SqlParameter("@language", SqlDbType.VarChar));
                Command.Parameters[1].Value = "en-GB";

                SqlParameter prm1 = new SqlParameter("@userMsg", SqlDbType.VarChar, 100);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int result = sqlHelper.ExecuteNonQuery(Command);

                if (result > 0)
                {
                    userMsg = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_pwd_failed_count");
               
            }
            return userMsg;
        }

        public int DeleteSession(UserSession userSession)
        {
            int result = 0;
            try
            {
                DbCommand Command;
                Command = sqlHelper.GetCommandObject("frm_sp_delete_user_session", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@SessionUserID", SqlDbType.VarChar));
                Command.Parameters[0].Value = userSession.SessionUserID == null ? string.Empty : userSession.SessionUserID;
                Command.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.VarChar));
                Command.Parameters[1].Value = userSession.SessionID == null ? string.Empty : userSession.SessionID;

                result = sqlHelper.ExecuteNonQuery(Command);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_delete_user_session");
                return 0;
            }
            return result;
        }

        public IEnumerable<Logontime> lastlogontime(string usercode)
        {
            List<Logontime> logontimelist = new List<Logontime>();
            try
            {
                DbCommand Command;
                IDataReader objReader;
                Command = sqlHelper.GetCommandObject("FRM_SP_LASTLOGIN_COUNT", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar));
                Command.Parameters[0].Value = usercode;
                Command.Parameters.Add(new SqlParameter("@language", SqlDbType.VarChar));
                Command.Parameters[1].Value = "en-GB";

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        Logontime logontime = new Logontime();
                        logontime.SESSIONLOGINTIME = Convert.ToString(objReader["SESSIONLOGINTIME"]);
                        logontime.INVALIDPWDATTEMPTCOUNT = Convert.ToString(objReader["INVALIDPWDATTEMPTCOUNT"]);
                        logontime.LASTINVALIDLOGINDATE = Convert.ToString(objReader["LASTINVALIDLOGINDATE"]);
                        logontime.USERPREVLOGGEDON = Convert.ToString(objReader["USERPREVLOGGEDON"]);
                        logontimelist.Add(logontime);

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_SP_LASTLOGIN_COUNT");
            }
            return logontimelist;

        }


        public int GetUserSession(string sessionID, string UserName)
        {
            int cnt = 0;
            try
            {

                DbCommand Command;

                Command = sqlHelper.GetCommandObject("frm_sp_get_User_ClearSession_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@sessionID", SqlDbType.VarChar));
                Command.Parameters[0].Value = sessionID == null ? string.Empty : sessionID;
                Command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar));
                Command.Parameters[1].Value = UserName == null ? string.Empty : UserName;


                cnt = (int)sqlHelper.ExecuteScalar(Command);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_User_ClearSession_details_netcore");
                throw new InvalidOperationException(ex.Message, ex);
            }
            return cnt;
        }



        public int GetUserStatus(string UserName)
        {
            int cnt = 0;
            try
            {
                DbCommand Command;
                Command = sqlHelper.GetCommandObject("frm_sp_get_User_Status_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar));
                Command.Parameters[0].Value = UserName;
                cnt = (int)sqlHelper.ExecuteScalar(Command);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_User_Status_details_netcore");
                throw new InvalidOperationException(ex.Message, ex);
            }
            return cnt;
        }

        public string GetSourceVersion()
        {
            string version = string.Empty;
            try
            {
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_Source_Version", CommandType.StoredProcedure);
                version = (string)sqlHelper.ExecuteScalar(Command);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_Source_Version");
            }
            return version;
        }
    }
}
