using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Entities.User;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenFinanceWebApi.IServices
{
    public class ChangePasswordService : IChangePasswordService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public ChangePasswordService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public bool UpdatePassword(ChangePassword changePassword)
        {
            //bool result = false;
            try
            {
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_update_user_password_netcore", CommandType.StoredProcedure);

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERID", SqlDbType.VarChar));
                Command.Parameters[0].Value = changePassword.UserID;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_NAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = changePassword.UserCode;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_PASSWORD", SqlDbType.VarChar));
                Command.Parameters[2].Value = changePassword.UserPasswordNew;

                int i = sqlHelper.ExecuteNonQuery(Command);

                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_update_user_password_netcore");
                throw;
            }
        }

        public string UpdatePasswordHistory(ChangePassword changePassword)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_user_pwdarchieve_netcore", CommandType.StoredProcedure);

                Command.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar));
                Command.Parameters[0].Value = changePassword.UserCode;

                Command.Parameters.Add(new SqlParameter("@language", SqlDbType.VarChar));
                Command.Parameters[1].Value = "en-GB";

                Command.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar));
                Command.Parameters[2].Value = changePassword.UserPassword;

                Command.Parameters.Add(new SqlParameter("@UserPasswordNew", SqlDbType.VarChar));
                Command.Parameters[3].Value = changePassword.UserPasswordNew;

                SqlParameter prm1 = new SqlParameter("@PwdStatus", SqlDbType.VarChar, 256);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                SqlParameter prm2 = new SqlParameter("@PwdAgeFlag", SqlDbType.VarChar, 256);
                prm2.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm2);

                int i = sqlHelper.ExecuteNonQuery(Command);

                string pwdStatus = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
                string pwdAgeFlag = prm2.Value == null ? string.Empty : Convert.ToString(prm2.Value);
                Output_Desc = string.Format("{0}-{1}", pwdStatus, pwdAgeFlag);

                //if (i >= 1)
                //	return true;
                //else
                //	return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_user_pwdarchieve_netcore");
                Output_Desc = ex.Message;
            }

            return Output_Desc;
        }

    }
}
