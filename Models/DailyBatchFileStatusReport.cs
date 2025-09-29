namespace IPP_Connect.Models
{
    public class DailyBatchFileStatusReport
    {
        public List<DailyBatchFileStatus> dailyBatchFileStatusList { get; set; } 
    }

    public class DailyBatchFileStatus
    {
        public string? BatchReference { get; set; }
        public string? CycleNumber { get; set; }
        public string? FSVD { get; set; }
        public string? SubmissionTime { get; set; }
        public string? CompletionTime { get; set; }
        public string? NumberOfFSIs { get; set; }
        public string? NumberOfPayments { get; set; }
        public string? Amount { get; set; }
        public string? Status { get; set; }
        public string? CreationDateTime { get; set; }
        public string? FileName { get; set; }
    }
}
