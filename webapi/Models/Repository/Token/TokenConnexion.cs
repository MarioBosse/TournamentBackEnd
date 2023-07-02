namespace webapi.Models.Repository.Token
{
    public class TokenConnexion
    {
        public bool IsConnected { get; set; }
        public Int16 ConnexionCode { get; set; }
        public String Message { get; set; } = String.Empty;
    }
}
