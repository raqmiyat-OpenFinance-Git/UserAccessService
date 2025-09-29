using Entities.General;

namespace OpenFinanceWebApi.Models
{
    public class UserAccessReport
    {
        public int? TXNATTRIBS_TXNID { get; set; }

        public string? TXNATTRIBS_TXNNAME { get; set; }
        public string? TXNATTRIBS_PARENT_TXNID { get; set; }
        public string? TXNATTRIBS_PARENT_NAME { get; set; }
        public string? TXNATTRIBS_CATEGORY { get; set; }
        public string? TXNATTRIBS_ACCESS { get; set; }
        public string TXNATTRIBS_CATEGORY_ORDER { get; set; }
        public string? TXNATTRIBS_DISPLAYLIST { get; set; }
        public string? UserName { get; set; }
    }
}
