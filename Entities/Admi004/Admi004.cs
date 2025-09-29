using System;

namespace Entities.Admi004
{
    public class Admi004
    {
        public int EvtREFID { get; set; }
        public string EvtBICCode { get; set; }
        public string EvtStart { get; set; }
        public string EvtEnd { get; set; }
        public string EvtDesc { get; set; }
        public bool EvtDeleted { get; set; }
        public string EvtStatus { get; set; }
        public string Action { get; set; }
        public string AppUserID { get; set; }
        public string RejectReason { get; set; }
    }

    public class Admi004Checker
    {
        public int Id { get; set; }
        public string BICCode { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public bool? Deleted { get; set; }
        public string? RejectReason { get; set; }
        public string Action { get; set; }
    }
}
