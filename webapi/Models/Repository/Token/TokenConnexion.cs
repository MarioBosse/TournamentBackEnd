//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Token
// Description : Classe qui régis les valeurs de retour pour le status de connexion
//               entre l'application et les services de gestion du projet avec la
//               base de données.
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
    // Nom : TokenConnexion
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class TokenConnexion
    {
        public bool IsConnected { get; set; }
        public Int16 ConnexionCode { get; set; }
        public String Message { get; set; } = String.Empty;
    }
}
