using Entities.Common;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using OpenFinanceWebApi.Services;
using Raqmiyat.Entities.Login;
using System;
using System.Collections.Generic;



namespace OpenFinanceWebApi.Controllers
{
    public class TransactionAccessCheckerController : ControllerBase
    {

        private readonly ITransactionAccessCheckerService transactionAccessChecker;
        private readonly NLogWebApiService _logger;
        public TransactionAccessCheckerController(ITransactionAccessCheckerService txn, NLogWebApiService logger)//, IConfiguration config)
        {
            transactionAccessChecker = txn;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/TransactionAccessChecker/GetTransactionListCheck")]
        public IEnumerable<Txn> GetTransactionListCheck()
        {
            try
            {
                return transactionAccessChecker.GetTransactionList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
          
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/TransactionAccessChecker/ApproveTxn")]
        public ResponseStatus ApproveTxn([FromBody] Txn txn)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseval = transactionAccessChecker.ApproveTxn(txn);
                if (responseval.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseval.ToUpper();
                    responsestatus.statusMessage = responseval.ToUpper();
                    errorDetail.ErrorCode = "000";
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
        [Route("api/TransactionAccessChecker/GetTxnRoleCheck")]
        public Txn GetTxnRoleCheck(int id)
        {
            try
            {
                return transactionAccessChecker.GetTxnRole(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }
    }


}

