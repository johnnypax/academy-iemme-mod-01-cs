namespace API_lez07_JWT.Models
{
    public class UserLogin
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }           //Popolato dal DB
    }
}
