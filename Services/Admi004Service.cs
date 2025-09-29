
using Entities.Admi004;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenFinanceWebApi.Services
{
    public class Admi004Service(NLogWebApiService logger) : IAdmi004Service
    {
        private readonly SqlHelper sqlHelper = new(ConfigManager.getDBConnection());

        public bool AddAdmi004(Admi004Checker admi004)
        {
            try
            {
                DbCommand command = sqlHelper.GetCommandObject("IPP_InsertUpdateSelect_Admi004Checker", CommandType.StoredProcedure);

                //AddParameters
                command.Parameters.Add(CreateParameter("@Action", admi004.Action, SqlDbType.VarChar));
                command.Parameters.Add(CreateParameter("@Id", admi004.Id, SqlDbType.Int));
                command.Parameters.Add(CreateParameter("@BICCode", admi004.BICCode, SqlDbType.VarChar));
                command.Parameters.Add(CreateParameter("@StartTime", admi004.StartTime != null ? admi004.StartTime : (object)DBNull.Value, SqlDbType.DateTime));
                command.Parameters.Add(CreateParameter("@EndTime", admi004.EndTime != null ? admi004.EndTime : (object)DBNull.Value, SqlDbType.DateTime));
                command.Parameters.Add(CreateParameter("@Description", admi004.Description, SqlDbType.VarChar));
                command.Parameters.Add(CreateParameter("@Status", admi004.Status, SqlDbType.VarChar));
                command.Parameters.Add(CreateParameter("@CreatedBy", admi004.CreatedBy, SqlDbType.VarChar));
                command.Parameters.Add(CreateParameter("@ApprovedBy", admi004.ApprovedBy != null ? admi004.ApprovedBy : (object)DBNull.Value, SqlDbType.VarChar));
                command.Parameters.Add(CreateParameter("@ApprovedOn", admi004.ApprovedOn != null ? admi004.ApprovedOn : (object)DBNull.Value, SqlDbType.DateTime));
                command.Parameters.Add(CreateParameter("@RejectReason", admi004.RejectReason != null ? admi004.RejectReason : (object)DBNull.Value, SqlDbType.VarChar));

                sqlHelper.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "IPP_InsertUpdateSelect_Admi004Checker");
                return false;
            }
        }

        public SqlParameter CreateParameter(string parameterName, object value, SqlDbType dbType)
        {
            try
            {
                var parameter = new SqlParameter(parameterName, dbType)
                {
                    Value = value ?? DBNull.Value
                };
                return parameter;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }

        }

        public async Task<List<Admi004Checker>> GetAdmi004(int id)
        {
            var admi004List = new List<Admi004Checker>();

            try
            {
                using var connection = new SqlConnection(ConfigManager.getDBConnection());
                await connection.OpenAsync();

                using var command = new SqlCommand("IPP_InsertUpdateSelect_Admi004Checker", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Action", "SELECT");
                command.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var admi004 = new Admi004Checker
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        BICCode = Convert.ToString(reader["BICCode"]),
                        StartTime = Convert.ToDateTime(reader["StartTime"]),
                        EndTime = Convert.ToDateTime(reader["EndTime"]),
                        Description = Convert.ToString(reader["Description"]),
                        Status = Convert.ToString(reader["Status"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                        CreatedBy = Convert.ToString(reader["CreatedBy"])
                    };

                    admi004List.Add(admi004);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "IPP_InsertUpdateSelect_Admi004Checker");
            }

            return admi004List;
        }

        public async Task<List<Admi004Checker>> GetAdmi004Inward()
        {
            var admi004List = new List<Admi004Checker>();

            try
            {
                using var connection = new SqlConnection(ConfigManager.getDBConnection());
                await connection.OpenAsync();

                using var command = new SqlCommand("IPP_InsertUpdateSelect_Admi004Checker", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Action", "INWARD");

                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var admi004 = new Admi004Checker
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        BICCode = Convert.ToString(reader["BICCode"]),
                        StartTime = Convert.ToDateTime(reader["StartTime"]),
                        EndTime = Convert.ToDateTime(reader["EndTime"]),
                        Description = Convert.ToString(reader["Description"]),
                        Status = Convert.ToString(reader["Status"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                        CreatedBy = Convert.ToString(reader["CreatedBy"])
                    };

                    admi004List.Add(admi004);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "IPP_InsertUpdateSelect_Admi004Checker");
            }

            return admi004List;
        }

        public async Task<List<Admi004Checker>> GetAdmi004Maker(int id)
        {
            var admi004List = new List<Admi004Checker>();

            try
            {
                using var connection = new SqlConnection(ConfigManager.getDBConnection());
                await connection.OpenAsync();

                using var command = new SqlCommand("IPP_Select_Admi004Maker", connection);
                command.CommandType = CommandType.StoredProcedure;

                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var admi004 = new Admi004Checker
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        BICCode = Convert.ToString(reader["BICCode"]),
                        StartTime = Convert.ToDateTime(reader["StartTime"]),
                        EndTime = Convert.ToDateTime(reader["EndTime"]),
                        Description = Convert.ToString(reader["Description"]),
                        Status = Convert.ToString(reader["Status"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                        CreatedBy = Convert.ToString(reader["CreatedBy"]),
                        RejectReason = Convert.ToString(reader["RejectReason"])
                    };

                    admi004List.Add(admi004);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "IPP_Select_Admi004Maker");
            }

            return admi004List;
        }

        public Admi004 GetAdmi004Details(string Id)
        {
            var admi004 = new Admi004();
            try
            {
                IDataReader objReader = null!;
                DbCommand Command = null!;

                Command = sqlHelper.GetCommandObject("ipp_owd_get_admi004_details", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                Command.Parameters[0].Value = Id;
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        admi004.EvtREFID = Convert.ToInt32(objReader["EvtREFID"]);
                        admi004.EvtBICCode = Convert.ToString(objReader["EvtBICCode"]);
                        admi004.EvtStart = Convert.ToString(objReader["EvtStart"]);
                        admi004.EvtEnd = Convert.ToString(objReader["EvtEnd"]);
                        admi004.EvtDesc = Convert.ToString(objReader["EvtDesc"]);
                        admi004.EvtDeleted = Convert.ToBoolean(objReader["EvtDeleted"]);
                        admi004.EvtStatus = "";
                        var status = Convert.ToString(objReader["EvtStatus"]);
                        if (status == "10")
                        {
                            admi004.EvtStatus = "SentToApproval";
                        }
                        if (status == "20")
                        {
                            admi004.EvtStatus = "WaitingForApproval";
                        }
                        if (status == "30")
                        {
                            admi004.EvtStatus = "RejectedByChecker";
                        }
                        if (status == "40")
                        {
                            admi004.EvtStatus = "RepairedByMaker";
                        }
                        if (status == "50")
                        {
                            admi004.EvtStatus = "ApprovedByChecker";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_owd_get_admi004_details");
            }

            return admi004;
        }

        public string UpdateAdmi004(Admi004 admi004)
        {
            string? returnValue;
            try
            {
                DbCommand Command = null!;
                Command = sqlHelper.GetCommandObject("ipp_owd_insupd_admi004", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[0].Value = admi004.Action ?? "";
                Command.Parameters.Add(new SqlParameter("@EvtREFID", SqlDbType.Int));
                Command.Parameters[1].Value = admi004.EvtREFID;
                Command.Parameters.Add(new SqlParameter("@EvtBICCode", SqlDbType.VarChar));
                Command.Parameters[2].Value = admi004.EvtBICCode;
                Command.Parameters.Add(new SqlParameter("@EvtStart", SqlDbType.VarChar));
                Command.Parameters[3].Value = admi004.EvtStart;
                Command.Parameters.Add(new SqlParameter("@EvtEnd", SqlDbType.VarChar));
                Command.Parameters[4].Value = admi004.EvtEnd;
                Command.Parameters.Add(new SqlParameter("@EvtDesc", SqlDbType.VarChar));
                Command.Parameters[5].Value = admi004.EvtDesc ?? "";
                Command.Parameters.Add(new SqlParameter("@EvtDeleted", SqlDbType.Bit));
                Command.Parameters[6].Value = admi004.EvtDeleted ? 1 : 0;
                Command.Parameters.Add(new SqlParameter("@AppUserID", SqlDbType.VarChar));
                Command.Parameters[7].Value = admi004.AppUserID;
                Command.Parameters.Add(new SqlParameter("@RejectReason", SqlDbType.VarChar));
                Command.Parameters[8].Value = admi004.RejectReason ?? "";
                var prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                Command.Parameters.Add(prm1);
                sqlHelper.ExecuteNonQuery(Command);
                returnValue = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "ipp_owd_insupd_admi004");
                returnValue = ex.Message;
            }
            return returnValue ?? string.Empty;
        }
    }
}
