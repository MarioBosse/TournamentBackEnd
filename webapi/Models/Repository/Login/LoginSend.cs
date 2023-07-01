namespace webapi.Models.Repository.Login
{
    public class LoginSend
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class EmailCheck
    {
        public string Email { get; set; } = string.Empty;
    }
}
