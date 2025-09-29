namespace Raqmiyat.Entities.Login
{
    public class ProductList
    {
        public int Id { get; set; }                       // int IDENTITY (PK candidate)
        public int ProductId { get; set; }                // int NOT NULL
        public string? ProductName { get; set; }          // nvarchar(50) NULL
        public bool? LoginDisplay { get; set; }           // bit NULL
        public bool? UserDisplay { get; set; }            // bit NULL
        public bool? IsDeleted { get; set; }              // bit NULL
        public string? ControllerName { get; set; }       // nvarchar(100) NULL
        public string? ActionName { get; set; }           // nvarchar(100) NULL
        public string? AppUrl { get; set; }               // nvarchar(100) NULL
        public DateTime? CreatedDate { get; set; }        // datetime NULL
        public string? CreatedUser { get; set; }          // nvarchar(50) NULL
        public DateTime? ModifiedDate { get; set; }       // datetime NULL
        public string? ModifiedUser { get; set; }         // nvarchar(50) NULL
    }
}
