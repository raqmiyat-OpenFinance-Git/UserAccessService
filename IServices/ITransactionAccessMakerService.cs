using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.IServices
{
    public interface ITransactionAccessMakerService
    {
        IEnumerable<Txn> GetTransactionList(int id);
        string AssignTxn(Txn txn);
        IEnumerable<Role> GetTxnRole(int id);
        IEnumerable<Txn> GetTxnRoles(int id);
        IEnumerable<Role> GetRole(int id);
        IEnumerable<ProductList_Tnx> GetPrdList();
    }
}
