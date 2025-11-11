using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using OpenFinanceWebApi.Services;
using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignRoleCheckerController : ControllerBase
    {
        private readonly IAssignRoleCheckerService _assignRoleCheckerService;
        private readonly NLogWebApiService _logger;
        public AssignRoleCheckerController(IAssignRoleCheckerService assignRoleCheckerService, NLogWebApiService logger)//, IConfiguration config)
        {
            _assignRoleCheckerService = assignRoleCheckerService;
            _logger = logger;
        }

        [HttpGet("GetAssignRoleList")]
        public ActionResult<IEnumerable<TransactionAccessCheck>> GetAssignRoleList()
        {
            try
            {
                return Ok(_assignRoleCheckerService.GetAssignRoleList());
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return StatusCode(500, "An error occurred while fetching product lists.");
            }
        }

        [HttpPost]
        [Route("GetSearchAssignRoleDetails")]
        public IEnumerable<TransactionAccessCheck> GetSearchRoleDetails(TransactionAccessCheck role)
        {
            try
            {
                return _assignRoleCheckerService.GetSearchRoleDetails(role);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet("GetAssignRoleHistory")]
        public ActionResult<IEnumerable<AssignRoleListHistory>> GetAssignRoleHistory(int roleId)
        {
            try
            {
                return Ok(_assignRoleCheckerService.GetAssignRoleHistory(roleId));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return StatusCode(500, "An error occurred while fetching product lists.");
            }
        }
        [HttpPost("Approve")]
        public ActionResult<string> Approve([FromBody] AssignRoleModel assignRoleModel)
        {
            string result = string.Empty;

            try
            {
                result = _assignRoleCheckerService.Approve(assignRoleModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return Ok(result);
        }
        [HttpPost("Reject")]
        public ActionResult<string> Reject([FromBody] AssignRoleModel assignRoleModel)
        {
            string result = string.Empty;

            try
            {
                result = _assignRoleCheckerService.Reject(assignRoleModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return Ok(result);
        }
    }
}
