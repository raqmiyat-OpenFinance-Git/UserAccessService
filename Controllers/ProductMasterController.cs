using Entities.Master;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenFin_User_Management_WebApi.IServices;
using OpenFinanceWebApi.NLogService;

namespace OpenFin_User_Management_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMasterController : ControllerBase
    {
        private readonly IProductMasterService productmasterservice;
        private readonly NLogWebApiService _logger;


        public ProductMasterController(IProductMasterService prodctmasterSer, NLogWebApiService logger)
        {
            _logger = logger;
            productmasterservice = prodctmasterSer;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/ProductMaster/GetProductList")]
        public List<ProductMasterModel> GetProductList(string userCode)
        {
           // _logger.Info("ProductMasterController", "GetProductList", "----------Start----------");
            try
            {
                //_logger.Info("ProductMasterController", "GetProductList", "----------End----------");
                return productmasterservice.GetProductList(userCode);

            }
            catch(Exception ex) 
            {
                //_logger.Error("ProductMasterController", "GetProductList", "", ex.Message);
            }
            return productmasterservice.GetProductList(userCode);
        }
    }
}
