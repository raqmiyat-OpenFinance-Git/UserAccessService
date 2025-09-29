using NLog;

namespace OpenFinanceWebApi.Custom
{
    
    static class NLogger
    {
        public static NLog.Logger GetNLogger { get; }
        static NLogger()
        {
            GetNLogger = LogManager.GetLogger("NPSSLogger");
        }
    }

}