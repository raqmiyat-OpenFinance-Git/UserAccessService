
using System;

namespace Raqmiyat.Entities.Login
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Status { get; set; }
        public string ErrorMsg { get; set; }
    }

    public class NewUserLogin
    {
        public string UserID { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string PassOption { get; set; }
    }
  
    
    
}
