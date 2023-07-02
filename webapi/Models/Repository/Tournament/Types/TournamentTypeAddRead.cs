using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament.Types
{
    public class TournamentTypeAddRead
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public String Description { get; set; } = String.Empty;
    }

    public class TournamentTypeDelete
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public TournamentType tournamentType { get; set; } = new TournamentType();
    }
}
