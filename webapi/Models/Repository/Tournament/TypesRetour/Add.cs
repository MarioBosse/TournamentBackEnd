using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament.TypesRetour
{
    public class Add
    {
        public Int64 Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }

    public class Delete
    {
        public bool DeleteDone { get; set; } = false;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
}
