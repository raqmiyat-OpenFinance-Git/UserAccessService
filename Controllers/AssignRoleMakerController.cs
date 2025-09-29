using Entities.Common;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using Pacs008.Request.Model;
using Raqmiyat.Entities.Login;

namespace OpenFinanceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignRoleMakerController : ControllerBase
    {
        private readonly IAssignRoleMakerService _assignRoleMakerService;
        private readonly NLogWebApiService _logger;
        public AssignRoleMakerController(IAssignRoleMakerService assignRoleMakerService, NLogWebApiService logger)//, IConfiguration config)
        {
            _assignRoleMakerService = assignRoleMakerService;
            _logger = logger;
        }


        [HttpGet("GetProductLists")]
        public ActionResult<IEnumerable<ProductList>> GetProductLists()
        {
            try
            {
                return Ok(_assignRoleMakerService.GetProductLists());
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return StatusCode(500, "An error occurred while fetching product lists.");
            }
        }




        [HttpGet("GetModulesById")]
      
        public ActionResult<IEnumerable<Modules>> GetModulesById(int productId)
        {
            try
            {
                return Ok(_assignRoleMakerService.GetModulesById(productId));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            
        }
        [HttpGet("GetMenusById")]
        public ActionResult<IEnumerable<Menus>> GetMenusById(int productId)
        {
            try
            {
                return Ok(_assignRoleMakerService.GetMenusById(productId));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet("GetRolesById")]
        public ActionResult<IEnumerable<Role>> GetRolesById(int productId)
        {
            try
            {
                return Ok(_assignRoleMakerService.GetRolesById(productId));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        
        [HttpGet("GetTransactionAccesses")]
        public ActionResult<IEnumerable<TransactionAccess>> GetTransactionAccesses(int productId, int moduleId, int roleId)
        {
            try
            {
                return Ok(_assignRoleMakerService.GetTransactionAccesses(productId, moduleId, roleId));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpPost("SaveAssignRole")]
        public ActionResult<ResponseStatus> SaveAssignRole([FromBody] AssignRoleModel assignRoleModel)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();

            try
            {
                var responseval = _assignRoleMakerService.SaveAssignRole(assignRoleModel)?.Trim().ToUpperInvariant();

                if (responseval == "SUCCESS")
                {
                    responsestatus.status = "SUCCESS";
                    responsestatus.statusMessage = "SUCCESS";
                    errorDetails.Add(new ErrorDetail { ErrorCode = "000", ErrorDesc = "" });
                }
                else if (responseval == "MAKER SUCCESS")
                {
                    responsestatus.status = "MAKER SUCCESS";
                    responsestatus.statusMessage = "MAKER SUCCESS";
                    errorDetails.Add(new ErrorDetail { ErrorCode = "222", ErrorDesc = "" });
                }
                else
                {
                    errorDetails.Add(new ErrorDetail { ErrorCode = "401", ErrorDesc = responseval ?? "Unknown error" });
                }
            }
            catch (Exception ex)
            {
                errorDetails.Add(new ErrorDetail { ErrorCode = "400", ErrorDesc = "An unexpected error occurred." });
                _logger.Error(ex);
            }

            responsestatus.errorDetails = errorDetails;
            return Ok(responsestatus);
        }
    }
}
