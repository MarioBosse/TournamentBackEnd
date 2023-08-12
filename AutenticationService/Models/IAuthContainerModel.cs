//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : AuthenticationService.Managers
// Description : Cette espace effectue la gestion des informations requises pour
//               créer le jeton de sécurité.
//
//----------------------------------------------------------------------------------
using System.Security.Claims;

namespace AuthenticationService.Models
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition d'Interface
    // Nom : IAuthContainerModel
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public interface IAuthContainerModel
    {
        #region Members
        // Clé de sécurité pour le client demandé
        string SecretKey { get; set; }
        // Algorithme de sécurité utilisé pour l'encriptage
        string SecurityAlgorithm { get; set; }
        // Durée de vie du jeton demandé
        int ExpireMinutes { get; set; }

        // Liste des valeurs identifiant l'utilisateur et utilisé pour l'enregistrement
        // de la clé
        Claim[] Claims { get; set; }
        #endregion
    }
}
