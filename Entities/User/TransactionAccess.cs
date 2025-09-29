namespace Raqmiyat.Entities.Login
{
    public class TransactionAccess
    {
        public int TranId { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int ProductId { get; set; }
        public bool IsAccess { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string? ActionBy { get; set; }
        public DateTime? ActionOn { get; set; } = DateTime.Now;

        public string? UserAction { get; set; }

        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }

        public string? MenuName { get; set; }
        public string? ModuleName { get; set; }
        public bool AccessValue { get; set; }
        public bool OldAccessValue { get; set; }
    }
}
