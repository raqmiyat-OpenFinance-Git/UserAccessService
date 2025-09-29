
//using NLog;
//using System.Diagnostics;
//using System.Reflection;

//namespace OpenFinanceWebApi.NLogService
//{
//    public class BaseLogger
//    {
//        public required Logger Log { get; set; }

//        public void Debug(string Message)
//        {
//            Log.Debug(FormStructuredLog(Message));
//        }

//        public void Error(string Message)
//        {
//            Log.Error(FormStructuredLog(Message));
//        }
//        public void Error(Exception ex, string StoreProcedure)
//        {
//            Log.Error(FormStructuredLog($"Exception: {ex.Message}", StoreProcedure));
//            if (ex.InnerException != null)
//            {
//                Log.Error(FormStructuredLog($"InnerException: {ex.InnerException.Message}", StoreProcedure));
//            }
//            Log.Error(FormStructuredLog($"StackTrace: {ex.StackTrace}", StoreProcedure));
//        }

//        public void Error(Exception ex)
//        {
//            Log.Error(FormStructuredLog($"Exception: {ex.Message}"));

//            if (ex.InnerException != null)
//            {
//                Log.Error(FormStructuredLog($"InnerException: {ex.InnerException.Message}"));
//            }

//            Log.Error(FormStructuredLog($"StackTrace: {ex.StackTrace}"));
//        }

//        public void Info(string Message)
//        {
//            Log.Info(FormStructuredLog(Message));
//        }

//        public void Warn(string Message)
//        {
//            Log.Warn(FormStructuredLog(Message));
//        }

//        public void Trace(string Message)
//        {
//            Log.Trace(FormStructuredLog(Message));
//        }
//        public static string FormStructuredLog(string Message, string StoreProcedure)
//        {
//            string parentMethodName = string.Empty;
//            string parentClassName = string.Empty;
//            int lineNumber = 0;

//            try
//            {
//                string[] ignoredMethodNames =
//                [
//                    "Start",
//                    "AsyncMethodBuilderCore",
//                    "ExecutionContextCallback",
//                    "RunInternal",
//                    "RunOrScheduleAction",
//                    "Info",
//                    "FormStructuredLog"
//                ];

//                var stackTrace = new StackTrace(true);

//                for (int i = 1; i < stackTrace.FrameCount; i++)
//                {
//                    StackFrame frame = stackTrace.GetFrame(i)!;
//                    MethodBase method = frame.GetMethod()!;

//                    if (method.DeclaringType != null
//&& method.DeclaringType != typeof(BaseLogger)
//&& !method.IsSpecialName
//&& !ignoredMethodNames.Contains(method.Name))
//                    {
//                        parentClassName = method.DeclaringType.Name;
//                        parentMethodName = method.Name;
//                        lineNumber = frame.GetFileLineNumber();

//                        string filePath = frame.GetFileName() ?? "Unknown";
//                        string methodNameWithSuffix = method.Name;
//                        string fileName = Path.GetFileName(filePath);

//                        int startIndex = parentClassName.IndexOf('<') + 1;
//                        int endIndex = parentClassName.IndexOf('>');

//                        if (startIndex != -1 && endIndex != -1)
//                        {
//                            parentMethodName = parentClassName[startIndex..endIndex];
//                            parentClassName = fileName.Replace(".cs", "");
//                        }
//                        else
//                        {
//                            parentMethodName = methodNameWithSuffix;
//                        }
//                        break;
//                    }
//                }
//            }
//            catch
//            {
//                //If Exception, ignore to get method name and class name
//            }

//            var separator = "-------------------------------------------------------------------------------------";
//            var newLine = "\r\n";
//            return $"{newLine}Class Name : {parentClassName}{newLine}Method Name : {parentMethodName}{newLine}Line Number : {lineNumber}{newLine}StoreProcedure : {StoreProcedure}{newLine}Message : {Message}{newLine}{separator}";
//        }

//        public static string FormStructuredLog(string Message)
//        {
//            string parentMethodName = string.Empty;
//            string parentClassName = string.Empty;
//            int lineNumber = 0;

//            try
//            {
//                string[] ignoredMethodNames =
//                [
//                    "Start",
//                    "AsyncMethodBuilderCore",
//                    "ExecutionContextCallback",
//                    "RunInternal",
//                    "RunOrScheduleAction",
//                    "Info",
//                    "FormStructuredLog"
//                ];

//                var stackTrace = new StackTrace(true);

//                for (int i = 1; i < stackTrace.FrameCount; i++)
//                {
//                    StackFrame frame = stackTrace.GetFrame(i)!;
//                    MethodBase method = frame.GetMethod()!;

//                    if (method.DeclaringType != null
//&& method.DeclaringType != typeof(BaseLogger)
//&& !method.IsSpecialName
//&& !ignoredMethodNames.Contains(method.Name))
//                    {
//                        parentClassName = method.DeclaringType.Name;
//                        parentMethodName = method.Name;
//                        lineNumber = frame.GetFileLineNumber();

//                        string filePath = frame.GetFileName() ?? "Unknown";
//                        string methodNameWithSuffix = method.Name;
//                        string fileName = Path.GetFileName(filePath);

//                        int startIndex = parentClassName.IndexOf('<') + 1;
//                        int endIndex = parentClassName.IndexOf('>');

//                        if (startIndex != -1 && endIndex != -1)
//                        {
//                            parentMethodName = parentClassName[startIndex..endIndex];
//                            parentClassName = fileName.Replace(".cs", "");
//                        }
//                        else
//                        {
//                            parentMethodName = methodNameWithSuffix;
//                        }
//                        break;
//                    }
//                }
//            }
//            catch
//            {
//                //If Exception, ignore to get method name and class name
//            }

//            var separator = "-------------------------------------------------------------------------------------";
//            var newLine = "\r\n";
//            return $"{newLine}Class Name : {parentClassName}{newLine}Method Name : {parentMethodName}{newLine}Line Number : {lineNumber}{newLine}Message : {Message}{newLine}{separator}";
//        }
//    }




//    public class NLogWebApiService : BaseLogger
//    {
//        public NLogWebApiService(IConfiguration configuration)
//        {
//            bool simenabled = configuration.GetValue<bool>("SIEM-Ready-Log");
//            if (simenabled)
//            {
//                LogManager.Setup().LoadConfigurationFromFile("NLog.config");

//                Log = LogManager.GetLogger("JsonLogger");
//            }
//            else
//            {
//                Log = LogManager.GetLogger("NLogWebApiService");

//            }
//        }



//    }

//    public class WeatherForecastController : BaseLogger
//    {
//        public WeatherForecastController()
//        {
//            Log = LogManager.GetLogger("WeatherForecastController");
//        }
//    }
//    public class MQLog : BaseLogger
//    {
//        public MQLog()
//        {
//            Log = LogManager.GetLogger("MQLog");
//        }
//    }
//        private static (string className, string methodName, int lineNumber) ExtractCallerInfo()
//        {
//            string className = "Unknown", methodName = "Unknown";
//            int lineNumber = 0;

//            try
//            {
//                string[] ignored = ["Start", "AsyncMethodBuilderCore", "ExecutionContextCallback", "RunInternal", "RunOrScheduleAction", "Info", "FormStructuredLog"];
//                var stack = new StackTrace(true);

//                for (int i = 1; i < stack.FrameCount; i++)
//                {
//                    var frame = stack.GetFrame(i);
//                    var method = frame?.GetMethod();

//                    if (method?.DeclaringType != null && method.DeclaringType != typeof(BaseLogger) && !ignored.Contains(method.Name))
//                    {
//                        className = method.DeclaringType.Name;
//                        methodName = method.Name;
//                        lineNumber = frame.GetFileLineNumber();
//                        break;
//                    }
//                }
//            }
//            catch { }

//            return (className, methodName, lineNumber);
//        }


//    }

using NLog;
using System.Diagnostics;
using LogLevel = NLog.LogLevel;

namespace OpenFinanceWebApi.NLogService
{
    public class BaseLogger
    {
        private readonly IConfiguration _config;
        private readonly bool siemEnabled;
        public required Logger Log { get; set; }

        public BaseLogger(IConfiguration configuration)
        {
            _config = configuration;
            siemEnabled= _config.GetValue<bool>("SIEM-Ready-Log");
        }

        public void Debug(string message)
        {
            if (siemEnabled)
            {
                var (className, methodName, lineNumber) = ExtractCallerInfo();
                var logEvent = new LogEventInfo(LogLevel.Debug, Log.Name, message);

                logEvent.Properties["className"] = className;
                logEvent.Properties["methodName"] = methodName;
                logEvent.Properties["lineNumber"] = lineNumber;
                logEvent.Properties["stackTrace"] = message;

                Log.Log(logEvent);
            }
            else
            {
                Log.Debug(FormStructuredLog(message));

            }
        }

        public void Error(string message)
        {
            if (siemEnabled)
            {
                var (className, methodName, lineNumber) = ExtractCallerInfo();
                var logEvent = new LogEventInfo(LogLevel.Error, Log.Name, message);

                logEvent.Properties["className"] = className;
                logEvent.Properties["methodName"] = methodName;
                logEvent.Properties["lineNumber"] = lineNumber;
                logEvent.Properties["stackTrace"] = message;

                Log.Log(logEvent);
            }
            else
            {
                Log.Error(FormStructuredLog(message));
            }
        }

        public void Error(Exception ex, string storeProcedure)
        {
            bool siemEnabled = _config.GetValue<bool>("SIEM-Ready-Log");

            if (siemEnabled)
            {
                var (className, methodName, lineNumber) = ExtractCallerInfo();
                var logEvent = new LogEventInfo(LogLevel.Error, Log.Name, ex.Message);

                logEvent.Properties["className"] = className;
                logEvent.Properties["methodName"] = methodName;
                logEvent.Properties["lineNumber"] = lineNumber;
                logEvent.Properties["storedProcedure"] = storeProcedure;
                logEvent.Properties["stackTrace"] = ex.ToString();

                Log.Log(logEvent);
            }
            else
            {
                Log.Error(FormStructuredLog($"Exception: {ex.Message}", storeProcedure));

                if (ex.InnerException != null)
                {
                    Log.Error(FormStructuredLog($"InnerException: {ex.InnerException.Message}", storeProcedure));
                }
                Log.Error(FormStructuredLog($"StackTrace: {ex.StackTrace}", storeProcedure));
            }
        }

        public void Error(Exception ex)
        {
            Log.Error(FormStructuredLog($"Exception: {ex.Message}"));

            if (ex.InnerException != null)
            {
                Log.Error(FormStructuredLog($"InnerException: {ex.InnerException.Message}"));
            }

            Log.Error(FormStructuredLog($"StackTrace: {ex.StackTrace}"));
        }

        public void Info(string message)
        {
            if (siemEnabled)
            {
                var (className, methodName, lineNumber) = ExtractCallerInfo();
                var logEvent = new LogEventInfo(LogLevel.Info, Log.Name, message);

                logEvent.Properties["className"] = className;
                logEvent.Properties["methodName"] = methodName;
                logEvent.Properties["lineNumber"] = lineNumber;
                logEvent.Properties["stackTrace"] = message;

                Log.Log(logEvent);
            }
            else
            {
                Log.Info(FormStructuredLog(message));
            }
        }

        public void Warn(string message)
        {
            if (siemEnabled)
            {
                var (className, methodName, lineNumber) = ExtractCallerInfo();
                var logEvent = new LogEventInfo(LogLevel.Warn, Log.Name, message);

                logEvent.Properties["className"] = className;
                logEvent.Properties["methodName"] = methodName;
                logEvent.Properties["lineNumber"] = lineNumber;
                logEvent.Properties["stackTrace"] = message;

                Log.Log(logEvent);
            }
            else
            {
                Log.Warn(FormStructuredLog(message));
            }
           
        }

        public void Trace(string message)
        {
            if (siemEnabled)
            {
                var (className, methodName, lineNumber) = ExtractCallerInfo();
                var logEvent = new LogEventInfo(LogLevel.Trace, Log.Name, message);

                logEvent.Properties["className"] = className;
                logEvent.Properties["methodName"] = methodName;
                logEvent.Properties["lineNumber"] = lineNumber;
                logEvent.Properties["stackTrace"] = message;

                Log.Log(logEvent);
            }
            else
            {
                Log.Trace(FormStructuredLog(message));
            }
            
        }

        public static string FormStructuredLog(string message, string storeProcedure)
        {
            var (className, methodName, lineNumber) = ExtractCallerInfo();
            var newLine = "\r\n";
            var separator = "-------------------------------------------------------------------------------------";

            return $"{newLine}Class Name : {className}{newLine}Method Name : {methodName}{newLine}Line Number : {lineNumber}{newLine}StoreProcedure : {storeProcedure}{newLine}Message : {message}{newLine}{separator}";
        }

        public static string FormStructuredLog(string message)
        {
            var (className, methodName, lineNumber) = ExtractCallerInfo();
            var newLine = "\r\n";
            var separator = "-------------------------------------------------------------------------------------";

            return $"{newLine}Class Name : {className}{newLine}Method Name : {methodName}{newLine}Line Number : {lineNumber}{newLine}Message : {message}{newLine}{separator}";
        }

        private static (string className, string methodName, int lineNumber) ExtractCallerInfo()
        {
            string className = "Unknown", methodName = "Unknown";
            int lineNumber = 0;

            try
            {
                string[] ignored = [
                    "Start",
                    "AsyncMethodBuilderCore",
                    "ExecutionContextCallback",
                    "RunInternal",
                    "RunOrScheduleAction",
                    "Info",
                    "FormStructuredLog"
                ];

                var stack = new StackTrace(true);

                for (int i = 1; i < stack.FrameCount; i++)
                {
                    var frame = stack.GetFrame(i);
                    var method = frame?.GetMethod();

                    if (method?.DeclaringType != null &&
                        method.DeclaringType != typeof(BaseLogger) &&
                        !ignored.Contains(method.Name))
                    {
                        className = method.DeclaringType.Name;
                        methodName = method.Name;
                        lineNumber = frame.GetFileLineNumber();
                        break;
                    }
                }
            }
            catch
            {
                // Safe ignore
            }

            return (className, methodName, lineNumber);
        }
    }

    public class NLogWebApiService : BaseLogger
    {
        public NLogWebApiService(IConfiguration configuration) : base(configuration)
        {
            bool siemEnabled = configuration.GetValue<bool>("SIEM-Ready-Log");

            if (siemEnabled)
            {
                LogManager.Setup().LoadConfigurationFromFile("NLog.config");
                Log = LogManager.GetLogger("JsonLogger");
            }
            else
            {
                Log = LogManager.GetLogger("NLogWebApiService");
            }
        }
    }

    public class WeatherForecastController : BaseLogger
    {
        public WeatherForecastController(IConfiguration configuration) : base(configuration)
        {
            Log = LogManager.GetLogger("WeatherForecastController");
        }
    }

    public class MQLog : BaseLogger
    {
        public MQLog(IConfiguration configuration) : base(configuration)
        {
            Log = LogManager.GetLogger("MQLog");
        }
    }
}



