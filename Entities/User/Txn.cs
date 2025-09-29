
using System;

namespace Raqmiyat.Entities.Login
{
    public class Txn
    {       
        public int TXNATTRIBS_TXNID { get; set; }
        public string TXNATTRIBS_TXNNAME { get; set; }
        public string TXN_ACCESS { get; set; }
        public string ACTION_BY { get; set; }
        public DateTime ACTION_ON { get; set; }
        public string ACTION { get; set; }
        public string APPROVED_BY { get; set; }
        public DateTime APPROVED_ON { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public string Pre_Txnaccess_Name { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
    }


}
