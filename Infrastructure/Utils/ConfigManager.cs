
#region NameSpaces


using FrameWork.Custom;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Fluent;
using System;
using System.IO;
#endregion

namespace Raqmiyat.Infrastructure.Utils
{
    public static class ConfigManager
    {
        private static readonly Logger _logger = LogManager.GetLogger("NLogWebApiService");
        public static string getDBConnection()
        {
            string _connectionString = string.Empty;
            string DBConnection = string.Empty;
            bool IsEncrypted=false;
            try
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                DBConnection = root.GetSection("DataBaseConnectionParams").GetSection("DBConnection").Value;
                IsEncrypted = Convert.ToBoolean(root.GetSection("DataBaseConnectionParams").GetSection("IsEncrypted").Value);
                _connectionString =SqlConManager.GetConnectionString(DBConnection, IsEncrypted);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, FormStructuredLog("ConfigManager", "getDBConnection", ex.Message));
              
            }
            return _connectionString;
        }


        public static string getFrameworkDBConnection()
        {
            string _connectionString = string.Empty;
            string DBConnection = string.Empty;
            bool IsEncrypted = false;
            try
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                DBConnection = root.GetSection("DataBaseConnectionParams").GetSection("FrameworkDBConnection").Value;
                IsEncrypted = Convert.ToBoolean(root.GetSection("DataBaseConnectionParams").GetSection("IsEncrypted").Value);
                _connectionString = SqlConManager.GetConnectionString(DBConnection, IsEncrypted);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, FormStructuredLog("ConfigManager", "getDBConnection", ex.Message));
            }
            return _connectionString;
        }

        public static string getAuditLogConnection()
        {
            string _connectionString = string.Empty;
            string DBConnection = string.Empty;
            bool IsEncrypted = false;
            try
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                DBConnection = root.GetSection("DataBaseConnectionParams").GetSection("AuditLogConnection").Value;
                IsEncrypted = Convert.ToBoolean(root.GetSection("DataBaseConnectionParams").GetSection("IsEncrypted").Value);
                _connectionString = SqlConManager.GetConnectionString(DBConnection, IsEncrypted);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, FormStructuredLog("ConfigManager", "getDBConnection", ex.Message));
            }
            return _connectionString;
        }
        private static string FormStructuredLog(string MethodName, string ProcedureName, string Message)
        {
            return $"-----------------------------------------------\r\n Class Name : ConfigManager.\r\n Method Name : {MethodName}.\r\n Stored Procedure : {ProcedureName} \r\n Message : {Message}. \r\n ----------------------------------------------------------------------------";
        }
    }
}
