using webapi.Models.Repository.Token;

namespace webapi.Messages
{
    public class ApiResponse
    {
        public TokenConnexion MessageConnexion(bool isConnected, Int16 code, String message)
        {
            return new TokenConnexion { IsConnected = isConnected,
                                        ConnexionCode = code,
                                        Message = message };
        }
    }
}
