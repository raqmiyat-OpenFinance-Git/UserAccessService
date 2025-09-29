namespace Raqmiyat.Entities.Login
{
    public class Login
    {
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public string UserPassword { get; set; }
        public string UserStatus { get; set; }


    }

    public class UserSession
    {
        public string SessionID { get; set; }
        public string SessionUserID { get; set; }
        public string SessionLoginTime { get; set; }
        public string SessionWrkStnID { get; set; }
        public string SessionCommChannel { get; set; }


    }

    public class Logontime
    {
        public string? SESSIONLOGINTIME { get; set; }
        public string? INVALIDPWDATTEMPTCOUNT { get; set; }
        public string? LASTINVALIDLOGINDATE { get; set; }
        public string? USERPREVLOGGEDON { get; set; }

    }


}
