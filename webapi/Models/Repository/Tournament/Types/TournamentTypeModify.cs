using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament.Types
{
    public class TournamentTypeModify
    {
        public String Origin { get; set; } = String.Empty;
        public String Destination { get; set; } = String.Empty;
        public TokenCheck TokenCheck { get; set; } = new TokenCheck();
    }
}
