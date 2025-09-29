using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.IServices
{
    public interface IAssignRoleMakerService
    {
        IEnumerable<ProductList> GetProductLists();
        IEnumerable<Modules> GetModulesById(int productId);
        IEnumerable<Menus> GetMenusById(int productId);
        IEnumerable<Role> GetRolesById(int productId);
        IEnumerable<TransactionAccess> GetTransactionAccesses(int productId, int moduleId, int roleId);
        string SaveAssignRole(AssignRoleModel assignRoleModel);
    }
}
