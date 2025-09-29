using Raqmiyat.Entities.GNRList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
namespace Entities.Master
{
    public class ChargeMasterMakerModel
    {
        public int SegID { get; set; }
        public string SegmentID { get; set; }
        public string SegmentName { get; set; }
        public string TransactionType { get; set; }
        public string Msg_Type { get; set; }
        public string Outward_Charges_Amount { get; set; }
        public string Inward_Charges_Amount { get; set; }
        public string ChargesStatus { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public bool IsDeleted { get; set; }
        public string action { get; set; }
        public string Approved_By { get; set; }
        public string Approved_on { get; set; }
        public string ActionBy { get; set; }
        public string gnarr_list_id { get; set; }
        public string general_list_id { get; set; }
        public List<GeneralList> gnarrList { get; set; }
    }
}
