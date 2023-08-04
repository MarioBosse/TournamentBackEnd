//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Users   
// Description : Classe qui régis les information pour créer la table 'usr_token'
//               dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Users
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Token
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("usr_token")]
    public class Token
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string SecurityToken { get; set; } = string.Empty;
    }
}
