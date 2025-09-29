using Entities.LogMoniter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;
using OpenFinanceWebApi.Models;

namespace OpenFinanceWebApi.Controllers
{
    public class LogMoniterController : Controller
    {
        private readonly ILogMoniterService logMoniterService;
        private readonly NLogWebApiService _logger;
        public LogMoniterController(ILogMoniterService moniterService, NLogWebApiService logger)
        {
            logMoniterService = moniterService;
            _logger = logger;
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/LogMoniter/SaveLoginLogout")]
        public async Task SaveLoginLogout([FromBody] LogMoniterModel loginLogout)
        {
            try
            {
                if (loginLogout != null)
                {
                    await logMoniterService.SaveLoginLogout(loginLogout);

                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/LogMoniter/VerifyTransaction")]
        public async Task<int> VerifyTransaction([FromBody] TransactionApprovalRestriction approvalRestriction)
        {
            try
            {
                if (approvalRestriction != null)
                {
                    return await logMoniterService.VerifyTransaction(approvalRestriction);

                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return 0;
        }
    }
}
