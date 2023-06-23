using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System.Security.Cryptography;
using webapi.Context;
using webapi.Models.Users;



namespace webapi.Token
{
    public class MyToken
    {
        private String userSecretKey { get; set; } = String.Empty;
        private DateTime lapsedtime { get; set; }
        private User _user { get; set; }
        private UserRoleContext _context { get; set; }

        private String BuildSecretKey()
        {
            var sec = new DbLink.Token(_context).GetSecurityKey(_user);

            if (sec == "")
            {
                userSecretKey = Convert.ToBase64String(new HMACSHA256().Key);
                return new DbLink.Token(_context).AddSecurityKey(_user.IdUser, userSecretKey);
            }
            return sec;
        }

        private String BuildToken(User user)
        {
            _user = user;
            string token = JwtBuilder.Create()
                                        .WithAlgorithm(new HMACSHA256Algorithm())
                                        .WithSecret(userSecretKey)
                                        .AddClaim("exp", DateTimeOffset.UtcNow.AddTicks(lapsedtime.Ticks).ToUnixTimeSeconds())
                                        .AddClaim("user", _user)
                                        .Encode();
            return token;
        }

        public String GetToken(User user)
        {
            _user = user;
            userSecretKey = BuildSecretKey();
            return BuildToken(_user);
        }

        public MyToken(UserRoleContext context, IConfiguration configuration)
        {
            _context = context;
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
    }
}
