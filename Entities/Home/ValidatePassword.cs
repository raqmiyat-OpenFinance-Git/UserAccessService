namespace Entities.Home
{
    public class ValidatePassword
    {
        public bool Complex { get; set; }

        public int Maximum_Lenth { get; set; }

        public int Minimum_Lenth { get; set; }

        public int ExpiryDate { get; set; }

        public int ReminderDate { get; set; }

        public int Uppercase { get; set; }

        public int HistoryRecords { get; set; }

        public int NoOfAttempts { get; set; }

    }
}
