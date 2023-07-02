using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament.Types
{
    public class GetAlls
    {
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
        public TournamentType[] TournamentTypes { get; set; }
    }
}
