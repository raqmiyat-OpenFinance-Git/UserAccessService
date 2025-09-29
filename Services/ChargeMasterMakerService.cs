using Entities.Master;
using Raqmiyat.Infrastructure.Data;
using System.Data.Common;
using System.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data.SqlClient;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Services
{
    public class ChargeMasterMakerService : IChargeMasterMakerService

    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getDBConnection());
        private readonly NLogWebApiService _logger;
        public ChargeMasterMakerService(NLogWebApiService logger)
        {
            _logger = logger;
        }

        public string Addcharge(ChargeMasterMakerModel user)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_Insert_Details_Charge_Master_Maker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@SegmentID", SqlDbType.Int));
                Command.Parameters[0].Value = user.SegmentID;
                Command.Parameters.Add(new SqlParameter("@SegmentName", SqlDbType.VarChar));
                Command.Parameters[1].Value = user.SegmentName;
                Command.Parameters.Add(new SqlParameter("@TransactionType", SqlDbType.VarChar));
                Command.Parameters[2].Value = user.general_list_id == null ? string.Empty : user.general_list_id;
                Command.Parameters.Add(new SqlParameter("@OutwardChargesAmount", SqlDbType.VarChar));
                Command.Parameters[3].Value = user.Outward_Charges_Amount;
                Command.Parameters.Add(new SqlParameter("@InwardChargesAmount", SqlDbType.VarChar));
                Command.Parameters[4].Value = user.Inward_Charges_Amount;
                Command.Parameters.Add(new SqlParameter("@ChargesStatus", SqlDbType.VarChar));
                Command.Parameters[5].Value = user.ChargesStatus == null ? string.Empty : user.ChargesStatus;
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[6].Value = "INSERT";
                Command.Parameters.Add(new SqlParameter("@MsgType", SqlDbType.VarChar));
                Command.Parameters[7].Value = user.Msg_Type == null ? string.Empty : user.Msg_Type;
                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);
                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_Insert_Details_Charge_Master_Maker");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }

        public string ChargeApproveOrReject(ChargeMasterMakerModel CheckerApprRej)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_Approve_Reject_Charge_Master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@SegmentID", SqlDbType.Int));
                Command.Parameters[0].Value = CheckerApprRej.SegmentID;
                Command.Parameters.Add(new SqlParameter("@SegmentName", SqlDbType.VarChar));
                Command.Parameters[1].Value = CheckerApprRej.SegmentName;
                Command.Parameters.Add(new SqlParameter("@TransactionType", SqlDbType.VarChar));
                Command.Parameters[2].Value = CheckerApprRej.TransactionType;
                Command.Parameters.Add(new SqlParameter("@OutwardChargesAmount", SqlDbType.VarChar));
                Command.Parameters[3].Value = CheckerApprRej.Outward_Charges_Amount;
                Command.Parameters.Add(new SqlParameter("@InwardChargesAmount", SqlDbType.VarChar));
                Command.Parameters[4].Value = CheckerApprRej.Inward_Charges_Amount;
                Command.Parameters.Add(new SqlParameter("@ChargesStatus", SqlDbType.VarChar));
                Command.Parameters[5].Value = CheckerApprRej.ChargesStatus == null ? string.Empty : CheckerApprRej.ChargesStatus;
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[6].Value = CheckerApprRej.action;
                Command.Parameters.Add(new SqlParameter("@Actionby", SqlDbType.VarChar));
                Command.Parameters[7].Value = CheckerApprRej.ActionBy;
                Command.Parameters.Add(new SqlParameter("@MsgType", SqlDbType.VarChar));
                Command.Parameters[8].Value = CheckerApprRej.Msg_Type;
                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);
                int i = sqlHelper.ExecuteNonQuery(Command);
                if (i > 0)
                {
                    Output_Desc = "SUCCESS";
                }
                //Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_Approve_Reject_Charge_Master");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }

        public IEnumerable<ChargeMasterMakerModel> ChargeCheckerDetail()
        {
            List<ChargeMasterMakerModel> List = new List<ChargeMasterMakerModel>();


            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_details_Charge_MASTER_Checker", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ChargeMasterMakerModel objUser = new ChargeMasterMakerModel();
                        objUser.SegmentID = objReader["SegmentID"].ToString();
                        objUser.SegmentName = objReader["SegmentName"].ToString();
                        objUser.TransactionType = objReader["TransactionType"].ToString();
                        objUser.Outward_Charges_Amount = objReader["OutwardChargesAmount"].ToString();
                        objUser.Inward_Charges_Amount = objReader["InwardChargesAmount"].ToString();
                        objUser.ChargesStatus = objReader["ChargesStatus"].ToString();
                        objUser.SegID = Convert.ToInt32(objReader["SegID"].ToString());
                        objUser.action = objReader["Action"].ToString();
                        objUser.IsDeleted = Convert.ToBoolean(objReader["IsDeleted"].ToString());
                        List.Add(objUser);

                    }


                }
                return List;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_details_Charge_MASTER_Checker");
            }
            return List;
        }

        public string DeleteCharge(ChargeMasterMakerModel model)
        {
            var Output_Desc = string.Empty;

            try
            {
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("FRM_DELETE_Charge_Master_Maker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@SegmentID", SqlDbType.Int));
                Command.Parameters[0].Value = model.SegmentID;

                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_DELETE_Charge_Master_Maker");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }

        public string EditMaster(ChargeMasterMakerModel user)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_Insert_Details_Charge_Master_Maker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@SegmentID", SqlDbType.Int));
                Command.Parameters[0].Value = user.SegmentID;
                Command.Parameters.Add(new SqlParameter("@SegmentName", SqlDbType.VarChar));
                Command.Parameters[1].Value = user.SegmentName;
                Command.Parameters.Add(new SqlParameter("@TransactionType", SqlDbType.VarChar));
                Command.Parameters[2].Value = user.general_list_id;
                Command.Parameters.Add(new SqlParameter("@OutwardChargesAmount", SqlDbType.VarChar));
                Command.Parameters[3].Value = user.Outward_Charges_Amount;
                Command.Parameters.Add(new SqlParameter("@InwardChargesAmount", SqlDbType.VarChar));
                Command.Parameters[4].Value = user.Inward_Charges_Amount;
                Command.Parameters.Add(new SqlParameter("@ChargesStatus", SqlDbType.VarChar));
                Command.Parameters[5].Value = user.ChargesStatus == null ? string.Empty : user.ChargesStatus;
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[6].Value = "UPDATE";
                Command.Parameters.Add(new SqlParameter("@MsgType", SqlDbType.VarChar));
                Command.Parameters[7].Value = user.Msg_Type;
                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);
                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_Insert_Details_Charge_Master_Maker");

                Output_Desc = ex.Message;
            }
            return Output_Desc;

        }

        public ChargeMasterMakerModel GetCheckIndDetails(string Id)
        {
            throw new NotImplementedException();
        }

        public ChargeMasterMakerModel GetIndDetails(string SegmentID)
        {
            ChargeMasterMakerModel checkmaster = new ChargeMasterMakerModel();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_ind_details_Charge_Master_Maker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@SegmentID", SqlDbType.VarChar));
                Command.Parameters[0].Value = SegmentID;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        checkmaster.SegmentID = objReader["SegmentID"].ToString();
                        checkmaster.SegmentName = objReader["SegmentName"].ToString();
                        checkmaster.TransactionType = objReader["TransactionType"].ToString();
                        checkmaster.Outward_Charges_Amount = objReader["OutwardChargesAmount"].ToString();
                        checkmaster.Inward_Charges_Amount = objReader["InwardChargesAmount"].ToString();
                        checkmaster.Msg_Type = objReader["Message_Type"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_ind_details_Charge_Master_Maker");
            }
            return checkmaster;
        }

        public IEnumerable<ChargeMasterMakerModel> GetMakerDetails()
        {
            List<ChargeMasterMakerModel> userlist = new List<ChargeMasterMakerModel>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_details_Charge_Master_Maker", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ChargeMasterMakerModel objUser = new ChargeMasterMakerModel();
                        objUser.SegmentID = objReader["SegmentID"].ToString();
                        objUser.SegmentName = objReader["SegmentName"].ToString();
                        objUser.TransactionType = objReader["TransactionType"].ToString();
                        objUser.Outward_Charges_Amount = objReader["OutwardChargesAmount"].ToString();
                        objUser.Inward_Charges_Amount = objReader["InwardChargesAmount"].ToString();
                        objUser.ChargesStatus = objReader["ChargesStatus"].ToString();
                        objUser.SegID = Convert.ToInt32(objReader["SegID"].ToString());
                        objUser.IsDeleted = Convert.ToBoolean(objReader["IsDeleted"].ToString());
                        userlist.Add(objUser);

                    }

                }
            }

            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_details_Charge_Master_Maker");
            }
            return userlist;


        }

        public ChargeMasterMakerModel GetCheckerIndDetails(string SegmentID)
        {

            ChargeMasterMakerModel checkmaster = new ChargeMasterMakerModel();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_ind_details_Charge_Master_Checker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@SegmentID", SqlDbType.VarChar));
                Command.Parameters[0].Value = SegmentID;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        checkmaster.SegmentName = objReader["SegmentName"].ToString();
                        checkmaster.SegmentName = objReader["SegmentName"].ToString();
                        checkmaster.TransactionType = objReader["TransactionType"].ToString();
                        checkmaster.Outward_Charges_Amount = objReader["OutwardChargesAmount"].ToString();
                        checkmaster.Inward_Charges_Amount = objReader["InwardChargesAmount"].ToString();
                        checkmaster.Msg_Type = objReader["Message_Type"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_ind_details_Charge_Master_Checker");
            }
            return checkmaster;
        }

        public IEnumerable<ChargeMasterMakerModel> GetSearch(string SegmentID)
        {
            List<ChargeMasterMakerModel> searchdetails = new List<ChargeMasterMakerModel>();
            {
                try
                {
                    {
                        IDataReader? objReader = null;
                        DbCommand? Command = null;
                        Command = sqlHelper.GetCommandObject("FRM_Get_Search_Details_Charge_Master_MAker", CommandType.StoredProcedure);
                        Command.Parameters.Add(new SqlParameter("@SegmentID", SqlDbType.VarChar));
                        Command.Parameters[0].Value = SegmentID;



                        using (objReader = sqlHelper.ExecuteDataReader(Command))
                        {
                            while (objReader.Read())
                                searchdetails.Add(new ChargeMasterMakerModel
                                {
                                    SegmentID = objReader["SegmentID"].ToString(),
                                    SegmentName = objReader["SegmentName"].ToString(),
                                    TransactionType = objReader["TransactionType"].ToString(),
                                    Outward_Charges_Amount = objReader["OutwardChargesAmount"].ToString(),
                                    Inward_Charges_Amount = objReader["InwardChargesAmount"].ToString(),
                                    ChargesStatus = objReader["ChargesStatus"].ToString(),
                                    SegID = Convert.ToInt32(objReader["SegID"].ToString()),
                                    IsDeleted = Convert.ToBoolean(objReader["IsDeleted"].ToString()),

                                });
                        }

                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "FRM_Get_Search_Details_Charge_Master_MAker");
                }
                return searchdetails;


            }
        }
    }
}







