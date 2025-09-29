using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Master
{
    public class EmailGroupMasterModel
    {
        public int COUNTRY_ID { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string COUNTRY_NAME { get; set; }
        public string CURRENCY_CODE { get; set; }
        public string ACTION { get; set; }
        public string ACTION_BY { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime MODIFIED_On { get; set; }
        public string MODIFIED_By { get; set; }
        public DateTime APPROVED_ON { get; set; }
        public string APPROVED_BY { get; set; }
        public bool ISAPPROVED { get; set; }
        public bool ISREJECTED { get; set; }
        public string STATUS { get; set; }
        public string EmailModule { get; set; }
        public string emailaddress { get; set; }
        public string ID { get; set; }
        public List<EmailModule> EmailModuleList { get; set; }
    }
    public class EmailModule
    {
        public string Email_Module { get; set; }
    }
}
