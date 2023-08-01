//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Tournament
// Description : Classes qui régissent les besoins pour l'utilisation de la table
//               Tournament.
//
//----------------------------------------------------------------------------------
using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament
{
    public class TournamentBase
    {
        public Int64 IdTournament { get; set; }
        public String Tournament { get; set; } = String.Empty;
        public String TournamentType { get; set; } = String.Empty;
        public String Name { get; set; } = String.Empty;
        public Byte[]? Picture { get; set; }
    }
    public class Add
    {
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
        public Int64 idTournament { get; set; }
        public Int64 idTournamentType { get; set; }
        public String Name { get; set; } = String.Empty;
        public Byte[] Picture { get; set; }
    }
    public class Delete
    {
        public bool Deleted { get; set; } = false;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
    public class Definition
    {
        public ReadTournament Tournament { get; set; } = new ReadTournament();
        public TokenCheck Validation { get; set; } = new TokenCheck();
    }
    public class GetAll
    {
        public List<ReadTournament>? Tournaments { get; set; } = new List<ReadTournament>();
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
    public class TournamentDelete
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public TournamentBase tournament { get; set; } = new TournamentBase();
    }
    public class ReadTournament
    {
        public long IdTournament { get; set; }
        public String Name { get; set; } = string.Empty;
        public String TournamentType { get; set; } = String.Empty;
        public byte[]? Picture { get; set; }

        public TournamentType tournamentType { get; set; } = new TournamentType();
    }
    public class TournamentModify
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public TournamentBase Origin { get; set; } = new TournamentBase();
        public String NewName { get; set; } = String.Empty;
    }
}
