namespace OpenFinanceWebApi.Models
{
    public class TransactionApprovalRestriction
    {
        public long Id { get; set; }
        public string? RefId { get; set; } 
        public string? TrnName { get; set; } 
        public string? ActionBy { get; set; } 
        public string? Action { get; set; } 
    }
}
