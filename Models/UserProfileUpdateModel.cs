namespace UserAccessService.Models
{
    public class UserProfileUpdateModel
    {
        public string UserId { get; set; } = "";
        public string? FullName { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class ProfileUpdateModel
    {
        public string FullName { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
    public class User
    {
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public byte[] ProfileImage { get; set; } // Store image as byte array
    }
}
