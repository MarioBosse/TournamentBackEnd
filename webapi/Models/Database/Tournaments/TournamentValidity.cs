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
//               table 'trn_tournamentValidity' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_tournamentValidity")]
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : TournamentValidity
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class TournamentValidity
    {
        public Int64 IdTournamentValidity { get; set; }
        public Int64 IdTournament { get; set; }
        public DateTime InscriptionFrom { get; set; }
        public DateTime InscriptionTo { get; set; }
        public DateTime CompetitionFrom { get; set; }
        public DateTime CompetitionTo { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
