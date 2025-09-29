using Entities.Master;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Entities.Login;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenFin_User_Management_WebApi.IServices
{
    public class ProductMasterService : IProductMasterService
    {
         readonly SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public ProductMasterService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public List<ProductMasterModel> GetProductList(string userCode)
        {
           // _logger.Info("ProductMasterService", "GetProductList", "----------Start----------");
            var productmasterlist = new List<ProductMasterModel>();
            try
            {
               
                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_get_productList", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar));
                Command.Parameters[0].Value = userCode;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        ProductMasterModel productmastermodel = new ProductMasterModel();
                        productmastermodel.Product_ID = objReader["Product_ID"] == null ? 0 : Convert.ToInt32(objReader["Product_ID"]);
                        productmastermodel.Product_Name = objReader["Product_Name"] == null ? string.Empty : Convert.ToString(objReader["Product_Name"]);
                        productmastermodel.Controller_Name = objReader["Controller_Name"] == null ? string.Empty : Convert.ToString(objReader["Controller_Name"]);
                        productmastermodel.Action_Name = objReader["Action_Name"] == null ? string.Empty : Convert.ToString(objReader["Action_Name"]);
                        productmastermodel.App_Url = objReader["App_Url"] == null ? string.Empty : Convert.ToString(objReader["App_Url"]);
                        productmasterlist.Add(productmastermodel);
                    }
                }

            }
            catch (Exception ex)
            {
              //  _logger.Error("ProductMasterService", "GetProductList", "frm_sp_get_productList", ex.Message);

            }
            //_logger.Info("ProductMasterService", "GetProductList", "----------End----------");
            return productmasterlist;
        }

    }
}
