using webapi.Context;
using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Tournament.TypesRetour;
using webapi.Models.Repository.Tournament.Types;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Tournament;

namespace webapi.DbLink
{
    public class Tournament
    {
        private UserRoleContext _roleContext { get; set; }
        private IConfiguration _configuration { get; set; }
        #region Constructeur
        public Tournament(UserRoleContext context, IConfiguration configuration)
        {
            _roleContext = context;
            _configuration = configuration;
        }
        #endregion
        #region TournamentType
        public GetAllType? GetAllTypes(TokenCheck tokenCheck)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new GetAllType() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var r = new GetAllType()
            {
                TournamentTypes = _roleContext.TournamentTypes.Where(e => e.IdTournamentType > 0).ToArray(),
                Validation = token
            };
            return r;
        }
        public DeleteType? TournamentTypeDelete(TournamentTypeDelete deleteType)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(deleteType.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(deleteType.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new DeleteType() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            TournamentType? tourType = new TournamentType();
            if (deleteType.tournamentType.Name.Length > 1)
                tourType = _roleContext.TournamentTypes.Where(t => t.Name == deleteType.tournamentType.Name).FirstOrDefault();
            else if (deleteType.tournamentType.IdTournamentType > 0)
                tourType = _roleContext.TournamentTypes.Where(e => e.IdTournamentType == deleteType.tournamentType.IdTournamentType).FirstOrDefault();
            if(tourType == null) return new DeleteType() { Validation = token, DeleteDone = false };

            var result = _roleContext.TournamentTypes.Remove(tourType);
            DeleteType? delete = new DeleteType() { Validation = token, DeleteDone = true };
            return delete;
        }
        public AddType? TournamentTypeAdd(TournamentTypeAddRead ajoutType)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(ajoutType.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(ajoutType.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new AddType() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            _roleContext.TournamentTypes.Add(new TournamentType() { Name = ajoutType.Description });
            _roleContext.SaveChanges();

            AddType? add = GetTypeInfo(ajoutType.Description);
            if (add == null) { return null; }

            add.Validation = token;
            return add;
        }
        public AddType? TournamentTypeModify(TournamentTypeModify data)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(data.TokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(data.TokenCheck);
            if (isValide == null || !isValide.IsValid) return (new AddType() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var rec = _roleContext.TournamentTypes.Where(e => e.Name == data.Origin).FirstOrDefault();
            if (rec != null)
            {
                rec.Name = data.Destination;
                _roleContext.TournamentTypes.Update(rec);
                _roleContext.SaveChanges();

                AddType nouv = new AddType() { Id = rec.IdTournamentType, Name = data.Destination, Validation = token };
                return nouv;
            }
            return null;
        }
        #region Private
        private AddType? GetTypeInfo(String type)
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var rec = _roleContext.TournamentTypes.Where(e => e.Name == type).FirstOrDefault();

            if (rec == null) return null;
            AddType nouv = new AddType()
            {
                Name = type,
                Id = rec.IdTournamentType
            };
            return nouv;
        }
        #endregion
        #endregion
        #region Tournament
        public GetAll? GetAll(TokenCheck tokenCheck)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new GetAll() { Validation = token });

            if (_roleContext == null || _roleContext.Tournaments == null) return null;

            List<Models.Database.Tournaments.Tournament> test = _roleContext.Tournaments.Where(e => e.IdTournament > 0).ToList();
            var allT = _roleContext.Tournaments.Where(e => e.IdTournament > 0).ToList();
            if (allT == null) return null;

            var r = new GetAll()
            {
                Tournaments = GetInfo(allT),
                Validation = token
            };
            return r;
        }
        public Delete? TournamentDelete(TournamentDelete deleteType)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(deleteType.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(deleteType.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Delete() { Validation = token });

            if (_roleContext == null || _roleContext.Tournaments == null) return null;
            Models.Database.Tournaments.Tournament? tourType = new Models.Database.Tournaments.Tournament();
            if (deleteType.tournament.Name.Length > 1)
                tourType = _roleContext.Tournaments.Where(t => t.Name == deleteType.tournament.Name).FirstOrDefault();
            else if (deleteType.tournament.IdTournament > 0)
                tourType = _roleContext.Tournaments.Where(e => e.IdTournament == deleteType.tournament.IdTournament).FirstOrDefault();
            if (tourType == null) return new Delete() { Validation = token, Deleted = false };

            var result = _roleContext.Tournaments.Remove(tourType);
            Delete? delete = new Delete() { Validation = token, Deleted = true };
            return delete;
        }
        public Add? TournamentAdd(Definition Tournament)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(Tournament.Validation);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(Tournament.Validation);
            if (isValide == null || !isValide.IsValid) return (new Add() { Validation = token });

            if (_roleContext == null || _roleContext.Tournaments == null) return null;
            _roleContext.Tournaments.Add(new Models.Database.Tournaments.Tournament()
            {
                IdTournamentType = Tournament.Tournament.IdTournament,
                Name = Tournament.Tournament.Name,
                Picture = Tournament.Tournament.Picture
            });
            _roleContext.SaveChanges();

            Models.Database.Tournaments.Tournament? a = _roleContext.Tournaments.Where(e => e.Name == Tournament.Tournament.Name).FirstOrDefault();
            if(a == null || a.Picture == null) return null;

            Add add = new Add()
            {
                Validation = token,
                idTournament = a.IdTournament,
                idTournamentType = a.IdTournamentType,
                Picture = a.Picture,
                Name = a.Name
            };
            return add;
        }
        public Add? TournamentModify(TournamentModify data)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(data.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(data.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Add() { Validation = token });

            if (_roleContext == null || _roleContext.Tournaments == null) return null;
            var rec = _roleContext.Tournaments.Where(e => e.Name == data.Origin.Name).FirstOrDefault();
            if (rec == null || rec.Picture == null) return null;

            if (rec != null)
            {
                rec.Name = data.NewName;
                _roleContext.Tournaments.Update(rec);
                _roleContext.SaveChanges();

                Add nouv = new Add()
                {
                    idTournament = rec.IdTournament,
                    idTournamentType = rec.IdTournamentType,
                    Name = data.NewName,
                    Picture = rec.Picture,
                    Validation = token
                };
                return nouv;
            }
            return null;
        }
        #region Private
        private List<ReadTournament>? GetInfo(List<Models.Database.Tournaments.Tournament> tournaments)
        {
            if(tournaments == null) return null;
            if (_roleContext == null || _roleContext.TournamentTypes == null || _roleContext.Tournaments == null) return null;

            List<ReadTournament> infos = new List<ReadTournament>();
            foreach (var tournament in tournaments)
            {
                Models.Database.Tournaments.Tournament? rec = _roleContext.Tournaments.Where(e => e.IdTournament == tournament.IdTournament).FirstOrDefault();

                var tType = _roleContext.TournamentTypes.Where(e => e.IdTournamentType == tournament.IdTournament).FirstOrDefault();
                if (rec == null || tType == null) return null;

                ReadTournament nouv = new ReadTournament()
                {
                    IdTournament = tournament.IdTournament,
                    Name = tournament.Name,
                    tournamentType = tType,
                    Picture = tournament.Picture,
                    TournamentType = tType.Name
                };
                infos.Add(nouv);
            }
            return infos;
        }
        #endregion
        #endregion
    }
}
