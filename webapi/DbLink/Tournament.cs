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
        private long type;

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
            var r = new GetAll()
            {
                Tournaments = GetInfo(_roleContext.Tournaments.Where(e => e.IdTournament > 0).ToList()),
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
        public Add? TournamentAdd(ReadTournament Tournament)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(addTournament.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(addTournament.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Add() { Validation = token });

            if (_roleContext == null || _roleContext.Tournaments == null) return null;
            _roleContext.Tournaments.Add(new Models.Database.Tournaments.Tournament()
            {
                IdTournamentType = addTournament.tournament.IdTournament,
                Name = addTournament.tournament.Name,
                Picture = addTournament.tournament.Picture
            });
            _roleContext.SaveChanges();

            Models.Database.Tournaments.Tournament? a = _roleContext.Tournaments.Where(e => e.Name == addTournament.Name).FirstOrDefault();
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
            var rec = _roleContext.Tournaments.Where(e => e.Name == data.Origin).FirstOrDefault();
            if (rec != null)
            {
                rec.Name = data.Destination;
                _roleContext.Tournaments.Update(rec);
                _roleContext.SaveChanges();

                Add nouv = new Add()
                {
                    idTournament = rec.IdTournament,
                    idTournamentType = rec.IdTournamentType,
                    Name = data.Destination,
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
            if (_roleContext == null || _roleContext.Tournaments == null) return null;

            List<ReadTournament> infos = new List<ReadTournament>();
            foreach (var tournament in tournaments)
            {
                Models.Database.Tournaments.Tournament? rec = _roleContext.Tournaments.Where(e => e.IdTournament == tournament.IdTournament).FirstOrDefault();

                if (rec == null) return null;
                ReadTournament nouv = new ReadTournament()
                {
                    IdTournament = tournament.IdTournament,
                    Name = tournament.Name,
                    IdTournamentType = tournament.IdTournamentType,
                    Picture = tournament.Picture,
                    TournamentType = rec
                };
                infos.Add(nouv);
            }
            return infos;
        }
        #endregion
        #endregion
    }
}
