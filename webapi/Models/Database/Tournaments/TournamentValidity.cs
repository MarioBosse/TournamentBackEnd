﻿using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_tournamentValidity")]
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
