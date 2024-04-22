namespace ASP_API_JWT_TEST.Models
{
    public class UserLoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; } = "USER";

    }
}
