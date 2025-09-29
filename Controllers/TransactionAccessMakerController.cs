using Entities.Common;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using Pacs008.Request.Model;
using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.Controllers
{
    public class TransactionAccessMakerController : ControllerBase
    {
        private readonly ITransactionAccessMakerService transactionAccessMakerService;
        private readonly NLogWebApiService _logger;
        public TransactionAccessMakerController(ITransactionAccessMakerService txn, NLogWebApiService logger)//, IConfiguration config)
        {
            transactionAccessMakerService = txn;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/TransactionAccessMaker/GetTxn")]
        public IEnumerable<Txn> GetTransactionList(int id)
        {
            try
            {
                return transactionAccessMakerService.GetTransactionList(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/TransactionAccessMaker/AssignTxn")]
        public ResponseStatus AssignTxn([FromBody] Txn txn)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = transactionAccessMakerService.AssignTxn(txn);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseval.ToUpper() == " MAKER SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "222";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseval;
                    errorDetails.Add(errorDetail);
                }
            }
            catch (Exception ex)
            {
                errorDetail.ErrorCode = "400";
                errorDetail.ErrorDesc = "Exception " + ex.Message;
                errorDetails.Add(errorDetail);
                _logger.Error(ex);
            }
            responsestatus.errorDetails = errorDetails;
            return responsestatus;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/TransactionAccessMaker/GetTxnRole")]
        public IEnumerable<Role> GetTxnRole(int id)
        {
            try
            {
                return transactionAccessMakerService.GetTxnRole(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/TransactionAccessMaker/GetTxnByRole")]
        public IEnumerable<Txn> GetTxnByRole(int id)
        {
            try
            {
                return transactionAccessMakerService.GetTxnRoles(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/TransactionAccessMaker/GetRole")]
        public IEnumerable<Role> GetRole(int id)
        {
            try
            {
                return transactionAccessMakerService.GetRole(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/TransactionAccessMaker/GetPrdList")]
        public IEnumerable<ProductList_Tnx> GetPrdList()
        {
            try
            {
                return transactionAccessMakerService.GetPrdList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }


    }
}
