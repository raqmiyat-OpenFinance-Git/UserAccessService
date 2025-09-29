namespace IPP_Connect.Models
{
    public class DailyServiceBillingReport
    {
        public List<DailyServiceBilling> dailyServiceBillingList { get; set; }
    }

    public class DailyServiceBilling

    {
        public string? ServiceName { get; set; }
        public string? VolumeValueSize { get; set; }
        public string? TotalChargeAmount { get; set; }
        public string? CreationDateTime { get; set; }
        public string? FileName { get; set; }
    }
}
