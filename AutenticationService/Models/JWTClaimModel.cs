using System.Security.Claims;

namespace AutenticationService.Models
{
    public class JWTClaimModel
    {
        public string Name { get; set; } = String.Empty;
        public string Value { get; set; } = String.Empty;
    }
}
