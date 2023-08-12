//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Token
// Description : Classe qui régis les valeurs requise pour effectuer une connexion
//               avec les services responsable de la seine gestion des information
//               contenues dans la base de données.
//
//----------------------------------------------------------------------------------
namespace webapi.Models.Repository.Token
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : CheckConnexion
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class CheckConnexion
    {
        public String Email { get; set; } = String.Empty;
        public String Token { get; set; } = String.Empty;
    }
}
