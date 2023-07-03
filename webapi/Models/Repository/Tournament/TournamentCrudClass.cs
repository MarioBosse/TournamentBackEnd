using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament
{
    public class Add
    {
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
        public Int64 idTournament { get; set; }
        public Int64 idTournamentType { get; set; }
        public String Name { get; set; }
        public Byte[] Picture { get; set; }
    }
    public class Delete
    {
        public bool Deleted { get; set; } = false;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
    public class GetAll
    {
        public List<ReadTournament> Tournaments { get; set; } = new ReadTournament();
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
}
