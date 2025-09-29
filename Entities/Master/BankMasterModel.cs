using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Entities.Master
{
    public class BankMasterModel
    {
        public string BM_Country_Id { get; set; }
        public string BM_Bank_Id { get; set; }
        public string BM_Bank_Name { get; set; }

        public string BM_Bank_ShortName { get; set; }

        public string BM_Operation_Incharge { get; set; }

        public string BM_Phone_No { get; set; }

        public string BM_IsExpressClg { get; set; }

        public int BM_Rec_Id { get; set; }

        public bool BM_Bank_Status { get; set; }
        public bool BM_IsDeleted { get; set; }

        public string Action { get; set; }
        public string Action_By { get; set; }
        public DateTime BM_Approved_On { get; set; }
        public bool BM_IsApproved { get; set; }
        public bool BM_IsRejected { get; set; }
        public string BM_Approved_By { get; set; }
    }
}
