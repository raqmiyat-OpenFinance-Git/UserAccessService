using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Entities.Login;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using UserAccessService.Models;
using User = UserAccessService.Models.User;

namespace OpenFinanceWebApi.Services
{
    public class UserCreationService : IUserCreationService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public UserCreationService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public IEnumerable<RoleList> GetRoleLists()
        {
            List<RoleList> rolesList = new List<RoleList>();
            try
            {
                DbCommand? command = null;
                IDataReader? objReader = null;
                command = sqlHelper.GetCommandObject("frm_sp_get_usermaker_role_details_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {

                        rolesList.Add(new RoleList
                        {
                            Role_ID = Convert.ToInt32(objReader["ROLE_ID"]),
                            Role_Name = Convert.ToString(objReader["ROLE_NAME"])
                        });
                    }
                }
                return rolesList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_usermaker_role_details_netcore");
            }
            return rolesList;
        }
        public IEnumerable<ProductLists> GetProductLists()
        {
            List<ProductLists> rolesList = new List<ProductLists>();
            try
            {
                DbCommand? command = null;
                IDataReader? objReader = null;
                command = sqlHelper.GetCommandObject("frm_sp_get__products_list_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {

                        rolesList.Add(new ProductLists
                        {
                            Prodouct_ID = Convert.ToString(objReader["Product_ID"]),
                            Product_Name = Convert.ToString(objReader["Product_Name"])
                        });
                    }
                }
                return rolesList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get__products_list_netcore");
            }
            return rolesList;
        }
        public string AddUser(UserMaker postData)
        {
            var Output_Desc = string.Empty;
            try
            {

                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_insert_user_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_NAME", SqlDbType.VarChar));
                Command.Parameters[0].Value = postData.UserName == null ? string.Empty : postData.UserName;


                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_FULLNAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = postData.FirstName == null ? string.Empty : postData.FirstName;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_SHORTNAME", SqlDbType.VarChar));
                Command.Parameters[2].Value = postData.LastName == null ? string.Empty : postData.LastName;


                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_PASSWORD", SqlDbType.VarChar));
                Command.Parameters[3].Value = postData.Password == null ? string.Empty : postData.Password;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERSTATUS", SqlDbType.Bit));
                Command.Parameters[4].Value = postData.USERATTRIBS_USERSTATUS;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_EMAILID", SqlDbType.VarChar));
                Command.Parameters[5].Value = postData.EmailAddress == null ? string.Empty : postData.EmailAddress;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_MOBILE", SqlDbType.VarChar));
                Command.Parameters[6].Value = postData.MobileNo == null ? string.Empty : postData.MobileNo;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_MENU_TYPE", SqlDbType.Int));
                Command.Parameters[7].Value = 3;

                Command.Parameters.Add(new SqlParameter("@Actionby", SqlDbType.VarChar));
                Command.Parameters[8].Value = postData.Actionby;

                Command.Parameters.Add(new SqlParameter("@Roles", SqlDbType.VarChar, 1000));
                Command.Parameters[9].Value = postData.Roles;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_IsDelete", SqlDbType.Bit));
                Command.Parameters[10].Value = 0;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Checker", SqlDbType.Bit));
                Command.Parameters[11].Value = postData.IsCheckerUser;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Checker_Business", SqlDbType.Bit));
                Command.Parameters[12].Value = postData.IsBusinessApprovalChecker;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Pass_Never_Expires", SqlDbType.Bit));
                Command.Parameters[13].Value = postData.PasswordNeverExpired;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Business_Hours", SqlDbType.Time));
                Command.Parameters[14].Value = postData.BusinessHours;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_PRODUCT_ID", SqlDbType.NVarChar));
                Command.Parameters[15].Value = postData.Product_ID;


                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_insert_user_details_netcore");
            }
            return Output_Desc;
        }

        public string UpdateUser(UserMaker postData)
        {
            var Output_Desc = string.Empty;
            try
            {

                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_update_user_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERID", SqlDbType.VarChar));
                Command.Parameters[0].Value = postData.USER_ID;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_NAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = postData.UserName == null ? string.Empty : postData.UserName;


                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_FULLNAME", SqlDbType.VarChar));
                Command.Parameters[2].Value = postData.FirstName == null ? string.Empty : postData.FirstName;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_SHORTNAME", SqlDbType.VarChar));
                Command.Parameters[3].Value = postData.LastName == null ? string.Empty : postData.LastName;


                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_PASSWORD", SqlDbType.VarChar));
                Command.Parameters[4].Value = postData.Password == null ? string.Empty : postData.Password;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERSTATUS", SqlDbType.Bit));
                Command.Parameters[5].Value = postData.USERATTRIBS_USERSTATUS;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_EMAILID", SqlDbType.VarChar));
                Command.Parameters[6].Value = postData.EmailAddress == null ? string.Empty : postData.EmailAddress;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_MOBILE", SqlDbType.VarChar));
                Command.Parameters[7].Value = postData.MobileNo == null ? string.Empty : postData.MobileNo;

                Command.Parameters.Add(new SqlParameter("@Actionby", SqlDbType.VarChar));
                Command.Parameters[8].Value = postData.Actionby;

                Command.Parameters.Add(new SqlParameter("@Roles", SqlDbType.VarChar, 1000));
                Command.Parameters[9].Value = postData.Roles;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Checker", SqlDbType.Bit));
                Command.Parameters[10].Value = postData.IsCheckerUser;

                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Checker_Business", SqlDbType.Bit));
                Command.Parameters[11].Value = postData.IsBusinessApprovalChecker;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Pass_Never_Expires", SqlDbType.Bit));
                Command.Parameters[12].Value = postData.PasswordNeverExpired;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Business_Hours", SqlDbType.Time));
                Command.Parameters[13].Value = postData.BusinessHours;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_PRODUCT_ID", SqlDbType.NVarChar));
                Command.Parameters[14].Value = postData.Product_ID;

                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_update_user_details_netcore");
            }
            return Output_Desc;
        }
        public string DeleteUser(UserMaker postData)
        {
            var Output_Desc = string.Empty;
            try
            {

                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_delete_user_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERID", SqlDbType.VarChar));
                Command.Parameters[0].Value = postData.USER_ID;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_NAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = postData.UserName == null ? string.Empty : postData.UserName;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_FULLNAME", SqlDbType.VarChar));
                Command.Parameters[2].Value = postData.FirstName == null ? string.Empty : postData.FirstName;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_SHORTNAME", SqlDbType.VarChar));
                Command.Parameters[3].Value = postData.LastName == null ? string.Empty : postData.LastName;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_PASSWORD", SqlDbType.VarChar));
                Command.Parameters[4].Value = postData.Password == null ? string.Empty : postData.Password;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERSTATUS", SqlDbType.Bit));
                Command.Parameters[5].Value = postData.USERATTRIBS_USERSTATUS;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_EMAILID", SqlDbType.VarChar));
                Command.Parameters[6].Value = postData.EmailAddress == null ? string.Empty : postData.EmailAddress;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_MOBILE", SqlDbType.VarChar));
                Command.Parameters[7].Value = postData.MobileNo == null ? string.Empty : postData.MobileNo;
                Command.Parameters.Add(new SqlParameter("@Actionby", SqlDbType.VarChar));
                Command.Parameters[8].Value = postData.Actionby;
                Command.Parameters.Add(new SqlParameter("@Roles", SqlDbType.VarChar, 1000));
                Command.Parameters[9].Value = postData.Roles;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Checker", SqlDbType.Bit));
                Command.Parameters[10].Value = postData.IsCheckerUser;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Checker_Business", SqlDbType.Bit));
                Command.Parameters[11].Value = postData.IsBusinessApprovalChecker;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Pass_Never_Expires", SqlDbType.Bit));
                Command.Parameters[12].Value = postData.PasswordNeverExpired;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Business_Hours", SqlDbType.Time));
                Command.Parameters[13].Value = postData.BusinessHours;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_PRODUCT_ID", SqlDbType.NVarChar));
                Command.Parameters[14].Value = postData.Product_ID;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_IsDelete", SqlDbType.Bit));
                Command.Parameters[15].Value = true;
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.NVarChar));
                Command.Parameters[16].Value = "DELETE";
                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_delete_user_details_netcore");
            }
            return Output_Desc;
        }

        public User GetUserProfile(string userCode)
        {
            var login = new User();
            try
            {
                if (string.IsNullOrWhiteSpace(userCode))
                {
                    _logger.Warn("GetLogin called with empty userCode");
                    return login;
                }

                IDataReader objReader;
                DbCommand command;

                command = sqlHelper.GetCommandObject("frm_sp_GetUserProfile", CommandType.StoredProcedure);
                command.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 50));
                command.Parameters[0].Value = userCode.Trim();

                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    if (objReader != null && objReader.Read())
                    {
                        login = new User
                        {
                            UserCode = objReader["USERATTRIBS_NAME"] == DBNull.Value ? string.Empty : Convert.ToString(objReader["USERATTRIBS_NAME"]),
                            FullName = objReader["USERATTRIBS_FULLNAME"] == DBNull.Value ? string.Empty : Convert.ToString(objReader["USERATTRIBS_FULLNAME"]),
                            ProfileImage = objReader["USERATTRIBS_IMAGE"] == DBNull.Value ? null : (byte[])objReader["USERATTRIBS_IMAGE"],
                        };

                        // Log successful retrieval
                        _logger.Info("User profile retrieved for: {UserCode}" + userCode);
                    }
                    else
                    {
                        _logger.Warn("No user found for userCode: {UserCode}" + userCode);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                _logger.Error(sqlEx, "Database error in frm_sp_GetUserProfile for user: {UserCode}" + userCode);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error in frm_sp_GetUserProfile for user: {UserCode}" + userCode);
                throw;
            }
            return login;
        }
        public string UpdateUserProfile(User user)
        {
            string outputDesc = string.Empty;
            bool success = false;
            try
            {
                DbCommand command = sqlHelper.GetCommandObject("frm_sp_UpdateUserProfile", CommandType.StoredProcedure);

                // Create parameters and assign values
                SqlParameter userCodeParam = new SqlParameter("@UserCode", SqlDbType.NVarChar, 50)
                {
                    Value = user.UserCode
                };

                SqlParameter fullNameParam = new SqlParameter("@FullName", SqlDbType.NVarChar, 100)
                {
                    Value = string.IsNullOrEmpty(user.FullName) ? (object)DBNull.Value : user.FullName
                };

                SqlParameter profileImageParam = new SqlParameter("@ProfileImage", SqlDbType.VarBinary, -1)
                {
                    Value = user.ProfileImage ?? (object)DBNull.Value
                };
                var rowsParam = new SqlParameter("@RowsAffected", SqlDbType.Int) { Direction = ParameterDirection.Output };
                
                // Add parameters to command
                command.Parameters.Add(userCodeParam);
                command.Parameters.Add(fullNameParam);
                command.Parameters.Add(profileImageParam);
                command.Parameters.Add(rowsParam);
                sqlHelper.ExecuteNonQuery(command);

                int rowsAffected = (int)rowsParam.Value;
                success = rowsAffected > 0;

                if (success)
                {
                    outputDesc="SUCCESS";
                    _logger.Info("User profile updated successfully for: {UserCode}" + user.UserCode);
                }
                else
                {
                    outputDesc= "Update failed - user not found";
                    _logger.Warn("No rows affected when updating profile for: {UserCode}" + user.UserCode);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in frm_sp_UpdateUserProfile for user: {UserCode}" + user.UserCode);
                throw;
            }
            return outputDesc;
        }
        public string RemoveProfileImage(string userCode)
        {
            string outputDesc = string.Empty;
            bool success = false;
            try
            {
                DbCommand command;

                command = sqlHelper.GetCommandObject("frm_sp_RemoveProfileImage", CommandType.StoredProcedure);
                command.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar));
                command.Parameters[0].Value = userCode;

                int rowsAffected = sqlHelper.ExecuteNonQuery(command);
                success = rowsAffected > 0;

                if (success)
                {
                    outputDesc = "SUCCESS";
                    _logger.Info("Profile image removed successfully for: {UserCode}" + userCode);
                }
                else
                {
                    outputDesc = "Removal failed - user not found";
                    _logger.Warn("No rows affected when removing profile image for: {UserCode}" + userCode);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in frm_sp_RemoveProfileImage for user: {UserCode}" + userCode);
                throw;
            }
            return outputDesc; // Fixed: return outputDesc instead of success
        }

        public IEnumerable<UserMaker> GetUserLists()
        {
            List<UserMaker> userMakerList = new List<UserMaker>();
            try
            {
                DbCommand? command = null;
                IDataReader? objReader = null;
                command = sqlHelper.GetCommandObject("frm_sp_get_user_details_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {

                        userMakerList.Add(new UserMaker
                        {
                            USER_ID = Convert.ToInt32(objReader["USERATTRIBS_USERID"]),
                            UserName = Convert.ToString(objReader["USERATTRIBS_NAME"]),
                            FirstName = Convert.ToString(objReader["USERATTRIBS_FULLNAME"]),
                            LastName = objReader["USERATTRIBS_SHORTNAME"].ToString(),
                            Password = objReader["USERATTRIBS_PASSWORD"].ToString(),
                            USERATTRIBS_USERSTATUS = Convert.ToBoolean(objReader["USERATTRIBS_USERSTATUS"].ToString()),
                            Status = Convert.ToString(objReader["USERSTATUS"]),
                            EmailAddress = objReader["USERATTRIBS_EMAILID"].ToString(),
                            MobileNo = objReader["USERATTRIBS_MOBILE"].ToString(),
                            USERATTRIBS_IsDelete = Convert.ToBoolean(objReader["USERATTRIBS_IsDelete"].ToString()),
                            IsCheckerUser = Convert.ToBoolean(objReader["USERATTRIBS_Checker"]),
                            Product_ID = Convert.ToString(objReader["USERATTRIBS_PRODUCT_ID"]),
                            IsBusinessApprovalChecker = Convert.ToBoolean(objReader["USERATTRIBS_Checker_Business"]),
                            PasswordNeverExpired = Convert.ToBoolean(objReader["USERATTRIBS_Pass_Never_Expires"]),
                            BusinessHours = Convert.ToString(objReader["USERATTRIBS_Business_Hours"]),
                        });
                    }
                }
                return userMakerList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_user_details_netcore");
            }
            return userMakerList;
        }

        public IEnumerable<UserMaker> SearchUserLists(string UserName)
        {
            List<UserMaker> userMakerList = new List<UserMaker>();
            try
            {
                DbCommand? command = null;
                IDataReader? objReader = null;
                command = sqlHelper.GetCommandObject("frm_sp_get_search_details_netcore", CommandType.StoredProcedure);
                command.Parameters.Add(new SqlParameter("@USERATTRIBS_NAME", SqlDbType.NVarChar));
                command.Parameters[0].Value = UserName;
                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {

                        userMakerList.Add(new UserMaker
                        {
                            USER_ID = Convert.ToInt32(objReader["USERATTRIBS_USERID"]),
                            UserName = Convert.ToString(objReader["USERATTRIBS_NAME"]),
                            FirstName = Convert.ToString(objReader["USERATTRIBS_FULLNAME"]),
                            LastName = objReader["USERATTRIBS_SHORTNAME"].ToString(),
                            Password = objReader["USERATTRIBS_PASSWORD"].ToString(),
                            USERATTRIBS_USERSTATUS = Convert.ToBoolean(objReader["USERATTRIBS_USERSTATUS"].ToString()),
                            Status = Convert.ToString(objReader["USERSTATUS"]),
                            EmailAddress = objReader["USERATTRIBS_EMAILID"].ToString(),
                            MobileNo = objReader["USERATTRIBS_MOBILE"].ToString(),
                            USERATTRIBS_IsDelete = Convert.ToBoolean(objReader["USERATTRIBS_IsDelete"].ToString()),
                            IsCheckerUser = Convert.ToBoolean(objReader["USERATTRIBS_Checker"]),
                            Product_ID = Convert.ToString(objReader["USERATTRIBS_PRODUCT_ID"]),
                            IsBusinessApprovalChecker = Convert.ToBoolean(objReader["USERATTRIBS_Checker_Business"]),
                            PasswordNeverExpired = Convert.ToBoolean(objReader["USERATTRIBS_Pass_Never_Expires"]),
                            BusinessHours = Convert.ToString(objReader["USERATTRIBS_Business_Hours"]),
                        });
                    }
                }
                return userMakerList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_search_details_netcore");
            }
            return userMakerList;
        }


        public UserMaker GetIndividualUserList(int Id)
        {
            UserMaker userMakerList = new UserMaker();
            try
            {
                DbCommand? command = null;
                IDataReader? objReader = null;
                command = sqlHelper.GetCommandObject("frm_sp_get_individual_user_details_netcore", CommandType.StoredProcedure);
                command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERID", SqlDbType.Int));
                command.Parameters[0].Value = Id;
                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {

                        userMakerList.USER_ID = Convert.ToInt32(objReader["USERATTRIBS_USERID"]);
                        userMakerList.UserName = Convert.ToString(objReader["USERATTRIBS_NAME"]);
                        userMakerList.FirstName = Convert.ToString(objReader["USERATTRIBS_FULLNAME"]);
                        userMakerList.LastName = objReader["USERATTRIBS_SHORTNAME"].ToString();
                        userMakerList.Password = objReader["USERATTRIBS_PASSWORD"].ToString();
                        userMakerList.USERATTRIBS_USERSTATUS = Convert.ToBoolean(objReader["USERATTRIBS_USERSTATUS"].ToString());
                        userMakerList.Status = Convert.ToString(objReader["USERSTATUS"]);
                        userMakerList.EmailAddress = objReader["USERATTRIBS_EMAILID"].ToString();
                        userMakerList.MobileNo = objReader["USERATTRIBS_MOBILE"].ToString();
                        userMakerList.USERATTRIBS_IsDelete = Convert.ToBoolean(objReader["USERATTRIBS_IsDelete"].ToString());
                        userMakerList.Product_ID = Convert.ToString(objReader["USERATTRIBS_PRODUCT_ID"]);
                        userMakerList.IsCheckerUser = Convert.ToBoolean(objReader["USERATTRIBS_Checker"]);
                        userMakerList.IsBusinessApprovalChecker = Convert.ToBoolean(objReader["USERATTRIBS_Checker_Business"]);
                        userMakerList.PasswordNeverExpired = Convert.ToBoolean(objReader["USERATTRIBS_Pass_Never_Expires"]);
                        userMakerList.BusinessHours = Convert.ToString(objReader["USERATTRIBS_Business_Hours"]);


                    }
                }
                return userMakerList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_individual_user_details_netcore");
            }
            return userMakerList;
        }

        public IEnumerable<RoleList> GetRoleByUserCode(int Id)
        {
            List<RoleList> rolesList = new List<RoleList>();
            try
            {
                DbCommand command = null;
                IDataReader objReader = null;
                command = sqlHelper.GetCommandObject("frm_sp_get_User_role_details_netcore", CommandType.StoredProcedure);
                command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERID", SqlDbType.Int));
                command.Parameters[0].Value = Id;
                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {

                        rolesList.Add(new RoleList
                        {
                            Role_ID = Convert.ToInt32(objReader["ROLE_ID"]),
                            Role_Name = Convert.ToString(objReader["ROLE_NAME"])
                        });
                    }
                }
                return rolesList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_User_role_details_netcore");
            }
            return rolesList;
        }


        //Checker
        public IEnumerable<UserMaker> GetCheckerLists()
        {
            List<UserMaker> userMakerList = new List<UserMaker>();
            try
            {
                DbCommand command = null;
                IDataReader objReader = null;
                command = sqlHelper.GetCommandObject("frm_sp_get_user_Checker_details_netcore", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {

                        userMakerList.Add(new UserMaker
                        {
                            USER_ID = Convert.ToInt32(objReader["USERATTRIBS_USERID"]),
                            UserName = Convert.ToString(objReader["USERATTRIBS_NAME"]),
                            FirstName = Convert.ToString(objReader["USERATTRIBS_FULLNAME"]),
                            LastName = objReader["USERATTRIBS_SHORTNAME"].ToString(),
                            Password = objReader["USERATTRIBS_PASSWORD"].ToString(),
                            USERATTRIBS_USERSTATUS = Convert.ToBoolean(objReader["USERATTRIBS_USERSTATUS"]),
                            Product_ID = Convert.ToString(objReader["USERATTRIBS_PRODUCT_ID"]),
                            Created_By = Convert.ToString(objReader["CREATED_BY"]),
                            ActionType = Convert.ToString(objReader["ACTION"]),
                            Created_On = Convert.ToDateTime(objReader["CREATED_ON"]).ToString("dd/MM/yyyy"),
                            EmailAddress = objReader["USERATTRIBS_EMAILID"].ToString(),
                            MobileNo = objReader["USERATTRIBS_MOBILE"].ToString(),
                            USERATTRIBS_IsDelete = Convert.ToBoolean(objReader["USERATTRIBS_IsDelete"]),
                            IsCheckerUser = Convert.ToBoolean(objReader["USERATTRIBS_Checker"]),
                            IsBusinessApprovalChecker = Convert.ToBoolean(objReader["USERATTRIBS_Checker_Business"]),
                            PasswordNeverExpired = Convert.ToBoolean(objReader["USERATTRIBS_Pass_Never_Expires"]),
                            BusinessHours = Convert.ToString(objReader["USERATTRIBS_Business_Hours"]),

                        });
                    }
                }
                return userMakerList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_user_Checker_details_netcore");
            }
            return userMakerList;
        }


        public UserMaker GetIndividualCheck(int Id)
        {
            UserMaker userMakerList = new UserMaker();
            try
            {
                DbCommand command = null;
                IDataReader objReader = null;
                command = sqlHelper.GetCommandObject("frm_sp_get_individual_user_Checker_details_netcore", CommandType.StoredProcedure);
                command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERID", SqlDbType.Int));
                command.Parameters[0].Value = Id;
                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {

                        userMakerList.USER_ID = Convert.ToInt32(objReader["USERATTRIBS_USERID"]);
                        userMakerList.UserName = Convert.ToString(objReader["USERATTRIBS_NAME"]);
                        userMakerList.FirstName = Convert.ToString(objReader["USERATTRIBS_FULLNAME"]);
                        userMakerList.LastName = objReader["USERATTRIBS_SHORTNAME"].ToString();
                        userMakerList.Password = objReader["USERATTRIBS_PASSWORD"].ToString();
                        userMakerList.USERATTRIBS_USERSTATUS = Convert.ToBoolean(objReader["USERATTRIBS_USERSTATUS"].ToString());
                        userMakerList.EmailAddress = objReader["USERATTRIBS_EMAILID"].ToString();
                        userMakerList.MobileNo = objReader["USERATTRIBS_MOBILE"].ToString();
                        userMakerList.USERATTRIBS_IsDelete = Convert.ToBoolean(objReader["USERATTRIBS_IsDelete"].ToString());
                        userMakerList.Roles = objReader["Roles"].ToString();
                        userMakerList.Product_ID = Convert.ToString(objReader["USERATTRIBS_PRODUCT_ID"]);

                        userMakerList.IsCheckerUser = Convert.ToBoolean(objReader["USERATTRIBS_Checker"]);
                        userMakerList.IsBusinessApprovalChecker = Convert.ToBoolean(objReader["USERATTRIBS_Checker_Business"]);
                        userMakerList.PasswordNeverExpired = Convert.ToBoolean(objReader["USERATTRIBS_Pass_Never_Expires"]);
                        userMakerList.BusinessHours = Convert.ToString(objReader["USERATTRIBS_Business_Hours"]);


                    }
                }
                return userMakerList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_individual_user_Checker_details_netcore");
            }
            return userMakerList;
        }

        public IEnumerable<UserMaker> SearchCheckUserLists(string UserName)
        {
            List<UserMaker> userMakerList = new List<UserMaker>();
            try
            {
                DbCommand? command = null;
                IDataReader? objReader = null;
                command = sqlHelper.GetCommandObject("frm_sp_get_search_Check_details_netcore", CommandType.StoredProcedure);
                command.Parameters.Add(new SqlParameter("@USERATTRIBS_NAME", SqlDbType.NVarChar));
                command.Parameters[0].Value = UserName;
                using (objReader = sqlHelper.ExecuteDataReader(command))
                {
                    while (objReader.Read())
                    {

                        userMakerList.Add(new UserMaker
                        {
                            USER_ID = Convert.ToInt32(objReader["USERATTRIBS_USERID"]),
                            UserName = Convert.ToString(objReader["USERATTRIBS_NAME"]),
                            FirstName = Convert.ToString(objReader["USERATTRIBS_FULLNAME"]),
                            LastName = objReader["USERATTRIBS_SHORTNAME"].ToString(),
                            Password = objReader["USERATTRIBS_PASSWORD"].ToString(),
                            USERATTRIBS_USERSTATUS = Convert.ToBoolean(objReader["USERATTRIBS_USERSTATUS"]),
                            Product_ID = Convert.ToString(objReader["USERATTRIBS_PRODUCT_ID"]),
                            Created_By = Convert.ToString(objReader["CREATED_BY"]),
                            ActionType = Convert.ToString(objReader["ACTION"]),
                            Created_On = Convert.ToDateTime(objReader["CREATED_ON"]).ToString("dd/MM/yyyy"),
                            EmailAddress = objReader["USERATTRIBS_EMAILID"].ToString(),
                            MobileNo = objReader["USERATTRIBS_MOBILE"].ToString(),
                            USERATTRIBS_IsDelete = Convert.ToBoolean(objReader["USERATTRIBS_IsDelete"]),
                            IsCheckerUser = Convert.ToBoolean(objReader["USERATTRIBS_Checker"]),
                            IsBusinessApprovalChecker = Convert.ToBoolean(objReader["USERATTRIBS_Checker_Business"]),
                            PasswordNeverExpired = Convert.ToBoolean(objReader["USERATTRIBS_Pass_Never_Expires"]),
                            BusinessHours = Convert.ToString(objReader["USERATTRIBS_Business_Hours"]),
                        });
                    }
                }
                return userMakerList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_search_details_netcore");
            }
            return userMakerList;
        }
        public string Approve(UserMaker postData)
        {
            var Output_Desc = string.Empty;
            try
            {

                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_update_user_Checker_details_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_NAME", SqlDbType.VarChar));
                Command.Parameters[0].Value = postData.UserName == null ? string.Empty : postData.UserName;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_FULLNAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = postData.FirstName == null ? string.Empty : postData.FirstName;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_SHORTNAME", SqlDbType.VarChar));
                Command.Parameters[2].Value = postData.LastName == null ? string.Empty : postData.LastName;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_PASSWORD", SqlDbType.VarChar));
                Command.Parameters[3].Value = postData.Password == null ? string.Empty : postData.Password;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERSTATUS", SqlDbType.Bit));
                Command.Parameters[4].Value = postData.USERATTRIBS_USERSTATUS;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_EMAILID", SqlDbType.VarChar));
                Command.Parameters[5].Value = postData.EmailAddress == null ? string.Empty : postData.EmailAddress;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_MOBILE", SqlDbType.VarChar));
                Command.Parameters[6].Value = postData.MobileNo == null ? string.Empty : postData.MobileNo;
                Command.Parameters.Add(new SqlParameter("@Approvedby", SqlDbType.VarChar));
                Command.Parameters[7].Value = postData.Actionby;
                Command.Parameters.Add(new SqlParameter("@Roles", SqlDbType.VarChar, 1000));
                Command.Parameters[8].Value = postData.Roles;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_IsDelete", SqlDbType.Bit));
                Command.Parameters[9].Value = postData.USERATTRIBS_IsDelete;
                Command.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.NVarChar));
                Command.Parameters[10].Value = postData.IsApproved;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_USERID", SqlDbType.VarChar));
                Command.Parameters[11].Value = postData.USER_ID;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Checker", SqlDbType.Bit));
                Command.Parameters[12].Value = postData.IsCheckerUser;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Checker_Business", SqlDbType.Bit));
                Command.Parameters[13].Value = postData.IsBusinessApprovalChecker;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Pass_Never_Expires", SqlDbType.Bit));
                Command.Parameters[14].Value = postData.PasswordNeverExpired;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_Business_Hours", SqlDbType.Time));
                Command.Parameters[15].Value = postData.BusinessHours;
                Command.Parameters.Add(new SqlParameter("@USERATTRIBS_PRODUCT_ID", SqlDbType.NVarChar));
                Command.Parameters[16].Value = postData.Product_ID;
                int i = sqlHelper.ExecuteNonQuery(Command);
                if (i > 0)
                {
                    Output_Desc = "SUCCESS";
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_update_user_Checker_details_netcore");
            }
            return Output_Desc;
        }

    }
}
