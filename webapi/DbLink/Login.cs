using AuthenticationService.Managers;
using AuthenticationService.Models;
using AuthenticationService.Token;
using System.Security.Claims;
using webapi.Context;
using webapi.Models.Repository;
using webapi.Models.Repository.Login;
using webapi.Models.Repository.Token;

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
        public GetAlls? GetAlls(TokenCheck token)
        {
            TokenConnexion tokenC = new ConnexionState(_roleContext, _configuration).GetConnexionState(token);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(token);
            if (isValide == null || !isValide.IsValid) return (new GetAlls() {  Validation = tokenC });

            if (token == null || _roleContext == null || _roleContext.Users == null || _roleContext.Addresses == null) return new GetAlls() { Validation = tokenC };
            if(isValide != null && isValide.IsValid)
            {
                var alls = _roleContext.Users.Where(e => e.IdUser > 0).ToList();

                List<AllUsers> allUsers = new List<AllUsers>();
                foreach (var user in alls)
                {
                    var ad = _roleContext.Addresses.Where(e => e.IdAddress == user.IdAddress).FirstOrDefault();
                    if (ad == null) continue;

                    allUsers.Add(new AllUsers()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Gender = user.Gender,
                        Birthdate = user.Birthdate,
                        IsActivated = user.IsActivated,
                        ProfilePhoto = user.ProfilePhoto,
                        Address = new DataObjectTransfert().GetAddress(ad, _roleContext)
                    });
                }
                return new GetAlls() { Validation = tokenC, AllUsers = allUsers };
            }
            return null;
        }
        public VraiFaux EmailExisting(String email)
        {
            var VF = new VraiFaux();
            if (_roleContext == null || _roleContext.Users == null) { VF.Value = false; return VF; }

            VF.Value = _roleContext.Users.Where(e => e.Email == email).Any();
            return VF;
        }

        public TokenCheck? GetConnection(LoginSend loginSend)
        {
            if (_roleContext == null || _roleContext.Users == null) return null;

            TokenCheck TR = new TokenCheck();
            TR.Email = loginSend.Email;

            var val = _roleContext.Users.Where(e => e.Email == loginSend.Email && e.Password == loginSend.Password).FirstOrDefault();
            if (val == null) return null;

            var secTok = _roleContext.Tokens.Where(e => e.IdUser == val.IdUser).FirstOrDefault();

            // Cr�ation d'un Jeton de s�curit�. Il sera utilis� pour g�n�rer les jetons utilis� par l'utilisateur.
            // Chaque utilisateur poss�de un jeton de s�curit� qui lui est propre.
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
        public TokenValidation? IsConnexionValid(TokenCheck tokenRead)
        {
            bool GotEmail = false;
            bool validEmail = false;

            bool GotKey = false;
            bool validKey = false;

            if (_roleContext == null || _roleContext.Users == null || tokenRead == null || tokenRead.Email == null) return null;

            Models.Database.Users.User? id = _roleContext.Users.Where(e => e.Email == tokenRead.Email).FirstOrDefault();
            if (id == null) return null;

            Models.Database.Users.Token? secretKey = _roleContext.Tokens.Where(t => t.IdUser == id.IdUser).FirstOrDefault();
            if (secretKey == null) return null;

            if(new JWTService(secretKey.SecurityToken).IsTokenValid(tokenRead.Token))
            {
                IEnumerable<Claim> cls = new JWTService(secretKey.SecurityToken).GetTokenClaims(tokenRead.Token);
                List<Claim> lCls = cls.ToList();
                foreach (Claim c in lCls)
                {
                    if (GotEmail == false && IsEmailValid(c, tokenRead.Email))
                    {
                        GotEmail = true;
                        if(c.Value == tokenRead.Email)
                            validEmail = true;
                        continue;
                    }
                    if(GotKey == false && IsTokenValid(c, tokenRead.Token))
                    {
                        GotKey = true;
                        if(c.Value == secretKey.SecurityToken)
                            validKey = true;
                        continue;
                    }
                    if(validEmail && validKey)
                    {
                        if(IsTimeValid(c))
                            return (new TokenValidation() { IsValid = true });
                    }
                }
            }
            return null;
        }

        private bool IsTokenValid(Claim c, string token)
        {
            return (c.Type == "Token" ? true : false);
        }
        private bool IsEmailValid(Claim c, string email)
        {
            return c.Type.Contains("email");
        }

        private bool IsTimeValid(Claim c)
        {
            if (c.Type == "exp")
            {
                var exp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(c.Value));
                if (exp.DateTime > DateTime.Now)
                    return true;
            }
            return false;
        }
    }
}
