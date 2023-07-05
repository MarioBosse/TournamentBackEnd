using System.Collections.Generic;
using System.Data.Entity.Core;
using webapi.Context;
using webapi.Models.Database.Tournaments;
using webapi.Models.Database.Users;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Users;

namespace webapi.DbLink
{
    public class Address
    {
        private UserRoleContext _roleContext { get; set; }
        private IConfiguration _configuration { get; set; }
        #region Constructeur
        public Address(UserRoleContext context, IConfiguration configuration)
        {
            _roleContext = context;
            _configuration = configuration;
        }
        #endregion
        #region Address
        public GetAll? GetAll(TokenCheck tokenCheck)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new GetAll() { Validation = token });

            if (_roleContext == null || _roleContext.Users == null) return null;
            var r = new GetAll()
            {
                Users = BuildBase(_roleContext.Users.Where(e => e.IdUser > 0).ToList()),
                Validation = token
            };
            return r;
        }
        private List<UserRead> BuildBase(List<User> users)
        {
            List<UserRead> bases = new List<UserRead>();
            foreach (User user in users)
            {
                bases.Add(new UserRead()
                {
                    IdUser = user.IdUser,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Gender = user.Gender,
                    Birthdate = user.Birthdate,
                    ProfilePhoto = user.ProfilePhoto,
                    IsActivated = user.IsActivated,
                    IdAddress = user.IdAddress,
                    userAddress = BuildAddress(user.IdAddress)
                });
            }
            return bases;
        }
        private UserAddress BuildAddress(Int64? idAddress)
        {
            if (_roleContext == null || _roleContext.Addresses == null) return new UserAddress();

            var address = _roleContext.Addresses.Where(e => e.IdAddress == idAddress).FirstOrDefault();
            UserAddress userAddress = new UserAddress()
            {
                DoorNumber = address.DoorNumber,
                StreetName = address.StreetName,
                StreetName2 = address.StreetName2,
                AppNumber = address.AppNumber,
                Zipcode = address.Zipcode,
                City = GetCity(address.IdCity),
                Province = GetProvince(address.IdCity),
                Pays = GetPays(address.IdCity)
            };
            return userAddress;
        }
        private UserCity GetCity(Int64 idCity)
        {
            if (_roleContext == null || _roleContext.Cities == null) return new UserCity() { IdCity = idCity };

            var city = _roleContext.Cities.Where(e => e.IdCity == idCity).FirstOrDefault();
            if (city == null) return new UserCity() { IdCity = idCity };

            return new UserCity() { IdCity = idCity, Name = city.Name };
        }
        private UserProvince GetProvince(Int64 idCity)
        {
            if (_roleContext == null || _roleContext.Cities == null || _roleContext.Provinces == null) return new UserProvince();

            var city = _roleContext.Cities.Where(e => e.IdCity == idCity).FirstOrDefault();
            var province = _roleContext.Provinces.Where(e => e.IdProvince == city.IdProvince).FirstOrDefault();
            if (city == null || province == null) return new UserProvince();

            return new UserProvince() { IdProvince = province.IdProvince, Name = province.Name };
        }
        private UserPays GetPays(Int64 idCity)
        {
            if (_roleContext == null ||
                _roleContext.Cities == null ||
                _roleContext.Provinces == null ||
                _roleContext.Countries == null)
                return new UserPays();

            var city = _roleContext.Cities.Where(e => e.IdCity == idCity).FirstOrDefault();
            if(city == null) return new UserPays();

            var province = _roleContext.Provinces.Where(e => e.IdProvince == city.IdProvince).FirstOrDefault();
            if (province == null) return new UserPays();

            var pays = _roleContext.Countries.Where(e => e.IdCountry == province.IdCountry).FirstOrDefault();
            if (city == null || province == null || pays == null) return new UserPays();

            return new UserPays() { IdPays = pays.IdCountry, Name = pays.Name };
        }
        public Delete? TournamentTypeDelete(UserDelete delete)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(deleteType.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(deleteType.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Delete() { Validation = token });

            if (_roleContext == null || _roleContext.Users == null) return null;
            User? user = new User();
            if (delete.User.Name.Length > 1)
                user = _roleContext.TournamentTypes.Where(t => t.Name == delete.User.Name).FirstOrDefault();
            else if (delete.User.Id > 0)
                user = _roleContext.TournamentTypes.Where(e => e.IdTournamentType == delete.User.IdTournamentType).FirstOrDefault();
            if (user == null) return new Delete() { Validation = token, Deleted = false };

            var result = _roleContext.Users.Remove(tourType);
            Delete? delete = new Delete() { Validation = token, Deleted = true };
            return delete;
        }
        public Add? TournamentTypeAdd(UserAddRead ajoutUser)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(ajoutClient.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(ajoutClient.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Add() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            _roleContext.TournamentTypes.Add(new TournamentType() { Name = ajoutUser.Description });
            _roleContext.SaveChanges();

            Add? add = GetTypeInfo(ajoutUser.Description);
            if (add == null) { return null; }

            add.Validation = token;
            return add;
        }
        public Add? TournamentTypeModify(UserModify data)
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
            if (a == null || a.Picture == null) return null;

            Add add = new Add()
            {
                Validation = token,
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
                    Validation = token
                };
                return nouv;
            }
            return null;
        }
        #region Private
        private List<ReadTournament>? GetInfo(List<Models.Database.Tournaments.Tournament> tournaments)
        {
            if (tournaments == null) return null;
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
