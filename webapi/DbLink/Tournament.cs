using webapi.Context;
using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Tournament.TypesRetour;
using webapi.Models.Repository.Tournament.Types;
using webapi.Models.Repository.Token;

namespace webapi.DbLink
{
    public class Tournament
    {
        private UserRoleContext _roleContext { get; set; }
        private IConfiguration _configuration { get; set; }

        public Tournament(UserRoleContext context, IConfiguration configuration)
        {
            _roleContext = context;
            _configuration = configuration;
        }

        public GetAlls? GetAllTypes(TokenCheck tokenCheck)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new GetAlls() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var r = new GetAlls()
            {
                TournamentTypes = _roleContext.TournamentTypes.Where(e => e.IdTournamentType > 0).ToArray(),
                Validation = token
            };
            return r;
        }

        public Add? TournamentTypeAdd(TournamentTypeAddRead ajoutType)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(ajoutType.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(ajoutType.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Add() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            _roleContext.TournamentTypes.Add(new TournamentType() { Name = ajoutType.Description });
            _roleContext.SaveChanges();

            Add? add = GetTypeInfo(ajoutType.Description);
            if (add == null) { return null; }

            add.Validation = token;
            return add;
        }
        public Add? TournamenetTypeModify(TournamentTypeModify data)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(data.TokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(data.TokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Add() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var rec = _roleContext.TournamentTypes.Where(e => e.Name == data.Origin).FirstOrDefault();
            if (rec != null)
            {
                rec.Name = data.Destination;
                _roleContext.TournamentTypes.Update(rec);
                _roleContext.SaveChanges();

                Add nouv = new Add() { Id = rec.IdTournamentType, Name = data.Destination, Validation = token };
                return nouv;
            }
            return null;
        }
        #region Private
        private Add? GetTypeInfo(String type)
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var rec = _roleContext.TournamentTypes.Where(e => e.Name == type).FirstOrDefault();

            if (rec == null) return null;
            Add nouv = new Add()
            {
                Name = type,
                Id = rec.IdTournamentType
            };
            return nouv;
        }
        #endregion
    }
}
