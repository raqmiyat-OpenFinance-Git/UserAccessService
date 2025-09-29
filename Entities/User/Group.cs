
using System;

namespace Raqmiyat.Entities.Login
{
    public class Group
    {

        public int GROUPDTL_CODE { get; set; }
        public string GROUPDTL_NAME { get; set; }
        public string GROUP_ACCESS { get; set; }
        public string ACTION_BY { get; set; }
        public DateTime ACTION_ON { get; set; }
        public string ACTION { get; set; }
        public string APPROVED_BY { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRoleAssigned { get; set; }      

    }

}
