namespace UserAccessService.Models
{
    public class FRMMENU
    {
        public int MenuID { get; set; }              // numeric in SQL
        public string ModuleName { get; set; }           // varchar
        public string MenuName { get; set; }             // varchar
        public string ControllerName { get; set; }       // varchar
        public string IndexName { get; set; }            // varchar
        public int? ItemOrder { get; set; }              // int (nullable)
        public short? ModuleOrder { get; set; }          // smallint (nullable)
        public bool? IsDeleted { get; set; }             // bit (nullable)
        public int? ProductID { get; set; }              // int (nullable)
    }
}
