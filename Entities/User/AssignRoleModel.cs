namespace Raqmiyat.Entities.Login
{
    public class AssignRoleModel
    {
        public int ProductId { get; set; }
        public int ModuleId { get; set; }
        public int RoleId { get; set; }
        public string? ModuleName { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public string? Action { get; set; }
        public string? ActionOn { get; set; }
        public string? ActionBy { get; set; }
        public List<CheckBoxModel>? CheckBoxItems { get; set; }
        public List<Role>? roleList { get; set; }
        public List<Modules>? moduleList { get; set; }
        public List<TransactionAccess>? transactionAccesses { get; set; }
    }
}
