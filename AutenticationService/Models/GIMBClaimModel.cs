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
namespace AutenticationService.Models
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de classe
    // Nom : GIMBClaimModel
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class GIMBClaimModel
    {
        // Nom du Claims a créer
        public string Name { get; set; } = String.Empty;
        // Valeur a enregistrer
        public string Value { get; set; } = String.Empty;
    }
}
