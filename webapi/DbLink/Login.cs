using AuthenticationService.Managers;
using AuthenticationService.Models;
using AuthenticationService.Token;
using System.Security.Claims;
using webapi.Context;
using webapi.Models.CRUD.Token;
using webapi.Models.Repository;
using webapi.Models.Repository.Login;

namespace webapi.DbLink
{
    public class Login
    {
        private readonly UserRoleContext _roleContext;
        private readonly IConfiguration _configuration;
        public Login(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }

        public List<AllUsers> GetAlls()
        {
            if (_roleContext == null || _roleContext.Users == null || _roleContext.Addresses == null) return new List<AllUsers>();
            var alls = _roleContext.Users.Where(e => e.IdUser > 0).ToList();

            List<AllUsers> allUsers = new List<AllUsers>();
            foreach(var user in alls)
            {
                var ad = _roleContext.Addresses.Where(e => e.IdAddress == user.IdAddress).FirstOrDefault();
                if (ad == null) continue;

                allUsers.Add(new AllUsers() { FirstName = user.FirstName,
                                              LastName = user.LastName,
                                              Email = user.Email,
                                              Gender = user.Gender,
                                              Birthdate = user.Birthdate,
                                              IsActivated = user.IsActivated,
                                              ProfilePhoto = user.ProfilePhoto,
                                              Address = new DataObjectTransfert().GetAddress(ad, _roleContext)
                });
            }
            return allUsers;
        }
        public VraiFaux EmailExisting(String email)
        {
            var VF = new VraiFaux();
            if (_roleContext == null || _roleContext.Users == null) { VF.Value = false; return VF; }

            VF.Value = _roleContext.Users.Where(e => e.Email == email).Any();
            return VF;
        }

        public TokenRead? GetConnection(LoginSend loginSend)
        {
            if (_roleContext == null || _roleContext.Users == null) return null;

            TokenRead TR = new TokenRead();
            TR.Email = loginSend.Email;

            var val = _roleContext.Users.Where(e => e.Email == loginSend.Email && e.Password == loginSend.Password).FirstOrDefault();
            if (val == null) return null;

            var secTok = _roleContext.Tokens.Where(e => e.IdUser == val.IdUser).FirstOrDefault();

            // Création d'un Jeton de sécurité. Il sera utilisé pour générer les jetons utilisé par l'utilisateur.
            // Chaque utilisateur possède un jeton de sécurité qui lui est propre.
            if (secTok == null)
            {
                secTok = new()
                {
                    IdUser = val.IdUser,
                    SecurityToken = new GenToken(_configuration, "").BuildSecretKey()
                };
                _roleContext.Tokens.Add(secTok);
                _roleContext.SaveChanges();
            }
            List <Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, val.Email, ""));
            claims.Add(new Claim("Token", secTok.SecurityToken, "" ));
            var i = claims.AsEnumerable<System.Security.Claims.Claim>();
            var token = new JWTService(secTok.SecurityToken).GenerateToken(new JWTContainerModel()
            {
                SecretKey = secTok.SecurityToken,
                Claims = GetClaims(claims).ToArray<Claim>()
            });
            TR.Token = token;
            return TR;
        }

        private IEnumerable<Claim> GetClaims(List<Claim> claims)
        {
            return claims.AsEnumerable();
        }
        public TokenRead? IsConnexionValid(TokenRead tokenRead)
        {
            GenToken tok = new GenToken(_configuration, tokenRead.Token);
            var ret = tok.IsValidToken(tokenRead.Token);
            return null;
        }
    }
}
