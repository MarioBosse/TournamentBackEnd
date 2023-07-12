using Microsoft.EntityFrameworkCore;
using GiDlls;

using webapi.Definitions;
using webapi.Models.Database.Address;
using webapi.Models.Database.Building;
using webapi.Models.Database.Camping;
using webapi.Models.Database.Roles;
using webapi.Models.Database.Tournaments;
using webapi.Models.Database.Users;

namespace webapi.Context
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UserRoleContext : DbContext
    {
        //private static readonly MySqlEFConfiguration? _configuration;
        private String _connectionString { get; set; } = String.Empty;
        private Boolean IsStarted { get; set; } = false;

        public UserRoleContext(String connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
            InitContent();
        }
        public UserRoleContext(DbContextOptions<UserRoleContext> option) : base(option)
        {
            IsStarted = true;
        }

        #region DbSet Address
        // Address
        public DbSet<Country>? Countries { get; private set; }
        public DbSet<Province>? Provinces { get; private set; }
        public DbSet<City>? Cities { get; private set; }
        public DbSet<Address>? Addresses { get; private set; }
        public DbSet<Appartement> Appartements { get; private set; }
        #endregion

        #region DbSet Roles
        // Roles
        public DbSet<Discipline>? Disciplines { get; private set; }
        public DbSet<DisciplineUser>? DisciplineUsers { get; private set; }
        public DbSet<ModelHasPersmissions>? ModelHasPersmissions { get; private set; }
        public DbSet<ModelHasRoles>? ModelHasRoles { get; private set; }
        public DbSet<Role>? Roles { get; private set; }
        public DbSet<RoleHasPermission>? RoleHasPermissions { get; private set; }
        #endregion

        #region DbSet Tournaments
        // Tournaments
        public DbSet<Matchup>? Matchups { get; private set; }
        public DbSet<MatchupType>? matchupTypes { get; private set; }
        public DbSet<Player>? Players { get; private set; }
        public DbSet<Roster>? Rosters { get; private set; }
        public DbSet<Team>? Teams { get; private set; }
        public DbSet<Tournament>? Tournaments { get; private set; }
        public DbSet<TournamentValidity> tournamentValidities { get; private set; }
        public DbSet<TournamentPeriod>? TournamentPeriods { get; private set; }
        public DbSet<TournamentPhaese>? TournamentPhaeses { get; private set; }
        public DbSet<TournamentType>? TournamentTypes { get; private set; }
        #endregion

        #region DbSet Users
        // Users
        public DbSet<Permission>? Permissions { get; private set; }
        public DbSet<Skill>? Skills { get; private set; }
        public DbSet<SkillUser>? SkillUsers { get; private set; }
        public DbSet<User>? Users { get; private set; }
        public DbSet<Token> Tokens { get; private set; }
        #endregion

        #region DbSet Camping
        // Camping
        public DbSet<Terrain> Terrains { get; private set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            object value = optionBuilder.UseMySQL(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Address
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(entity =>
            {
                
                entity.HasKey(e => e.IdCountry);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.IdProvince);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.IdAddress);
            });

            modelBuilder.Entity<Appartement>(entity =>
            {
                entity.HasKey(e => e.IdAppartmet);
            });
            #endregion
            #region Roles
            modelBuilder.Entity<Discipline>(entity => {
                entity.HasKey(e => e.IdDiscipline);
            });

            modelBuilder.Entity<DisciplineUser>(entity => {
                entity.HasKey(e => new { e.IdUser, e.IdDiscipline });
            });

            modelBuilder.Entity<ModelHasPersmissions>(entity => {
                entity.HasKey(e => e.IdPermission);
            });

            modelBuilder.Entity<ModelHasRoles>(entity => {
                entity.HasKey(e => e.IdModelHasRoles);
            });

            modelBuilder.Entity<Role>(entity => {
                entity.HasKey(e => e.IdRole);
            });

            modelBuilder.Entity<RoleHasPermission>(entity => {
                entity.HasKey(e => e.IdRolePermission);
            });
            #endregion
            #region Tournaments
            modelBuilder.Entity<Matchup>(entity => {
                entity.HasKey(e => e.IdMatchup);
            });

            modelBuilder.Entity<MatchupType>(entity => {
                entity.HasKey(e => e.IdMatcupType);
            });

            modelBuilder.Entity<Player>(entity => {
                entity.HasKey(e => new { e.IdPlayer, e.IdTeam });
            });

            modelBuilder.Entity<Roster>(entity => {
                entity.HasKey(e => e.IdRoster);
            });

            modelBuilder.Entity<Team>(entity => {
                entity.HasKey(e => e.IdTeam);
            });

            modelBuilder.Entity<Tournament>(entity => {
                entity.HasKey(e => e.IdTournament);
            });

            modelBuilder.Entity<TournamentPeriod>(entity => {
                entity.HasKey(e => e.IdTournamentPeriod);
            });

            modelBuilder.Entity<TournamentPhaese>(entity => {
                entity.HasKey(e => e.IdTournamentPhase);
            });

            modelBuilder.Entity<TournamentType>(entity => {
                entity.HasKey(e => e.IdTournamentType);
            });

            modelBuilder.Entity<TournamentValidity>(entity => {
                entity.HasKey(e => e.IdTournamentValidity);
            });
            #endregion
            #region Users
            modelBuilder.Entity<Permission>(entity => {
                entity.HasKey(e => e.IdPermission);
            });

            modelBuilder.Entity<Skill>(entity => {
                entity.HasKey(e => e.IdSkill);
            });

            modelBuilder.Entity<SkillUser>(entity => {
                entity.HasKey(e => new { e.IdUser, e.IdDiscipline });
            });

            modelBuilder.Entity<User>(entity => {
                entity.HasKey(e => e.IdUser);
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            #endregion
            #region Terrains
            modelBuilder.Entity<Terrain>(entity => {
                entity.HasKey(e => e.IdTerrain);
            });
            #endregion
        }

        private void InitContent()
        {
            foreach(TransitAdresseValue addr in new DbBaseCreationLists().Addresss)
            {
                AddLieu(addr.NamePlace, AddAddress(new TransAddress(addr.DoorNumber,
                                                                    addr.StreetName,
                                                                    addr.StreetName2,
                                                                    addr.AppNumber,
                                                                    addr.Zipcode,
                                                                    AddVille(addr.City,
                                                                    AddProvince(addr.Province,
                                                                    AddCountry(addr.Pays))))));
            }

            foreach(TransitUserValue tuv in  new DbBaseCreationLists().Users)
            {
                AddUser(tuv);
            }

            foreach(TransitTournementType tt in new  DbBaseCreationLists().TournamentType)
            {
                AddTournamentType(tt);
            }
        }
        #region Country
        private Int64 GetCountry(String Name)
        {
            if (Countries == null || Countries.Count() == 0) return 0;
            var test = this.Countries.Where(e => e.Name == Name).FirstOrDefault();
            if (test != null)
                return test.IdCountry;
            return 0;
        }
        private Int64 AddCountry(String Name)
        {
            if(Countries == null) return 0;
            var p = GetCountry(Name);
            if (p == 0)
            {
                Countries.Add(new Country { Name = Name, CreatedAt = DateTime.Now, UpdateddAt = DateTime.Now });
                SaveChanges();
            }
            return GetCountry(Name);
        }
        #endregion
        #region Province
        private Int64 GetProvince(String Name, Int64 pays)
        {
            if (Provinces == null || Provinces.Count() == 0) return 0;
            var test = Provinces.Where(e => e.Name == Name).FirstOrDefault();
            if (test != null)
            {
                return test.IdProvince;
            }
            return 0;
        }

        private Int64 AddProvince(String Name, Int64 pays)
        {
            var p = GetProvince(Name, pays);
            if (p == 0)
            {
                if(Provinces != null) Provinces.Add(new Province { Name = Name, IdCountry = pays, CreatedAt = DateTime.Now, UpdateddAt = DateTime.Now });
                SaveChanges();
            }
            return GetProvince(Name, pays);
        }
        #endregion
        #region Ville
        private Int64 GetVille(String Name, Int64? province)
        {
            if (Cities == null || Cities.Count() == 0) return 0;
            var test = Cities.Where(c => c.Name == Name).FirstOrDefault();
            if (test != null)
            {
                return test.IdCity;
            }
            return 0;
        }

        private Int64 AddVille(String Name, Int64 province)
        {
            var v = GetVille(Name, province);
            if (v == 0)
            {
                if(Cities != null) Cities.Add(new City { Name = Name, IdProvince = province, CreatedAt = DateTime.Now, UpdateddAt = DateTime.Now });
                SaveChanges();
            }
            return GetVille(Name, province);
        }
        #endregion
        #region Adresse
        private Int64 GetAddress(TransAddress ta)
        {
            if (Addresses == null || Addresses.Count() == 0) { return 0; }
            var test = Addresses.Where( e => e.DoorNumber == ta.doorNumber &&
                                        e.StreetName == ta.streetName &&
                                        e.StreetName2 == ta.streetName2 &&
                                        e.AppNumber == ta.appartment &&
                                        e.Zipcode == ta.zipcode &&
                                        e.IdCity == ta.city).FirstOrDefault();
            if(test != null)
            {
                return test.IdAddress;
            }
            return 0;
        }

        private Int64 AddAddress(TransAddress ta)
        {
            if (ta == null) return 0;
            var a = GetAddress(ta);
            if (a == 0)
            {
                if(Addresses != null) Addresses.Add(new Address() { DoorNumber=ta.doorNumber,
                                                                    StreetName=ta.streetName,
                                                                    StreetName2 = ta.streetName2,
                                                                    AppNumber = ta.appartment,
                                                                    Zipcode=ta.zipcode,
                                                                    IdCity = ta.city,
                                                                    CreatedAt = DateTime.Now,
                                                                    UpdateddAt = DateTime.Now});
                SaveChanges();
            }
            return GetAddress(ta);
        }
        #endregion
        #region TournamentType
        private Int64 GetTournamentType(TransitTournementType tt)
        {
            if(TournamentTypes == null || TournamentTypes.Count() == 0) return 0;
            var test = TournamentTypes.Where(e => e.Name == tt.Name).FirstOrDefault();
            if (test != null)
                return test.IdTournamentType;
            return 0;
        }
        private Int64 AddTournamentType(TransitTournementType tt)
        {
            if(tt == null) return 0;
            var a = GetTournamentType(tt);
            if(a == 0)
            {
                if (TournamentTypes != null) TournamentTypes.Add(new TournamentType()
                {
                    Name = tt.Name,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });
                SaveChanges();
            }
            return GetTournamentType(tt);
        }
        #endregion
        #region Nom de lieu
        private Int64 GetLieu(String Name, Int64 idAddress)
        {
            if (Terrains == null || Terrains.Count() == 0) return 0;
            var test = Terrains.Where(e => e.Name == Name && e.IdAddress == idAddress).FirstOrDefault();
            return 0;
        }

        private Int64 AddLieu(String Name, Int64 Address)
        {
            if (Terrains == null) return 0;
            var l = GetLieu(Name, Address);
            if(l == 0)
            {
                Terrains.Add(new Terrain() { Name = Name,
                                             IdAddress = Address,
                                             CreatedAt = DateTime.Now,
                                             UpdateddAt = DateTime.Now });
                SaveChanges();
            }
            return GetLieu(Name, Address);
        }
        #endregion
        #region User
        private Int64 GetUser(TransitUserValue tuv)
        {
            if (Users == null || Users.Count() == 0) return 0;
            var test = Users.Where(e => e.FirstName == tuv.Firstname &&
                                        e.LastName == tuv.Lastname &&
                                        e.Gender == tuv.Gender &&
                                        e.Email == tuv.Email &&
                                        e.Password == tuv.Password).FirstOrDefault();
            if (test != null)
                return test.IdUser;
            return 0;
        }

        private Int64 AddUser(TransitUserValue usersValue)
        {
            if (usersValue == null) return 0;
            var a = GetUser(usersValue);
            if (Users != null)
            {
                if (a == 0)
                {
                    // Identifie l'addresse ID pour la passer à USER
                    // Utiliser l'address ID pour sauvegarder les informations complémentaire de l'adresse (Appt, ...)
                    Int64 IdAddr = new DbLink.Address(this).GetID(usersValue.DoorNumber, usersValue.StreetName);

                    User u = new User()
                    {
                        FirstName = usersValue.Firstname,
                        LastName = usersValue.Lastname,
                        Email = usersValue.Email,
                        Password = usersValue.Password,
                        Gender = usersValue.Gender,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IdAddress = IdAddr,
                        IsActivated = true,
                        ProfilePhoto = new Utils().GetFileContent(usersValue.ProfilePicture)
                    };
                    // Enregistrement de l'utilisateur
                    new DbLink.Users(this).AddUser(u);

                    // Enregistrement des informations complémentaires
                    if(usersValue.Infos != null)
                        new DbLink.Address(this).AddInfos(IdAddr, usersValue.Infos);
                }
            }
            return GetUser(usersValue);
        }
        #endregion
    }
}
