using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data.Common;
using System.Data;
using Entities.Error_Master;
using System.Data.SqlClient;
using OpenFinanceWebApi.NLogService;
using OpenFinanceWebApi.IServices;

namespace OpenFinanceWebApi.Services
{
    public class ErrorMasterService : IErrorMasterService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getDBConnection());
        private readonly NLogWebApiService _logger;
        public ErrorMasterService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public IEnumerable<ErrorMasterModel> GetDetails()
        {
            List<ErrorMasterModel> ErrorList = new List<ErrorMasterModel>();
            try
            {

                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_select_error_master", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ErrorList.Add(new ErrorMasterModel
                        {
                            Reject_Reason_Code = objReader["Reject_Reason_Code"].ToString(),
                            Reject_Type = objReader["Reject_Type"].ToString(),
                            Reject_Reason = objReader["Reject_Reason"].ToString(),
                            Active_Status = Convert.ToBoolean(objReader["Active_Status"].ToString())

                        });


                    }
                    return ErrorList;
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_select_error_master");
            }
            return ErrorList;
        }

        public ErrorMasterModel GetErrorIndDetails(string Id)
        {
            ErrorMasterModel objUser = new ErrorMasterModel();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_ind_error_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Reject_Reason_Code", SqlDbType.NVarChar));
                Command.Parameters[0].Value = Id;
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        objUser.Reject_Reason_Code = objReader["Reject_Reason_Code"].ToString();
                        objUser.Reject_Type = objReader["Reject_Type"].ToString();
                        objUser.Reject_Reason = objReader["Reject_Reason"].ToString();
                        objUser.Trxn_Name = objReader["Trxn_Name"].ToString();
                        objUser.Active_Status = Convert.ToBoolean(objReader["Active_Status"].ToString());
                        objUser.Error_Type = objReader["Error_Type"].ToString();
                        objUser.Accessibility = objReader["Accessibility"].ToString();
                    }
                }
                return objUser;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_ind_error_master");
            }
            return objUser;
        }

        public string AddErrorDetails(ErrorMasterModel error)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand Command = null;


                Command = sqlHelper.GetCommandObject("frm_sp_insert_error_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                Command.Parameters[0].Value = error.ID;

                Command.Parameters.Add(new SqlParameter("@Reject_Reason_Code", SqlDbType.VarChar));
                Command.Parameters[1].Value = error.Reject_Reason_Code;

                Command.Parameters.Add(new SqlParameter("@Reject_Type", SqlDbType.VarChar));
                Command.Parameters[2].Value = error.Reject_Type;

                Command.Parameters.Add(new SqlParameter("@Reject_Reason", SqlDbType.VarChar));
                Command.Parameters[3].Value = error.Reject_Reason;

                Command.Parameters.Add(new SqlParameter("@Trxn_Name", SqlDbType.VarChar));
                Command.Parameters[4].Value = error.Trxn_Name;

                Command.Parameters.Add(new SqlParameter("@Active_Status", SqlDbType.Bit));
                Command.Parameters[5].Value = error.Active_Status;

                Command.Parameters.Add(new SqlParameter("@ACTION", SqlDbType.VarChar));
                Command.Parameters[6].Value = error.ACTION;

                Command.Parameters.Add(new SqlParameter("@CREATEDBY", SqlDbType.VarChar));
                Command.Parameters[7].Value = error.CREATEDBY;

                Command.Parameters.Add(new SqlParameter("@Error_Type", SqlDbType.VarChar));
                Command.Parameters[8].Value = error.Error_Type;

                Command.Parameters.Add(new SqlParameter("@Accessibility", SqlDbType.VarChar));
                Command.Parameters[9].Value = error.Accessibility;


                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_insert_error_master");
                Output_Desc = ex.Message;
            }
            return Output_Desc;

        }

        public string EditErrorMaster(ErrorMasterModel error)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_Update_error_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Reject_Reason_Code", SqlDbType.VarChar));
                Command.Parameters[0].Value = error.Reject_Reason_Code;

                Command.Parameters.Add(new SqlParameter("@Reject_Type", SqlDbType.VarChar));
                Command.Parameters[1].Value = error.Reject_Type;

                Command.Parameters.Add(new SqlParameter("@Reject_Reason", SqlDbType.VarChar));
                Command.Parameters[2].Value = error.Reject_Reason;

                Command.Parameters.Add(new SqlParameter("@Trxn_Name", SqlDbType.VarChar));
                Command.Parameters[3].Value = error.Trxn_Name;

                Command.Parameters.Add(new SqlParameter("@Active_Status", SqlDbType.VarChar));
                Command.Parameters[4].Value = error.Active_Status;

                Command.Parameters.Add(new SqlParameter("@MODIFIEDBY", SqlDbType.VarChar));
                Command.Parameters[5].Value = error.MODIFIEDBY;

                Command.Parameters.Add(new SqlParameter("@ACTION", SqlDbType.VarChar));
                Command.Parameters[6].Value = error.ACTION;

                Command.Parameters.Add(new SqlParameter("@Error_Type", SqlDbType.VarChar));
                Command.Parameters[7].Value = error.Error_Type;

                Command.Parameters.Add(new SqlParameter("@Accessibility", SqlDbType.VarChar));
                Command.Parameters[8].Value = error.Accessibility;

                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_Update_error_master");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }

        public IEnumerable<ErrorMasterModel> GetErrorFilter(string Search_Error_Code)
        {
            List<ErrorMasterModel> errorMakers = new List<ErrorMasterModel>();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_filter_details_error_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Reject_Reason_Code", SqlDbType.VarChar));
                Command.Parameters[0].Value = Search_Error_Code;



                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                        errorMakers.Add(new ErrorMasterModel
                        {
                            Reject_Reason_Code = objReader["Reject_Reason_Code"].ToString(),
                            Reject_Type = objReader["Reject_Type"].ToString(),
                            Reject_Reason = objReader["Reject_Reason"].ToString(),
                            // Active_Status = Convert.ToBoolean(objReader["Active_Status"].ToString())

                        });
                }

                return errorMakers;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_filter_details_error_master");
            }
            return errorMakers;

        }
        public IEnumerable<ErrorMasterModel> GetErrorChecker()
        {
            List<ErrorMasterModel> errorList = new List<ErrorMasterModel>();

            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_error_master_check", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ErrorMasterModel objUser = new ErrorMasterModel();
                        objUser.ID = Convert.ToInt32(objReader["ID"].ToString());
                        objUser.Reject_Reason_Code = objReader["Reject_Reason_Code"].ToString();
                        objUser.Reject_Type = objReader["Reject_Type"].ToString();
                        objUser.Reject_Reason = objReader["Reject_Reason"].ToString();
                        objUser.Trxn_Name = objReader["Trxn_Name"].ToString();
                        objUser.Active_Status = Convert.ToBoolean(objReader["Active_Status"].ToString());
                        objUser.ACTION = objReader["ACTION"].ToString();
                        objUser.CREATEDBY = objReader["CREATEDBY"].ToString();
                        errorList.Add(objUser);
                    }

                }
                return errorList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_error_master_check");
            }
            return errorList;
        }
        public ErrorMasterModel GetCheckerIndErrorDetail(string Id)
        {
            ErrorMasterModel objUser = new ErrorMasterModel();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_ind_error_master_check", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Reject_Reason_Code", SqlDbType.VarChar));
                Command.Parameters[0].Value = Id;
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        objUser.ID = Convert.ToInt32(objReader["ID"].ToString());
                        objUser.Reject_Reason_Code = objReader["Reject_Reason_Code"].ToString();
                        objUser.Reject_Type = objReader["Reject_Type"].ToString();
                        objUser.Reject_Reason = objReader["Reject_Reason"].ToString();
                        objUser.Trxn_Name = objReader["Trxn_Name"].ToString();
                        objUser.Active_Status = Convert.ToBoolean(objReader["Active_Status"].ToString());
                        objUser.ACTION = objReader["ACTION"].ToString();
                        objUser.CREATEDBY = objReader["CREATEDBY"].ToString();
                        objUser.Error_Type = objReader["Error_Type"].ToString();
                        objUser.Accessibility = objReader["Accessibility"].ToString();

                    }

                }
                return objUser;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_ind_error_master_check");
            }
            return objUser;


        }
        public string DeleteErrorDetails(ErrorMasterModel error)
        {
            var OutputDesc = string.Empty;
            try
            {
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_delete_error_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Reject_Reason_Code", SqlDbType.VarChar));
                Command.Parameters[0].Value = error.Reject_Reason_Code;

                Command.Parameters.Add(new SqlParameter("@Reject_Type", SqlDbType.VarChar));
                Command.Parameters[1].Value = error.Reject_Type;

                Command.Parameters.Add(new SqlParameter("@Reject_Reason", SqlDbType.VarChar));
                Command.Parameters[2].Value = error.Reject_Reason;

                Command.Parameters.Add(new SqlParameter("@Trxn_Name", SqlDbType.VarChar));
                Command.Parameters[3].Value = error.Trxn_Name;

                Command.Parameters.Add(new SqlParameter("@Active_Status", SqlDbType.Bit));
                Command.Parameters[4].Value = error.Active_Status;

                Command.Parameters.Add(new SqlParameter("@CREATEDBY", SqlDbType.VarChar));
                Command.Parameters[5].Value = error.CREATEDBY;

                Command.Parameters.Add(new SqlParameter("@ACTION", SqlDbType.VarChar));
                Command.Parameters[6].Value = error.ACTION;
                Command.Parameters.Add(new SqlParameter("@ISDeleted", SqlDbType.Bit));
                Command.Parameters[7].Value = error.ISDeleted;

                SqlParameter prm1 = new SqlParameter("@OutputDesc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                OutputDesc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_delete_error_master");
                OutputDesc = ex.Message;
            }
            return OutputDesc;
        }
        public string ApproveOrRejectError(ErrorMasterModel error)
        {
            int result = 0;
            var Output_Desc = string.Empty;
            try
            {
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_error_master_check", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                Command.Parameters[0].Value = error.ID;

                Command.Parameters.Add(new SqlParameter("@Reject_Reason_Code", SqlDbType.VarChar));
                Command.Parameters[1].Value = error.Reject_Reason_Code;

                Command.Parameters.Add(new SqlParameter("@Reject_Type", SqlDbType.VarChar));
                Command.Parameters[2].Value = error.Reject_Type;

                Command.Parameters.Add(new SqlParameter("@Reject_Reason", SqlDbType.NVarChar));
                Command.Parameters[3].Value = error.Reject_Reason;

                Command.Parameters.Add(new SqlParameter("@Trxn_Name", SqlDbType.VarChar));
                Command.Parameters[4].Value = error.Trxn_Name;

                Command.Parameters.Add(new SqlParameter("@Active_Status", SqlDbType.Bit));
                Command.Parameters[5].Value = error.Active_Status;

                Command.Parameters.Add(new SqlParameter("@APPROVED_BY", SqlDbType.VarChar));
                Command.Parameters[6].Value = error.APPROVED_BY;

                Command.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.Bit));
                Command.Parameters[7].Value = error.IsApproved;

                Command.Parameters.Add(new SqlParameter("@IsRejected", SqlDbType.Bit));
                Command.Parameters[8].Value = error.IsRejected;

                Command.Parameters.Add(new SqlParameter("@ISDeleted", SqlDbType.Bit));
                Command.Parameters[9].Value = error.ISDeleted;

                Command.Parameters.Add(new SqlParameter("@Error_Type", SqlDbType.VarChar));
                Command.Parameters[10].Value = error.Error_Type;

                Command.Parameters.Add(new SqlParameter("@Accessibility", SqlDbType.VarChar));
                Command.Parameters[11].Value = error.Accessibility == null ? string.Empty : error.Accessibility;

                result = sqlHelper.ExecuteNonQuery(Command);
                if (result > 0)
                {
                    Output_Desc = "SUCCESS";
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_error_master_check");
            }
            return Output_Desc;
        }
        public IEnumerable<ErrorTypeModel> GetErrorList()
        {
            List<ErrorTypeModel> errorList = new List<ErrorTypeModel>();
            try
            {
                //List<ErrorTypeModel> errorList = new List<ErrorTypeModel>();

                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("ipp_sp_get_errorcode_typelist", CommandType.StoredProcedure);

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ErrorTypeModel objerror = new ErrorTypeModel();
                        objerror.Text = Convert.ToString(objReader["Text"]);
                        objerror.Value = Convert.ToString(objReader["Value"]);
                        errorList.Add(objerror);
                    }


                }
                //return errorList;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_get_errorcode_typelist");
                throw;
            }
            return errorList;
        }
        public IEnumerable<ErrorCode> GetErrorCheckList(string id)
        {
            List<ErrorCode> errorList = new List<ErrorCode>();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("ipp_sp_get_Ind_errorcode_type", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@General_List_Type", SqlDbType.VarChar));
                Command.Parameters[0].Value = id;


                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ErrorCode objError = new ErrorCode();
                        objError.General_List_Code = objReader["General_List_Code"].ToString();
                        objError.General_Desc_English = objReader["Value"].ToString();
                        errorList.Add(objError);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_get_Ind_errorcode_type");
            }
            return errorList;
        }

    }
}
