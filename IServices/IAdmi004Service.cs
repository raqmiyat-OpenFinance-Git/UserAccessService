using Entities.Admi004;

namespace OpenFinanceWebApi.IServices
{
    public interface IAdmi004Service
    {
        bool AddAdmi004(Admi004Checker admi004);
        string UpdateAdmi004(Admi004 admi004);
        Task<List<Admi004Checker>> GetAdmi004(int id);
        Task<List<Admi004Checker>> GetAdmi004Inward();
        Task<List<Admi004Checker>> GetAdmi004Maker(int id);
        Admi004 GetAdmi004Details(string Id);
    }
}
