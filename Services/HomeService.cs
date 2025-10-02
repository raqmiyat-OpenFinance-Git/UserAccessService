using Entities.Home;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using UserAccessService.Models;

namespace OpenFinanceWebApi.Services
{

    public class HomeService : IHomeService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getDBConnection());
        private readonly NLogWebApiService _logger;
        public HomeService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public ChartDashboard GetChartDashboard(string PaymentModule)
        {

            ChartDashboard objChartDashboard = new ChartDashboard();
            try
            {

                //ChartDashboard objChartDashboard = new ChartDashboard();
                //

                IDataReader objReader = null;
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("IPP_SP_Dashboard", CommandType.StoredProcedure);

                Command.Parameters.Add(new SqlParameter("@Businessdate", SqlDbType.DateTime));
                Command.Parameters[0].Value = "2022-10-07 10:19:02.850";

                Command.Parameters.Add(new SqlParameter("@PaymentModule", SqlDbType.VarChar));
                Command.Parameters[1].Value = PaymentModule;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        objChartDashboard.Total = objReader["Total"] == null ? "0" : Convert.ToString(objReader["Total"]);
                        objChartDashboard.AcceptCount = objReader["AcceptCount"] == null ? "0" : Convert.ToString(objReader["AcceptCount"]);
                        objChartDashboard.RejCount = objReader["RejCount"] == null ? "0" : Convert.ToString(objReader["RejCount"]);
                        objChartDashboard.Pending = objReader["Pending"] == null ? "0" : Convert.ToString(objReader["Pending"]);
                        objChartDashboard.TATDelays = objReader["TATDelays"] == null ? "0" : Convert.ToString(objReader["f"]);


                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_SP_Dashboard");
            }
            return objChartDashboard;
        }

        //public List<FullMenu> GetModule(string userCode)
        //{

        //    var fulllist = new List<FullMenu>();
        //    try
        //    {
        //        SqlConnection sqlcon = new SqlConnection(ConfigManager.getFrameworkDBConnection());
        //        sqlcon.Open();

        //        SqlCommand cmd = new SqlCommand("frm_sp_user_menu_access_netcore", sqlcon);

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@User_Name", userCode);


        //        DataSet ds = new DataSet();
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(ds);

        //         fulllist = (from item in ds.Tables[0].AsEnumerable()
        //                        select new FullMenu
        //                        {
        //                            TXNATTRIBS_TXNID = item.Field<int>("TXNATTRIBS_TXNID"),
        //                            TXNATTRIBS_TXNNAME = item.Field<string>("TXNATTRIBS_TXNNAME"),
        //                            TXNATTRIBS_CATEGORY = item.Field<string>("TXNATTRIBS_CATEGORY"),
        //                            TXNATTRIBS_CATEGORY_ORDER = item.Field<int>("TXNATTRIBS_CATEGORY_ORDER"),
        //                            TXNATTRIBS_DISPLAYLIST = item.Field<string>("TXNATTRIBS_DISPLAYLIST"),
        //                            TXNATTRIBS_CONTROLLER_NAME = item.Field<string>("TXNATTRIBS_CONTROLLER_NAME"),
        //                            TXNATTRIBS_ACTION_NAME = item.Field<string>("TXNATTRIBS_ACTION_NAME"),
        //                            TXNATTRIBS_PARENT_TXNID = item.Field<int>("TXNATTRIBS_PARENT_TXNID"),
        //                        }).ToList();

        //        //return ds.Tables[0].AsEnumerable();
        //        //return fulllist;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error(ex, "frm_sp_user_menu_access_netcore");
        //        throw;
        //    }
        //    return fulllist;
        //}


        public List<FRMMENU> GetModule(string userCode)
        {
            var menuList = new List<FRMMENU>();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(ConfigManager.getFrameworkDBConnection()))
                {
                    sqlcon.Open();

                    using (SqlCommand cmd = new SqlCommand("FRM_SELECTMENUS", sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@User_Name", userCode ?? (object)DBNull.Value);

                        DataSet ds = new DataSet();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds);

                        menuList = (from item in ds.Tables[0].AsEnumerable()
                                    select new FRMMENU
                                    {
                                        MenuID = item.Field<int>("MenuID"),
                                        ModuleName = item.Field<string>("ModuleID"),
                                        MenuName = item.Field<string>("MenuName"),
                                        ControllerName = item.Field<string>("ControllerName"),
                                        IndexName = item.Field<string>("IndexName"),
                                        ItemOrder = item.Field<int>("ItemOrder"),
                                        ModuleOrder = item.Field<short>("ModuleOrder"),
                                        IsDeleted = item.Field<bool>("IsDeleted"),
                                        ProductID = item.Field<int>("ProductID")
                                    }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_user_menu_access_netcore");
            }
            return menuList;
        }
        public ValidatePassword GetPasswordPolicy()
        {

            ValidatePassword passwordPolicy = new ValidatePassword();
            try
            {
                SqlConnection Sqlcon = new SqlConnection(ConfigManager.getFrameworkDBConnection());
                Sqlcon.Open();
                SqlCommand command = new SqlCommand("FRM_sp_get_Password_Policy_Details_netcore", Sqlcon);

                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader = command.ExecuteReader();
                while (objReader.Read())
                {
                    passwordPolicy.Complex = Convert.ToBoolean(objReader["Complex_YN"]);
                    passwordPolicy.Maximum_Lenth = Convert.ToInt32(objReader["Maximum_Length"]);
                    passwordPolicy.Minimum_Lenth = Convert.ToInt32(objReader["Minimum_Length"]);
                    passwordPolicy.ExpiryDate = Convert.ToInt32(objReader["Expiry_Days"]);
                    passwordPolicy.ReminderDate = Convert.ToInt32(objReader["Reminder_Days"]);
                    passwordPolicy.Uppercase = Convert.ToInt32(objReader["Case_Format"]);
                    passwordPolicy.HistoryRecords = Convert.ToInt32(objReader["History_Records"]);
                    passwordPolicy.NoOfAttempts = Convert.ToInt32(objReader["No_Of_Attempts"]);
                }


            }
            catch (Exception ex)
            {
                _logger.Error(ex, "FRM_sp_get_Password_Policy_Details_netcore");
            }
            return passwordPolicy;
        }
    }
}
