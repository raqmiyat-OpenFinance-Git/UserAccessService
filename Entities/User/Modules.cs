namespace Raqmiyat.Entities.Login
{
    public class Modules
    {
        public int ModuleId { get; set; }                  // INT IDENTITY (PK)
        public string ModuleName { get; set; } = null!;    // NVARCHAR(100) NOT NULL
        public string? Description { get; set; }           // NVARCHAR(255) NULL
        public bool IsActive { get; set; }                 // BIT NOT NULL DEFAULT 1
        public DateTime CreatedDate { get; set; }          // DATETIME NOT NULL DEFAULT GETDATE()
        public DateTime? ModifiedDate { get; set; }        // DATETIME NULL
        public int ProductId { get; set; }                 // INT
    }
}
