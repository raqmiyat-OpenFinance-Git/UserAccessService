using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.LogMoniter
{
    public class LogMoniterModel
    {
        public string User_Id { get; set; }
        public string AccessSourceIP { get; set; }
        public string AccessSourceHost { get; set; }
        public string SessionID { get; set; }
        public string Access_action { get; set; }
        public string Access_Description { get; set; }
        public string Server_HostName { get; set; }
        public string ServerIP { get; set; }
        public string ServerIPMac { get; set; }
        public string TransactionName { get; set; }
    }
}
