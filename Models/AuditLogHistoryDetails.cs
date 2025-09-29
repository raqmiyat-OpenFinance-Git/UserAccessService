namespace OpenFinanceWebApi.Models
{
    public class AuditLogHistoryDetails
    {
        public string UserName { get; set; }
        public string SourceIP { get; set; }
        public string Source_Host { get; set; }
        public string DestinationIP { get; set; }
        public string TransactionName { get; set; }
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
