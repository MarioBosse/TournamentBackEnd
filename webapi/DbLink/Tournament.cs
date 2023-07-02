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
        public Delete? TournamentTypeDelete(TournamentTypeDelete deleteType)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(deleteType.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(deleteType.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Delete() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            TournamentType? tourType = new TournamentType();
            if (deleteType.tournamentType.Name.Length > 1)
                tourType = _roleContext.TournamentTypes.Where(t => t.Name == deleteType.tournamentType.Name).FirstOrDefault();
            else if (deleteType.tournamentType.IdTournamentType > 0)
                tourType = _roleContext.TournamentTypes.Where(e => e.IdTournamentType == deleteType.tournamentType.IdTournamentType).FirstOrDefault();
            if(tourType == null) return new Delete() { Validation = token, DeleteDone = false };

            var result = _roleContext.TournamentTypes.Remove(tourType);
            Delete? delete = new Delete() { Validation = token, DeleteDone = true };
            return delete;
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
        public Add? TournamentTypeModify(TournamentTypeModify data)
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
