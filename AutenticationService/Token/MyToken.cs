
using Microsoft.Extensions.Configuration;

namespace AuthenticationService.Token
{
    public class GenToken
    {
        public String userSecretKey { get; set; } = String.Empty;
        private DateTime lapsedtime { get; set; }

        public String BuildSecretKey()
        {
            if (userSecretKey == "")
            {
                GenTokens SecurityKey = new GenTokens();
                userSecretKey = SecurityKey.Build(userSecretKey);
            }
            return userSecretKey;
        }

        public GenToken(IConfiguration configuration, String secToken = "")
        {
            userSecretKey = secToken;
            //lapsedtime = SetLifetime(Convert.ToDateTime(configuration.GetValue<String>("TokenLifetime")));
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
