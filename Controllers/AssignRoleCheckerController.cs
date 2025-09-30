using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
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

        [HttpGet("GetAssignRoleListAsync")]
        public ActionResult<IEnumerable<TransactionAccessCheck>> GetAssignRoleListAsync()
        {
            try
            {
                return Ok(_assignRoleCheckerService.GetAssignRoleListAsync());
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return StatusCode(500, "An error occurred while fetching product lists.");
            }
        }
        [HttpGet("GetAssignRoleHistoryAsync")]
        public ActionResult<IEnumerable<AssignRoleListHistory>> GetAssignRoleHistoryAsync(int roleId)
        {
            try
            {
                return Ok(_assignRoleCheckerService.GetAssignRoleHistoryAsync(roleId));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return StatusCode(500, "An error occurred while fetching product lists.");
            }
        }
        [HttpPost("Approve")]
        public async Task<ActionResult<string>> ApproveAsync([FromBody] AssignRoleModel assignRoleModel)
        {
            string result = string.Empty;

            try
            {
                result = await _assignRoleCheckerService.Approve(assignRoleModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return Ok(result);
        }
        [HttpPost("Reject")]
        public async Task<ActionResult<string>> RejecteAsync([FromBody] AssignRoleModel assignRoleModel)
        {
            string result = string.Empty;

            try
            {
                result = await _assignRoleCheckerService.Reject(assignRoleModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return Ok(result);
        }
    }
}
