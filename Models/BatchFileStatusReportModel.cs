namespace OpenFinanceWebApi.Models
{
    public class BatchFileStatusReportModel
    {
        public List<BatchFileStatusReport>? batchFileStatusReport { get; set; }

    }

    public class BatchFileStatusReport
    {
        public string? BatchReference { get; set; }
        public string? CycleNumber { get; set; }
        public string? FSVD { get; set; }
        public string? SubmissionTime { get; set; }
        public string? CompletionTime { get; set; }
        public string? NumberofFSIs { get; set; }
        public string? NumberofPayments { get; set; }
        public string? Amount { get; set; }
        public string? Status { get; set; }

    }

}
