using Entities.Master;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OpenFinanceWebApi.Models;
using System.Data;

namespace OpenFinanceWebApi.Data
{
    public class NPSSDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public NPSSDbContext(DbContextOptions<NPSSDbContext> options)
             : base(options)
        {
        }
        public DbSet<DashBoardResultModel> DashBoardResultModels { get; set; }
        public async Task<List<Dictionary<string, object>>> GetReportDataAsync(DateTime date)
        {
            var resultList = new List<Dictionary<string, object>>();

            await using (var connection = Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SP_GET_DASHBOARD_NEW_DESIGN";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Date", date));

                using var reader = await command.ExecuteReaderAsync();

                do
                {
                    while (await reader.ReadAsync())
                    {
                        var result = new Dictionary<string, object>();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            result[reader.GetName(i)] = reader.GetValue(i);
                        }
                        resultList.Add(result);
                    }
                } while (await reader.NextResultAsync());
            }

            return resultList;
        }
        public async Task<List<List<DashBoardResultModel>>> GetDashBoardResults(DateTime date)
        {
            var resultSets = new List<List<DashBoardResultModel>>();

            var connection = Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SP_GET_DASHBOARD_NEW";
                command.CommandType = CommandType.StoredProcedure;

                // Add parameter to the command
                command.Parameters.Add(new SqlParameter("@Date", date));

                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    do
                    {
                        var resultSet = new List<DashBoardResultModel>();

                        if (dataReader.HasRows)
                        {
                            while (await dataReader.ReadAsync())
                            {
                                var result = new DashBoardResultModel
                                {
                                    COUNT = Convert.ToInt32(dataReader["COUNT"]),
                                    TOTAL = Convert.ToDecimal(dataReader["TOTAL"]),
                                    STATUS = dataReader["STATUS"].ToString()!,
                                    MODULE_NAME = dataReader["MODULE_NAME"].ToString()!,
                                    Mode = dataReader["Mode"].ToString()!
                                };

                                resultSet.Add(result);
                            }
                        }

                        resultSets.Add(resultSet);

                    } while (await dataReader.NextResultAsync());
                }
            }

            return resultSets;
        }
        public async Task<List<List<DashBoardResultModel>>> GetDashBoardByCategory(DateTime date)
        {
            var resultSets = new List<List<DashBoardResultModel>>();

            var connection = Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SP_GET_DASHBOARD_VALUES_BY_CATEGORY";
                command.CommandType = CommandType.StoredProcedure;

                // Add parameter to the command
                command.Parameters.Add(new SqlParameter("@Date", date));

                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    do
                    {
                        var resultSet = new List<DashBoardResultModel>();

                        if (dataReader.HasRows)
                        {
                            while (await dataReader.ReadAsync())
                            {
                                var result = new DashBoardResultModel
                                {
                                    TOTAL = Convert.ToDecimal(dataReader["TOTAL"]),
                                    Mode = dataReader["Mode"].ToString()!
                                };

                                resultSet.Add(result);
                            }
                        }

                        resultSets.Add(resultSet);

                    } while (await dataReader.NextResultAsync());
                }
            }

            return resultSets;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DashBoardResultModel>().HasNoKey();
            // Additional configurations if needed
        }
        public async Task<string> GetNextSeqNo(string serviceName)
        {
            string result = string.Empty;

            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "IPP_sp_get_next_ENQ_SEQ_No";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@InstrName", serviceName));

                if (command.Connection!.State != ConnectionState.Open)
                    await command.Connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result = reader.GetString(reader.GetOrdinal("SequenceNumber"));
                    }
                }
            }
            return result;
        }
        public DbSet<EnrolmentChecker> EnrolmentCheckers { get; set; }
        public DbSet<EnrolmentMain> EnrolmentMain { get; set; }

        public DbSet<IPP_OWD_Admi004_Maker> IPP_OWD_Admi004_Maker { get; set; }

        public DbSet<IPP_OWD_Admi004_Checker> IPP_OWD_Admi004_Checker { get; set; }
    }
}
