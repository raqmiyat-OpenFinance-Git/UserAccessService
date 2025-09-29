namespace Raqmiyat.Entities.Login
{
    public class User
    {
        public int USERATTRIBS_USERID { get; set; }
        public string USERATTRIBS_NAME { get; set; }
        public int USERATTRIBS_USERBRANCH { get; set; }
        public int USERATTRIBS_USERCOMPANY { get; set; }
        public string USERATTRIBS_FULLNAME { get; set; }
        public string USERATTRIBS_SHORTNAME { get; set; }
        public string? USERATTRIBS_SHORTNAME_LANG1 { get; set; }
        public string? USERATTRIBS_SHORTNAME_LANG2 { get; set; }
        public int USERATTRIBS_MENU_TYPE { get; set; }
        public string USERATTRIBS_USER_GROUP { get; set; }
        public string? USERATTRIBS_PASSWORD { get; set; }
        public string? USERATTRIBS_NEWPASSWORD { get; set; }
        public string? USERATTRIBS_DESCRIPTION { get; set; }
        public bool USERATTRIBS_USERSTATUS { get; set; }
        public string USERATTRIBS_EMAILID { get; set; }
        public byte[]? USERATTRIBS_DETAILS { get; set; }
        public string USERATTRIBS_RITS_ID { get; set; }
        public string USERATTRIBS_GEID { get; set; }
        public bool USERATTRIBS_IsDelete { get; set; }
        public string? SearchTerm { get; set; }
        public string? ActionType { get; set; }
        public string? Status { get; set; }

    }
    
}
