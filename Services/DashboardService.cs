using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.SqlClient;
using NPSS_Connect.Models;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.IServices
{
    public class DashboardService : IDashboardService
    {
        private readonly NLogWebApiService _logger;
        public DashboardService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public async Task<IEnumerable<DashBoard>> GetDemoDashboardAsync(string paymentModule, string paymentType, string processType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigManager.getDBConnection()))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("ipp_sp_get_Dashboard_demo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentModule", paymentModule);
                        command.Parameters.AddWithValue("@PaymentType", paymentType);
                        command.Parameters.AddWithValue("@ProcessType", processType);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            if (dataSet.Tables.Count > 0)
                            {
                                DataTable dataTable = dataSet.Tables[0];
                                return dataTable.AsEnumerable().Select(dataRow => new DashBoard
                                {
                                    ENT_MODULE = Convert.ToString(dataRow["ENT_MODULE"]),
                                    ENT_SubModule = Convert.ToString(dataRow["ENT_SubModule"]),
                                    Total = Convert.ToString(dataRow["Total"]),
                                    Sent_to_CB = Convert.ToString(dataRow["Sent_to_CB"]),
                                    Accepted = Convert.ToString(dataRow["Accepted"]),
                                    Rejected = Convert.ToString(dataRow["Rejected"]),
                                    Pending = Convert.ToString(dataRow["Pending"]),
                                    Reserve_Posting = Convert.ToString(dataRow["Reserve_Posting"]),
                                    Debit_Posting = Convert.ToString(dataRow["Debit_Posting"]),
                                    Credit_Posting = Convert.ToString(dataRow["Credit_Posting"]),
                                    Reserve_Failed = Convert.ToString(dataRow["Reserve_Failed"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_get_Dashboard_demo");
            }
            return Enumerable.Empty<DashBoard>();
        }

        public async Task<IEnumerable<DashBoardAlert>> GetDemoDashboardAlertAsync(string loginName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigManager.getDBConnection()))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("WPS_sp_DashboardAlerts_netcore", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoginName", loginName);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                            {
                                DataTable dataTable = dataSet.Tables[0];
                                DataRow dataRow = dataTable.Rows[0];

                                List<DashBoardAlert> dashAlertList = new List<DashBoardAlert>();

                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    string[] alertInfo = column.ColumnName.Split('&');
                                    DashBoardAlert objDashboard = new DashBoardAlert
                                    {
                                        Name = alertInfo[0].Replace("_", " "),
                                        Value = dataRow[column].ToString(),
                                        Action = alertInfo[2],
                                        Conroller = alertInfo[1]
                                    };
                                    dashAlertList.Add(objDashboard);
                                }

                                return dashAlertList;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "WPS_sp_DashboardAlerts_netcore");
            }
            return Enumerable.Empty<DashBoardAlert>();
        }

        public async Task<IEnumerable<DashBoardMasterAlert>> GetDemoDashboardMasterAlertAsync(string loginName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigManager.getDBConnection()))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("ipp_sp_get_Dashboard_Alert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoginName", loginName);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                            {
                                DataTable dataTable = dataSet.Tables[0];
                                List<DashBoardMasterAlert> dashAlertList = new List<DashBoardMasterAlert>();

                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    DashBoardMasterAlert objDashboardMaster = new DashBoardMasterAlert
                                    {
                                        MsgName = Convert.ToString(dataRow["MsgDesc"]),
                                        MsgValue = Convert.ToString(dataRow["MsgCount"]),
                                        MsgMins = Convert.ToString(dataRow["Msgmins"]),
                                        MsgAction = Convert.ToString(dataRow["MsgDesc"]),
                                        MsgConroller = Convert.ToString(dataRow["MsgCount"])
                                    };
                                    dashAlertList.Add(objDashboardMaster);
                                }

                                return dashAlertList;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_get_Dashboard_Alert");
            }
            return Enumerable.Empty<DashBoardMasterAlert>();
        }
    }
}
