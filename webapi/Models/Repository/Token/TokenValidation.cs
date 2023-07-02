namespace webapi.Models.Repository.Token
{
    public class TokenValidation
    {
        public bool IsValid { get; set; }
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
}
