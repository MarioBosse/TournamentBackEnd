namespace webapi.Models.Repository.Token
{
    public class TokenValidation
    {
        public bool IsValid { get; set; }
        public TokenConnexion TokenConnexion { get; set; } = new TokenConnexion();
    }
}
