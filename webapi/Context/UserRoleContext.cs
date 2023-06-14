using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;
using webapi.Models.Address;
using webapi.Models.Tournaments;
using webapi.Models.Users;
using webapi.Models.UsersRoles;

namespace webapi.Context
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UserRoleContext : DbContext
    {
        //private static readonly MySqlEFConfiguration? _configuration;
        private String _connectionString = "Server=localhost; User ID=root; Password=root; Database=TournamentMgr";
        public Boolean IsStarted { get; set; } = false;
        public UserRoleContext(String connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }
        public UserRoleContext(DbContextOptions<UserRoleContext> option) : base(option)
        {
            IsStarted = true;
        }


        // Address
        public DbSet<Country>? Countries { get; private set; }
        public DbSet<Province>? Provinces { get; private set; }
        public DbSet<City>? Cities { get; private set; }
        public DbSet<Address>? Addresses { get; private set; }

        // Roles
        public DbSet<Discipline>? Disciplines { get; private set; }
        public DbSet<DisciplineUser>? DisciplineUsers { get; private set; }
        public DbSet<ModelHasPersmissions>? ModelHasPersmissions { get; private set; }
        public DbSet<ModelHasRoles>? ModelHasRoles { get; private set; }
        public DbSet<Role>? Roles { get; private set; }
        public DbSet<RoleHasPermission>? RoleHasPermissions { get; private set; }

        // Tournaments
        public DbSet<Matchup>? Matchups { get; private set; }
        public DbSet<MatchupType>? matchupTypes { get; private set; }
        public DbSet<Player>? Players { get; private set; }
        public DbSet<Roster>? Rosters { get; private set; }
        public DbSet<Team>? Teams { get; private set; }
        public DbSet<Tournament>? Tournaments { get; private set; }
        public DbSet<TournamentPeriod>? TournamentPeriods { get; private set; }
        public DbSet<TournamentPhaese>? TournamentPhaeses { get; private set; }
        public DbSet<TournamentType>? TournamentTypes { get; private set; }

        // Users
        public DbSet<Permission>? Permissions { get; private set; }
        public DbSet<Skill>? Skills { get; private set; }
        public DbSet<SkillUser>? SkillUsers { get; private set; }
        public DbSet<User>? Users { get; private set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            object value = optionBuilder.UseMySQL(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.IdProvince);
                entity.Property(f => f.IdCountry).IsRequired();
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity);
                entity.Property(e => e.IdProvince).IsRequired();
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.IdAddress);
                entity.Property(e => e.IdCity).IsRequired();
            });


            modelBuilder.Entity<Discipline>(entity => {
                entity.HasKey(e => e.IdDiscipline);
                entity.Property(e => e.Activity).IsRequired();
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
        }
    }
}
