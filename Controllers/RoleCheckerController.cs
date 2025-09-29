
using Microsoft.AspNetCore.Mvc;

using OpenFinanceWebApi.Services;
using OpenFinanceWebApi.IServices;
using Raqmiyat.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi1.Controllers
{
    public class RoleCheckerController : Controller
    {
        private readonly IRoleCheckerService roleCheckerService;
        private readonly NLogWebApiService _logger;
        public RoleCheckerController(IRoleCheckerService Userchecker, NLogWebApiService logger)
        {
            roleCheckerService = Userchecker;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/RoleChecker/GetRoleChecker")]
        public IEnumerable<Role> CheckerGetRole()
        {
            try
            {
                return roleCheckerService.GetRole();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/RoleChecker/ApproveOrRejectRole")]
        public bool RejectOrApproveRole([FromBody] Role roleviewmodel)
        {
            bool returnValue = false;
            try
            {
                if (roleviewmodel != null)
                {
                    int count = roleCheckerService.ApproveOrReject(roleviewmodel);
                    if (count > 0)
                    {
                        returnValue = true;

                    }
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return returnValue;
            }

        }

        [HttpPost]
        [Route("api/RoleChecker/GetSearchCheckRoleDetails")]
        public IEnumerable<Role> GetSearchCheckRoleDetails([FromBody] Role role)
        {
            try
            {
                return roleCheckerService.GetSearchCheckRoleDetails(role);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
    }
}
