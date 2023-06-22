using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System.Security.Cryptography;
using webapi.Models.Users;



namespace webapi.Token
{
    public class MyToken
    {
        private String userSecretKey { get; set; } = String.Empty;
        private DateTime lapsedtime { get; set; }
        private User _user { get; set; }

        private void BuildSecretKe()
        {
            var hmac = new HMACSHA256();
            userSecretKey = Convert.ToBase64String(hmac.Key);
        }

        private void BuildToken()
        {
            string token = JwtBuilder.Create()
                                        .WithAlgorithm(new HMACSHA256Algorithm())
                                        .WithSecret(userSecretKey)
                                        .AddClaim("exp", DateTimeOffset.UtcNow.AddTicks(lapsedtime.Ticks).ToUnixTimeSeconds())
                                        .Encode();

            Console.WriteLine(token);
        }

        public String GetToken(User user)
        {
            _user = user;
            BuildSecretKe();
            BuildToken();

            return WrapPayload(user).Payload;
        }
        public MyToken(IConfiguration configuration)
        {
            lapsedtime = SetLifetime(Convert.ToDateTime(configuration.GetValue<String>("TokenLifetime")));
        }

        private DateTime SetLifetime(DateTime life)
        {
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddHours(Convert.ToDateTime(life).Hour);
            dateTime = dateTime.AddMinutes(Convert.ToDateTime(life).Minute);
            dateTime = dateTime.AddSeconds(Convert.ToDateTime(life).Second);

            return dateTime;
        }

        private PayloadStruct WrapPayload(Object obj)
        {
            PayloadStruct payload = new PayloadStruct();
            payload.Payload = JsonConvert.SerializeObject(obj);
            payload.Type = obj.GetType().Name;
            return payload;
        }
    }
}
