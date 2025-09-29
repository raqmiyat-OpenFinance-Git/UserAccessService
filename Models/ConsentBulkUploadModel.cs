namespace OpenFinance.Models
{
    public class ConsentBulkUploadModel
    {
        public List<ConsetBulkUploadindividual> ConsentBulkList { get; set; }
    }
    public class ConsetBulkUploadindividual
    {
        public string PSUID { get; set; }
        public string TPPName { get; set; }
        public string ScopedGranted { get; set; }
        public string linkedAccounts { get; set; }
        public string ConsentValidity { get; set; }
        public bool Multi_User { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }
}
