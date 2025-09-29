

using System;

namespace Entities.Error_Master
{
    public class ErrorMasterModel
    {
        public int ID { get; set; }
        public string Reject_Reason_Code { get; set; }
        public string Reject_Type { get; set; }
        public string Reject_Reason { get; set; }
        public string Trxn_Name { get; set; }
        public bool Active_Status { get; set; }
        public string CREATEDBY { get; set; }
        public string CREATEDON { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime MODIFIEDON { get; set; }
        public string ACTION { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public string APPROVED_BY { get; set; }
        public DateTime APPROVED_ON { get; set; }
        public bool ISDeleted { get; set; }
        public string Error_Type { get; set; }
        public string Accessibility { get; set; }
    }
    public class ErrorTypeModel
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class ErrorCode
    {
        public string General_List_Type { get; set; }
        public string General_List_Code { get; set; }
        public string General_Desc_English { get; set; }
    }

}
