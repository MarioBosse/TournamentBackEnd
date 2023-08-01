//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Tournaments
// Description : Classe qui régis les informations pour effectuer la création de la
//               table 'trn_Tournaments' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_Tournaments")]
    public class Tournament
    {
        public long IdTournament { get; set; }
        public long IdTournamentType { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
