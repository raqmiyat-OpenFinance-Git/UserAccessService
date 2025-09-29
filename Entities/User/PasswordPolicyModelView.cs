using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.User
{
    public class PasswordPolicyModelView
    {
        public string CountryName { get; set; }
        public string BankName { get; set; }
        public string Branch_Id { get; set; }
        public string Password_Id { get; set; }
        public bool Complex { get; set; }
        public string Maximum_Lenth { get; set; }
        public string Minimum_Lenth { get; set; }
        public string ExpiryDate { get; set; }
        public string ReminderDate { get; set; }
        public string Uppercase { get; set; }
        public string HistoryRecords { get; set; }
        public string NoOfAttempts { get; set; }
        public string Action { get; set; }
        public string OutPutDesc { get; set; }
        public string Action_By { get; set; }

        public string CreatedBy { get; set; }

    }

}
