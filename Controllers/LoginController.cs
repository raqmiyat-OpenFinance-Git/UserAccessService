using Microsoft.AspNetCore.Mvc;
using Raqmiyat.Entities.Login;
using System;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.NLogService;
using NLog;

namespace OpenFinanceWebApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        private readonly NLogWebApiService _logger;
        private readonly string logger;
       
        public LoginController(ILoginService loginSer, NLogWebApiService logger)
        {
            _logger = logger;
            loginService = loginSer;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Login/GetLogin")]
        public Login GetLogin(string userCode)
        {
            try
            {
                return loginService.GetLogin(userCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Login/SaveSession")]
        public bool SaveSession([FromBody] UserSession userSession)
        {
            bool returnValue = false;
            try
            {
                if (userSession != null)
                {
                    int count = loginService.SaveSession(userSession);
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
        [Route("[action]")]
        [Route("api/Login/DeleteSession")]
        public bool DeleteSession([FromBody] UserSession userSession)
        {
            bool returnValue = false;
            try
            {
                if (userSession != null)
                {
                    int count = loginService.DeleteSession(userSession);
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

        [HttpGet]
        [Route("[action]")]
        [Route("api/Login/GetSession")]
        public int GetSession(string sessionID, string sessionUserID)
        {
            try
            {
                var userSession = new UserSession
                {
                    SessionID = sessionID,
                    SessionUserID = sessionUserID
                };

                int returnValue = loginService.GetSession(userSession);
                return returnValue;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return 0;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Login/GetInitialPwd")]
        public LoginValidation GetInitialPwd(string userCode)
        {
            LoginValidation loginValidation = new LoginValidation();
            try
            {
                return loginService.GetInitialPwd(userCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }




        [HttpPost]
        [Route("[action]")]
        [Route("api/Login/InactivateUser")]
        public ActionResult<LoginValidation> InactivateUser([FromBody] Login login)
        {
            try
            {
                LoginValidation loginValidation = new LoginValidation();
                loginValidation.UserCode = login.UserCode;
                if (!string.IsNullOrEmpty(login.UserCode))
                {
                    loginValidation.UserMsg = loginService.InactivateUser(login.UserCode);
                }
                return loginValidation;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Login/ResetPasswordCount")]
        public bool ResetPasswordCount([FromBody] Login login)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(login.UserCode))
                {
                    int count = loginService.ResetPasswordCount(login.UserCode);
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
        [Route("[action]")]
        [Route("api/Login/UpdatePasswordFailedCount")]
        public ActionResult<LoginValidation> UpdatePasswordFailedCount([FromBody] Login login)
        {
            LoginValidation loginValidation = new LoginValidation();
            try
            {
                loginValidation.UserCode = login.UserCode;
                if (!string.IsNullOrEmpty(login.UserCode))
                {
                    loginValidation.UserMsg = loginService.UpdatePasswordFailedCount(login.UserCode);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return loginValidation;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/LastLogin/lastlogontime")]
        public IEnumerable<Logontime> lastlogontime(string userCode)
        {
            try
            {
                return loginService.lastlogontime(userCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Login/GetUserSession")]
        public int GetUserSession(string sessionID, string sessionUserID)
        {
            try
            {
                return loginService.GetUserSession(sessionID, sessionUserID);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Login/GetUserStatus")]
        public int GetUserStatus(string UserName)
        {
            try
            {
                return loginService.GetUserStatus(UserName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Login/GetSourceVersion")]
        public string GetSourceVersion()
        {
            try
            {
                return loginService.GetSourceVersion();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return loginService.GetSourceVersion();
        }
    }
}
