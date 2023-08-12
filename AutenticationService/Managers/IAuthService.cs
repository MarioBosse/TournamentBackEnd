//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : AuthenticationService.Managers
// Description : Cette espace effectue la gestion des authentifications dans les
//               applications gèré par GiMB.
//
//----------------------------------------------------------------------------------
using AuthenticationService.Models;
using System.Security.Claims;

namespace AuthenticationService.Managers
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition d'Interface
    // Nom : IAuthService
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public interface IAuthService
    {
        string SecretKey { get; set; }

        bool IsTokenValid(string token);
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
