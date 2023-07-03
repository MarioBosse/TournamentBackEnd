using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament.TypesRetour
{
    public class AddType
    {
        public Int64 Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }

    public class DeleteType
    {
        public bool DeleteDone { get; set; } = false;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
}
