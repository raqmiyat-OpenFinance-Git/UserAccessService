namespace Raqmiyat.Entities.Login
{
    public class Menus
    {
        public decimal MenuId { get; set; }            // numeric(9,0) IDENTITY
        public string? ModuleName { get; set; }        // varchar(50) NULL
        public string MenuName { get; set; } = null!;  // varchar(100) NOT NULL
        public string ControllerName { get; set; } = null!; // varchar(100) NOT NULL
        public string IndexName { get; set; } = null!; // varchar(100) NOT NULL
        public int? ItemOrder { get; set; }            // int NULL
        public short? ModuleOrder { get; set; }        // smallint NULL
        public bool? IsDeleted { get; set; }           // bit NULL
        public int ProductId { get; set; }             // int NOT NULL (default since no NULL specified)
    }
}
