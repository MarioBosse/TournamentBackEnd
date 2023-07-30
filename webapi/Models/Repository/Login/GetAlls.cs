using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Login
{
    public class GetAlls
    {
        public TokenConnexion TokenConnexion { get; set; } = new TokenConnexion();
        public List<AllUsers> AllUsers { get; set; } = new List<AllUsers>();
    }
}
