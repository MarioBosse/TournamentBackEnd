namespace webapi.Models
{
    public class LoginSend
    {
        public String Email { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
    }

    public class EmailCheck
    {
        public String Email { get; set; } = String.Empty;
    }
}
