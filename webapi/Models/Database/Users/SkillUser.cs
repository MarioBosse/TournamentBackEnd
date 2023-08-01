//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Users
// Description : Classe qui régis les informations pour effectuer la création de la
//               table 'usr_SkillsUsers' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Users
{
    [Table("usr_SkillsUsers")]
    public class SkillUser
    {
        public long IdDiscipline { get; set; }
        public long IdUser { get; set; }
    }
}
