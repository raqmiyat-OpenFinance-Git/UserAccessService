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
    public class BankOnboardingService : IBankOnboardingService
    {
        readonly SqlHelper sqlHelper = new SqlHelper(ConfigManager.getDBConnection());
        private readonly NLogWebApiService _logger;
        public BankOnboardingService(NLogWebApiService logger)
        {
            _logger = logger;
        }

        public BankOnboardingModel GetDetails()
        {

            BankOnboardingModel bankOnboardingModel = new BankOnboardingModel();
            List<BankOnboarding> userlist = new List<BankOnboarding>();
            List<BankOnboardingReject> BankOnboardingReject = new List<BankOnboardingReject>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("sp_get_details_BANK_Onboard_maker", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        BankOnboarding objUser = new BankOnboarding();
                        objUser.BankId = objReader["BankId"].ToString();
                        objUser.BankCode = objReader["BankCode"].ToString();
                        objUser.BankName = objReader["BankName"].ToString();
                        objUser.SwiftCode = objReader["SwiftCode"].ToString();
                        objUser.IPP_Live = Convert.ToBoolean(objReader["IPP_Live"].ToString());
                        objUser.IPP_Real_Time = Convert.ToBoolean(objReader["IPP_Real_Time"].ToString());
                        objUser.IPP_OverlayService = Convert.ToBoolean(objReader["IPP_OverlayService"].ToString());
                        userlist.Add(objUser);

                    }
                    bankOnboardingModel.bankOnboarding = userlist;
                    if (objReader.NextResult())
                    {
                        while (objReader.Read())
                        {

                            BankOnboardingReject objUser = new BankOnboardingReject();
                            objUser.BankId = objReader["BankId"].ToString();
                            objUser.ID = objReader["id"].ToString();
                            objUser.Action = objReader["Action"].ToString();
                            objUser.Reject_Reason = objReader["Reject_Reason"].ToString();
                            objUser.BankCode = objReader["BankCode"].ToString();
                            objUser.BankName = objReader["BankName"].ToString();
                            objUser.SwiftCode = objReader["SwiftCode"].ToString();
                            objUser.IPP_Live = Convert.ToBoolean(objReader["IPP_Live"].ToString());
                            objUser.IPP_Real_Time = Convert.ToBoolean(objReader["IPP_Real_Time"].ToString());
                            objUser.IPP_OverlayService = Convert.ToBoolean(objReader["IPP_OverlayService"].ToString());
                            BankOnboardingReject.Add(objUser);

                        }
                    }
                    bankOnboardingModel.bankOnboardingReject = BankOnboardingReject;
                }
            }

            catch (Exception ex)
            {
                _logger.Error(ex, "sp_get_details_BANK_Onboard_maker");
            }
            return bankOnboardingModel;


        }

        public string Add(BankOnboarding user)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("sp_Create_details_BANK_Onboard_maker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@BankCode", SqlDbType.VarChar));
                Command.Parameters[0].Value = user.BankCode;
                Command.Parameters.Add(new SqlParameter("@BankName", SqlDbType.VarChar));
                Command.Parameters[1].Value = user.BankName;
                Command.Parameters.Add(new SqlParameter("@SwiftCode", SqlDbType.VarChar));
                Command.Parameters[2].Value = user.SwiftCode;
                Command.Parameters.Add(new SqlParameter("@Batch", SqlDbType.Bit));
                Command.Parameters[3].Value = user.IPP_Live;
                Command.Parameters.Add(new SqlParameter("@Realtime", SqlDbType.Bit));
                Command.Parameters[4].Value = user.IPP_Real_Time;
                Command.Parameters.Add(new SqlParameter("@Overlay", SqlDbType.Bit));
                Command.Parameters[5].Value = user.IPP_OverlayService;
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[6].Value = user.Action;
                Command.Parameters.Add(new SqlParameter("@Action_By", SqlDbType.VarChar));
                Command.Parameters[7].Value = user.Action_By;
                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);
                sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_Create_details_BANK_Onboard_maker");
                Output_Desc = ex.Message;
            }
            return Output_Desc!;



        }

        public BankOnboarding GetIndDet(string Bank_Id)
        {
            BankOnboarding bankOnboarding = new BankOnboarding();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("sp_get_details_for_Edit_BANK_Onboard_maker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Bank_Id", SqlDbType.VarChar));
                Command.Parameters[0].Value = Bank_Id;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        bankOnboarding.BankId = objReader["BankId"].ToString();
                        bankOnboarding.BankCode = objReader["BankCode"].ToString();
                        bankOnboarding.BankName = objReader["BankName"].ToString();
                        bankOnboarding.SwiftCode = objReader["SwiftCode"].ToString();
                        bankOnboarding.IPP_Live = Convert.ToBoolean(objReader["IPP_Live"].ToString());
                        bankOnboarding.IPP_Real_Time = Convert.ToBoolean(objReader["IPP_Real_Time"].ToString());
                        bankOnboarding.IPP_OverlayService = Convert.ToBoolean(objReader["IPP_OverlayService"].ToString());

                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_get_details_for_Edit_BANK_Onboard_maker");
            }
            return bankOnboarding;
        }

        public BankOnboarding GetIndDetid(string id)
        {
            BankOnboarding bankOnboarding = new BankOnboarding();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("sp_get_details_for_Edit_BANK_Onboard_Reject", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar));
                Command.Parameters[0].Value = id;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        bankOnboarding.BankId = objReader["BankId"].ToString();
                        bankOnboarding.ID = objReader["Id"].ToString();
                        bankOnboarding.Action = objReader["Action"].ToString();
                        bankOnboarding.BankCode = objReader["BankCode"].ToString();
                        bankOnboarding.BankName = objReader["BankName"].ToString();
                        bankOnboarding.SwiftCode = objReader["SwiftCode"].ToString();
                        bankOnboarding.IPP_Live = Convert.ToBoolean(objReader["IPP_Live"].ToString());
                        bankOnboarding.IPP_Real_Time = Convert.ToBoolean(objReader["IPP_Real_Time"].ToString());
                        bankOnboarding.IPP_OverlayService = Convert.ToBoolean(objReader["IPP_OverlayService"].ToString());

                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_get_details_for_Edit_BANK_Onboard_Reject");
            }
            return bankOnboarding;
        }

        public string EditUser(BankOnboarding user)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("sp_Insert_Details_BANK_Onboard_maker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@BankId", SqlDbType.VarChar));
                Command.Parameters[0].Value = user.BankId;
                Command.Parameters.Add(new SqlParameter("@BankCode", SqlDbType.VarChar));
                Command.Parameters[1].Value = user.BankCode;
                Command.Parameters.Add(new SqlParameter("@BankName", SqlDbType.VarChar));
                Command.Parameters[2].Value = user.BankName;
                Command.Parameters.Add(new SqlParameter("@SwiftCode", SqlDbType.VarChar));
                Command.Parameters[3].Value = user.SwiftCode;
                Command.Parameters.Add(new SqlParameter("@Batch", SqlDbType.Bit));
                Command.Parameters[4].Value = user.IPP_Live;
                Command.Parameters.Add(new SqlParameter("@Realtime", SqlDbType.Bit));
                Command.Parameters[5].Value = user.IPP_Real_Time;
                Command.Parameters.Add(new SqlParameter("@Overlay", SqlDbType.Bit));
                Command.Parameters[6].Value = user.IPP_OverlayService;
                Command.Parameters.Add(new SqlParameter("@Action_By", SqlDbType.VarChar));
                Command.Parameters[7].Value = user.Action_By;
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[8].Value = user.Action;


                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);
                sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_Insert_Details_BANK_Onboard_maker");
                Output_Desc = ex.Message;
            }
            return Output_Desc!;

        }

        public string EditUserReject(BankOnboarding user)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("sp_Insert_Details_BANK_Onboard_Reject", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@BankId", SqlDbType.VarChar));
                Command.Parameters[0].Value = user.BankId;
                Command.Parameters.Add(new SqlParameter("@BankCode", SqlDbType.VarChar));
                Command.Parameters[1].Value = user.BankCode;
                Command.Parameters.Add(new SqlParameter("@BankName", SqlDbType.VarChar));
                Command.Parameters[2].Value = user.BankName;
                Command.Parameters.Add(new SqlParameter("@SwiftCode", SqlDbType.VarChar));
                Command.Parameters[3].Value = user.SwiftCode;
                Command.Parameters.Add(new SqlParameter("@Batch", SqlDbType.Bit));
                Command.Parameters[4].Value = user.IPP_Live;
                Command.Parameters.Add(new SqlParameter("@Realtime", SqlDbType.Bit));
                Command.Parameters[5].Value = user.IPP_Real_Time;
                Command.Parameters.Add(new SqlParameter("@Overlay", SqlDbType.Bit));
                Command.Parameters[6].Value = user.IPP_OverlayService;
                Command.Parameters.Add(new SqlParameter("@Action_By", SqlDbType.VarChar));
                Command.Parameters[7].Value = user.Action_By;
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[8].Value = user.Action;
                Command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                Command.Parameters[9].Value = user.ID;


                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);
                sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_Insert_Details_BANK_Onboard_Reject");
                Output_Desc = ex.Message;
            }
            return Output_Desc!;

        }

        public IEnumerable<BankOnboarding> CheckerDetail()
        {
            List<BankOnboarding> BankOnboardingList = new List<BankOnboarding>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("sp_get_details_BANK_Onboard_Checker", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        BankOnboarding objUser = new BankOnboarding();

                        objUser.BankId = objReader["BankId"].ToString();
                        objUser.ID = objReader["ID"].ToString();
                        objUser.BankCode = objReader["BankCode"].ToString();
                        objUser.BankName = objReader["BankName"].ToString();
                        objUser.SwiftCode = objReader["SwiftCode"].ToString();
                        objUser.IPP_Live = Convert.ToBoolean(objReader["IPP_Live"].ToString());
                        objUser.IPP_Real_Time = Convert.ToBoolean(objReader["IPP_Real_Time"].ToString());
                        objUser.IPP_OverlayService = Convert.ToBoolean(objReader["IPP_OverlayService"].ToString());
                        objUser.Action = objReader["Action"].ToString();
                        BankOnboardingList.Add(objUser);

                    }
                }
                return BankOnboardingList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_get_details_BANK_Onboard_Checker");
            }
            return BankOnboardingList;
        }

        public BankOnboarding GetCheckIndDetails(string Id)
        {
            BankOnboarding BankOnboardingModel = new BankOnboarding();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("sp_get_details_BANK_Onboard_Checker_ID", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                Command.Parameters[0].Value = Id;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        BankOnboardingModel.ID = objReader["ID"].ToString();
                        BankOnboardingModel.BankId = objReader["BankId"].ToString();
                        BankOnboardingModel.BankCode = objReader["BankCode"].ToString();
                        BankOnboardingModel.BankName = objReader["BankName"].ToString();
                        BankOnboardingModel.SwiftCode = objReader["SwiftCode"].ToString();
                        BankOnboardingModel.IPP_Live = Convert.ToBoolean(objReader["IPP_Live"].ToString());
                        BankOnboardingModel.IPP_Real_Time = Convert.ToBoolean(objReader["IPP_Real_Time"].ToString());
                        BankOnboardingModel.IPP_OverlayService = Convert.ToBoolean(objReader["IPP_OverlayService"].ToString());
                        BankOnboardingModel.Action = objReader["Action"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_get_details_BANK_Onboard_Checker_ID");
            }
            return BankOnboardingModel;
        }

        public string Approve(BankOnboarding obj)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("sp_Approve_Bank_Onboard_checker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                Command.Parameters[0].Value = obj.ID;
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[1].Value = obj.Action;
                Command.Parameters.Add(new SqlParameter("@Action_By", SqlDbType.VarChar));
                Command.Parameters[2].Value = obj.Action_By;

                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_Approve_Bank_Onboard_checker");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }

        public string Reject(BankOnboarding obj)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("sp_Reject_Bank_Onboard_checker", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                Command.Parameters[0].Value = obj.ID;
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[1].Value = obj.Action;
                Command.Parameters.Add(new SqlParameter("@Action_By", SqlDbType.VarChar));
                Command.Parameters[2].Value = obj.Action_By;
                Command.Parameters.Add(new SqlParameter("@Reject_Reason", SqlDbType.VarChar));
                Command.Parameters[3].Value = obj.Reject_Reason;

                SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_Reject_Bank_Onboard_checker");
                Output_Desc = ex.Message;
            }
            return Output_Desc;
        }

        public string UploadOnboard(List<BankOnboarding> Banks)
        {
            var Output_Desc = string.Empty;
            try
            {
                foreach (var bank in Banks)
                {
                    DbCommand? Command = null;

                    Command = sqlHelper.GetCommandObject("sp_Create_details_BANK_Onboard_maker_Upload", CommandType.StoredProcedure);
                    Command.Parameters.Add(new SqlParameter("@BankCode", SqlDbType.VarChar));
                    Command.Parameters[0].Value = bank.BankCode;
                    Command.Parameters.Add(new SqlParameter("@BankName", SqlDbType.VarChar));
                    Command.Parameters[1].Value = bank.BankName;
                    Command.Parameters.Add(new SqlParameter("@SwiftCode", SqlDbType.VarChar));
                    Command.Parameters[2].Value = bank.SwiftCode;
                    Command.Parameters.Add(new SqlParameter("@Batch", SqlDbType.Bit));
                    Command.Parameters[3].Value = bank.IPP_Live;
                    Command.Parameters.Add(new SqlParameter("@Realtime", SqlDbType.Bit));
                    Command.Parameters[4].Value = bank.IPP_Real_Time;
                    Command.Parameters.Add(new SqlParameter("@Overlay", SqlDbType.Bit));
                    Command.Parameters[5].Value = bank.IPP_OverlayService;
                    Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                    Command.Parameters[6].Value = bank.Action;
                    Command.Parameters.Add(new SqlParameter("@Action_By", SqlDbType.VarChar));
                    Command.Parameters[7].Value = bank.Action_By;
                    SqlParameter prm1 = new SqlParameter("@Output", SqlDbType.VarChar, 500);
                    prm1.Direction = ParameterDirection.Output;
                    Command.Parameters.Add(prm1);
                    sqlHelper.ExecuteNonQuery(Command);
                    Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "sp_Create_details_BANK_Onboard_maker_Upload");
                Output_Desc = ex.Message;
            }
            return Output_Desc!;
        }


        public IEnumerable<BankOnboarding> GetBankOnboardSearch(string BankName,string BankCode)
        {
            List<BankOnboarding> searchdetails = new List<BankOnboarding>();
            {
                try
                {
                    
                        IDataReader? objReader = null;
                        DbCommand? Command = null;
                        Command = sqlHelper.GetCommandObject("FRM_Get_Search_Details_BankOndoarding_Master_MAker", CommandType.StoredProcedure);
                        Command.Parameters.Add(new SqlParameter("@BankName", SqlDbType.VarChar));
                        Command.Parameters[0].Value = BankName;
                        Command.Parameters.Add(new SqlParameter("@BankCode", SqlDbType.VarChar));
                        Command.Parameters[1].Value = BankCode;


                        using (objReader = sqlHelper.ExecuteDataReader(Command))
                        {
                            while (objReader.Read())
                                searchdetails.Add(new BankOnboarding
                                {
                                    BankId = objReader["BankId"].ToString(),
                                    BankCode = objReader["BankCode"].ToString(),
                                    BankName = objReader["BankName"].ToString(),
                                    SwiftCode = objReader["SwiftCode"].ToString(),
                                    IPP_Live = Convert.ToBoolean(objReader["IPP_Live"].ToString()),
                                    IPP_Real_Time = Convert.ToBoolean(objReader["IPP_Real_Time"].ToString()),
                                    IPP_OverlayService = Convert.ToBoolean(objReader["IPP_OverlayService"].ToString()),
                             

                                });
                        }

                    
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "FRM_Get_Search_Details_BankOndoarding_Master_MAker");
                }
                return searchdetails;


            }
        }
    }
}






