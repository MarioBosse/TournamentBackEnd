//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Login
// Description : Classe qui est utilisé pour retourner le somaire de tous les
//               utilisateurs présents dans la base de donnée. Cette même structure
//               peut aussi être utilisée pour idenfier un groupe d'utilisateur
//               dans un évenement au dans une catégorie d'évènement.
//
//----------------------------------------------------------------------------------
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Login
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : GetAlls
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class GetAlls
    {
        public TokenConnexion TokenConnexion { get; set; } = new TokenConnexion();
        public List<AllUsers> AllUsers { get; set; } = new List<AllUsers>();
    }
}
