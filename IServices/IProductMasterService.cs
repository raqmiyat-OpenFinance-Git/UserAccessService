using Entities.Master;
using Raqmiyat.Entities.Login;

namespace OpenFin_User_Management_WebApi.IServices
{
    public interface IProductMasterService
    {
       List< ProductMasterModel> GetProductList(string userCode);
    }
}
