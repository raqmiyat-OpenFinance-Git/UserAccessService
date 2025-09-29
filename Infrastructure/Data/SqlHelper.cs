
using NLog;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Raqmiyat.Infrastructure.Data
{
    public class SqlHelper
    {
        private readonly Logger _logger = LogManager.GetLogger("NLogWebApiService");
        private readonly string _connectionString;
        public SqlHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDataReader ExecuteDataReader(DbCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException(nameof(command), "Command cannot be null.");
                }
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"SqlException Messgae: {ex.Message}");
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task<IDataReader> ExecuteDataReaderAsync(DbCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException(nameof(command), "Command cannot be null.");
                }
                if (command.Connection.State != ConnectionState.Open)
                {
                    await command.Connection.OpenAsync();
                }
                return await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"SqlException Messgae: {ex.Message}");
                throw new InvalidOperationException(ex.Message);
            }
        }
        public int ExecuteNonQuery(DbCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException(nameof(command), "Command cannot be null.");
                }
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"SqlException Messgae: {ex.Message}");
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task<int> ExecuteNonQueryAsync(DbCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException(nameof(command), "Command cannot be null.");
                }
                if (command.Connection.State != ConnectionState.Open)
                {
                    await command.Connection.OpenAsync();
                }
                return await command.ExecuteNonQueryAsync();

            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"SqlException Messgae: {ex.Message}");
                throw new InvalidOperationException(ex.Message);
            }

        }
        public DbCommand GetCommandObject(string sqlCommand, CommandType type)
        {

            try
            {

                SqlConnection connection = new SqlConnection(_connectionString);
                DbCommand command = connection.CreateCommand();

                command.CommandText = sqlCommand;
                command.CommandType = type;

                return command;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"SqlException Messgae: {ex.Message}");
                throw new InvalidOperationException(ex.Message);
            }
        }
        public object ExecuteScalar(DbCommand command)
        {

            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException(nameof(command), "Command cannot be null.");
                }
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"SqlException Messgae: {ex.Message}");
                throw new InvalidOperationException(ex.Message);
            }

        }
        public async Task<object> ExecuteScalarAsync(DbCommand command)
        {

            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException(nameof(command), "Command cannot be null.");
                }

                if (command.Connection.State != ConnectionState.Open)
                {
                    await command.Connection.OpenAsync();
                }
                return await command.ExecuteScalarAsync();

            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"SqlException Messgae: {ex.Message}");
                throw new InvalidOperationException(ex.Message);
            }

        }
        public DataSet ExecuteDataSet(DbCommand command)
        {
            try
            {
                if (command == null) throw new ArgumentNullException(nameof(command));
                var dataSet = new DataSet();
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                var adapter = new SqlDataAdapter((SqlCommand)command);
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"SqlException Messgae: {ex.Message}");
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task<DataSet> ExecuteDataSetAsync(DbCommand command)
        {


            try
            {
                var dataSet = new DataSet();
                if (command == null)
                {
                    throw new ArgumentNullException(nameof(command));
                }
                if (command.Connection.State != ConnectionState.Open)
                {
                    await command.Connection.OpenAsync();
                }
                var adapter = new SqlDataAdapter((SqlCommand)command);
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"SqlException Messgae: {ex.Message}");
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
