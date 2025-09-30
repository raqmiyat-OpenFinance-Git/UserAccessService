namespace Raqmiyat.Entities.Login
{
    public class AssignRoleListHistory
    {
        public int Role_Id { get; set; }
        public int Module_Id { get; set; }
        public string? ModuleName { get; set; }
        public string? MenuName { get; set; }
        public bool OAccess { get; set; }
        public bool NAccess { get; set; }
        public string? popupcategory { get; set; }
        public string? itemcategory { get; set; }

    }
}
