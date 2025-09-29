using System.ComponentModel.DataAnnotations;

namespace NPSS_Connect.Models
{
    public class DashBoard
    {
        public string ENT_MODULE { get; set; }
        public string ENT_SubModule { get; set; }
        public string Total { get; set; }
        public string Sent_to_CB { get; set; }
        public string Accepted { get; set; }
        public string Rejected { get; set; }
        public string Pending { get; set; }
        public string Reserve_Posting { get; set; }
        public string Debit_Posting { get; set; }
        public string Credit_Posting { get; set; }
        public string Reserve_Failed { get; set; }
        


    }
}
