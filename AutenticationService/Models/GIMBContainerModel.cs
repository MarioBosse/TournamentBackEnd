//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : AuthenticationService.Models
// Description : Cette espace définie les structures de données à utiliser pour le
//               service d'autentification..
//
//----------------------------------------------------------------------------------
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AuthenticationService.Models
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de classe
    // Nom : GIMBContainerModel
    // Héritage : IAuthContainerModel
    //
    //----------------------------------------------------------------------------------
    public class GIMBContainerModel : IAuthContainerModel
    {
        #region Public Methods
        // Définition des valeurs par défaut du model a utilisé pour la craétion du
        // jeton de connexion.
        public int ExpireMinutes { get; set; } = 10080; // 7 jours.
        // Cette clé ne devrait pas être utilisée pour un utilsateur. Une nouvelle clé
        // sera créé pour la remplacer.
        public string SecretKey { get; set; } = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;

        public Claim[]? Claims { get; set; } = null;
        #endregion
    }
}
