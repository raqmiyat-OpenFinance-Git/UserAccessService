using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.IServices
{
    public interface ITransactionAccessCheckerService

    {
        IEnumerable<Txn> GetTransactionList();

        string ApproveTxn(Txn txn);

        Txn GetTxnRole(int id);
    }
}
