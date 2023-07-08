namespace webapi.Models.Repository.Token
{
    public class TokenCheck
    {
        public String Email { get; set; } = String.Empty;
        public String Token { get; set; } = String.Empty;
    }

    public class LoginUser
    {
        public TokenCheck tokenChek { get; set; } = new TokenCheck();
        public Byte[]? photoProfile { get; set; } = null;
        public String Firstname { get; set; } = String.Empty;
        public String Lastname { get; set; } = String.Empty;
    }
}
