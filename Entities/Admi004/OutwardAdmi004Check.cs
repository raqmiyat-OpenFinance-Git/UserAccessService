using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Admi004
{
    [Table("ipp_owd_Admi004_check")]
    public class OutwardAdmi004Check
    {
        [Key]

        public int EvtREFID { get; set; }
        public string EvtBICCode { get; set; }
        public string EvtStart { get; set; }
        public string EvtEnd { get; set; }
        public string EvtDesc { get; set; }
        public bool EvtDeleted { get; set; }
        public string Action { get; set; }
        public DateTime Action_On { get; set; } = DateTime.Now;
        public string Action_By { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public string Approved_By { get; set; }
        public DateTime Approved_on { get; set; } = DateTime.Now;
        public string EvtStatus { get; set; }
    }
}
