using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament
{
    public class ReadTournament
    {
        public long IdTournament { get; set; }
        public long IdTournamentType { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }

        public TournamentType TournamentType { get; set; } = new TournamentType();
    }
    public class TournamentDelete
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public ReadTournament tournament { get; set; } = new ReadTournament();
    }

    public class TournamentModify
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public ReadTournament Origin { get; set; } = new ReadTournament();
        public String NewName { get; set; } = String.Empty;
}
