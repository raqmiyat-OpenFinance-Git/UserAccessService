namespace OpenFinanceWebApi.Models
{
    public class Pacs008SuccessfulReport
    {
        public string? Creation_Date { get; set; }
        public string? Ref_No { get; set; }
        public string? Amount { get; set; }
        public string? PSRBDET_IntraBank_Settle_Date { get; set; }        
        public string? BATDET_Creditor_IBAN { get; set; }
        public string? Status { get; set; }
    }
}
