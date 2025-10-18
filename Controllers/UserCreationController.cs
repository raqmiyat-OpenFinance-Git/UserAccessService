using Entities.Common;
using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Entities.Login;
using UserAccessService.Models;
using User = UserAccessService.Models.User;

namespace OpenFinanceWebApi.Controllers
{
    public class UserCreationController : Controller
    {
        private readonly IUserCreationService _userCreationService;
        private readonly NLogWebApiService _logger;

        public UserCreationController(IUserCreationService CreationService, NLogWebApiService logger)
        {
            _userCreationService = CreationService;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/UserCreation/ProductLists")]
        public IEnumerable<ProductLists> ProductLists()
        {
            try
            {
                _logger.Info("ProductLists is Invoked.");
                return _userCreationService.GetProductLists();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/UserCreation/GetRoleList")]
        public IEnumerable<RoleList> GetRoleList()
        {
            try
            {
                _logger.Info("GetRoleList is Invoked.");

                return _userCreationService.GetRoleLists();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/UserCreation/GetRoleByUserCode")]
        public IEnumerable<RoleList> GetRoleByUserCode(int Id)
        {
            try
            {
                _logger.Info("GetRoleByUserCode is Invoked.");
                return _userCreationService.GetRoleByUserCode(Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/UserCreation/AddUser")]
        public ResponseStatus AddUser([FromBody] UserMaker obj)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseVal = _userCreationService.AddUser(obj);
                if (responseVal.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseVal.ToUpper();
                    responsestatus.statusMessage = responseVal.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseVal.ToUpper() == "MAKERSUCCESS")
                {
                    responsestatus.status = responseVal.ToUpper();
                    responsestatus.statusMessage = responseVal.ToUpper();
                    errorDetail.ErrorCode = "111";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseVal;
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

        [HttpPost]
        [Route("[action]")]
        [Route("api/UserCreation/UpdateUser")]
        public ResponseStatus UpdateUser([FromBody] UserMaker postData)
        {

            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseVal = _userCreationService.UpdateUser(postData);
                if (responseVal.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseVal.ToUpper();
                    responsestatus.statusMessage = responseVal.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseVal.ToUpper() == "MAKERSUCCESS")
                {
                    responsestatus.status = responseVal.ToUpper();
                    responsestatus.statusMessage = responseVal.ToUpper();
                    errorDetail.ErrorCode = "111";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseVal;
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

        [HttpPost]
        [Route("[action]")]
        [Route("api/UserCreation/DeleteUser")]
        public ResponseStatus DeleteUser([FromBody] UserMaker postData)
        {

            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseVal = _userCreationService.DeleteUser(postData);
                if (responseVal.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseVal.ToUpper();
                    responsestatus.statusMessage = responseVal.ToUpper();
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else if (responseVal.ToUpper() == "MAKERSUCCESS")
                {
                    responsestatus.status = responseVal.ToUpper();
                    responsestatus.statusMessage = responseVal.ToUpper();
                    errorDetail.ErrorCode = "111";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseVal;
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

        [HttpPost("UpdateProfile")]
        public ResponseStatus UpdateProfile([FromBody] User user)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseVal = _userCreationService.UpdateUserProfile(user);
                if (responseVal.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseVal.ToUpper();
                    responsestatus.statusMessage = "Profile updated successfully";
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    responsestatus.status = "FAILED";
                    responsestatus.statusMessage = "Profile update failed";
                    errorDetail.ErrorCode = "401";
                    errorDetail.ErrorDesc = responseVal;
                    errorDetails.Add(errorDetail);
                }
            }
            catch (Exception ex)
            {
                responsestatus.status = "ERROR";
                responsestatus.statusMessage = "System error occurred";
                errorDetail.ErrorCode = "400";
                errorDetail.ErrorDesc = "Exception: " + ex.Message;
                errorDetails.Add(errorDetail);
                _logger.Error(ex, "Error in UpdateProfile for user: {UserCode}" + user?.UserCode);
            }
            responsestatus.errorDetails = errorDetails;
            return responsestatus;
        }

        [HttpPost("RemoveProfileImage")]
        public ResponseStatus RemoveProfileImage([FromBody] string userCode) // Fixed parameter
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {
                var responseVal = _userCreationService.RemoveProfileImage(userCode);
                if (responseVal.ToUpper() == "SUCCESS")
                {
                    responsestatus.status = responseVal.ToUpper();
                    responsestatus.statusMessage = "Profile image removed successfully";
                    errorDetail.ErrorCode = "000";
                    errorDetail.ErrorDesc = "";
                    errorDetails.Add(errorDetail);
                }
                else
                {
                    responsestatus.status = "FAILED";
                    responsestatus.statusMessage = "Profile image removal failed";
                    errorDetail.ErrorCode = "403";
                    errorDetail.ErrorDesc = responseVal;
                    errorDetails.Add(errorDetail);
                }
            }
            catch (Exception ex)
            {
                responsestatus.status = "ERROR";
                responsestatus.statusMessage = "System error occurred";
                errorDetail.ErrorCode = "400";
                errorDetail.ErrorDesc = "Exception: " + ex.Message;
                errorDetails.Add(errorDetail);
                _logger.Error(ex, "Error in RemoveProfileImage for user: {UserCode}" + userCode);
            }
            responsestatus.errorDetails = errorDetails;
            return responsestatus;
        }

        [HttpGet("GetUserProfile")] // Fixed route parameter name
        public User GetUserProfile(string UserCode) // Fixed parameter name
        {
            var user = new User();
            try
            {
                user = _userCreationService.GetUserProfile(UserCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in GetUserProfile for user: {UserCode}" + UserCode);
            }
            return user;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/UserCreation/GetUserLists")]
        public IEnumerable<UserMaker> GetUserLists()
        {
            try
            {
                return _userCreationService.GetUserLists();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/UserCreation/SearchUserLists")]
        public IEnumerable<UserMaker> SearchUserLists(string UserName)
        {
            try
            {
                return _userCreationService.SearchUserLists(UserName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/UserCreation/GetIndividualUserList")]
        public UserMaker GetIndividualUserList(int Id)
        {
            try
            {
                return _userCreationService.GetIndividualUserList(Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }


        //Checker 


        [HttpGet]
        [Route("[action]")]
        [Route("api/UserCreation/GetIndividualCheck")]
        public UserMaker GetIndividualCheck(int Id)
        {
            try
            {
                return _userCreationService.GetIndividualCheck(Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/UserCreation/GetCheckerLists")]
        public IEnumerable<UserMaker> GetCheckerLists()
        {
            try
            {
                return _userCreationService.GetCheckerLists();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/UserCreation/Approve")]
        public ResponseStatus UserCreationApprove([FromBody] UserMaker postDta)
        {
            var responsestatus = new ResponseStatus();
            var errorDetails = new List<ErrorDetail>();
            var errorDetail = new ErrorDetail();
            try
            {

                try
                {
                    var responseVal = _userCreationService.Approve(postDta);
                    if (responseVal.ToUpper() == "SUCCESS")
                    {
                        responsestatus.status = responseVal.ToUpper();
                        responsestatus.statusMessage = responseVal.ToUpper();
                        errorDetail.ErrorCode = "000";
                        errorDetail.ErrorDesc = "";
                        errorDetails.Add(errorDetail);
                    }
                    else
                    {
                        errorDetail.ErrorCode = "401";
                        errorDetail.ErrorDesc = responseVal;
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
        [Route("api/UserCreation/SearchCheckUserLists")]
        public IEnumerable<UserMaker> SearchCheckUserLists(string UserName)
        {
            try
            {
                return _userCreationService.SearchCheckUserLists(UserName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
    }
}
