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
        public ActionResult<string> SaveAssignRole([FromBody] AssignRoleModel assignRoleModel)
        {
           string result = string.Empty;

            try
            {
                result = _assignRoleMakerService.SaveAssignRole(assignRoleModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return Ok(result);
        }
    }
}
