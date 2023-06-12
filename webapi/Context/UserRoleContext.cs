using MySql.Data.EntityFramework;
using System.Data.Common;
using System.Data.Entity;
using webapi.Models.Address;
using webapi.Models.Tournaments;
using webapi.Models.Users;
using webapi.Models.UsersRoles;

namespace webapi.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UserRoleContext : DbContext
    {
        private static readonly MySqlEFConfiguration? _configuration;
        private String? connectionString = String.Empty;

        // Address
        public DbSet<Country> Countries { get; private set; }
        public DbSet<Province> Provinces { get; private set; }
        public DbSet<City> Cities { get; private set; }
        public DbSet<Address> Addresses { get; private set; }

        // Roles
        public DbSet<Discipline>? Disciplines { get; private set; }
        public DbSet<DisciplineUser>? DisciplineUsers { get; private set; }
        public DbSet<ModelHasPersmissions>? ModelHasPersmissions { get; private set; }
        public DbSet<ModelHasRoles>? modelHasRoles { get; private set; }
        public DbSet<Role>? Roles { get; private set; }
        public DbSet<RoleHasPermission>? RoleHasPermissions { get; private set; }

        // Tournaments
        public DbSet<Player> Players { get; private set; }
        public DbSet<Team> Teams { get; private set; }

        // Users
        public DbSet<Address> Addresses { get; private set; }
        public DbSet<Permission>? Permissions { get; private set; }
        public DbSet<Skill>? Skills { get; private set; }
        public DbSet<SkillUser>? SkillUsers { get; private set; }
        public DbSet<User>? Users { get; private set; }

        public UserRoleContext() : base()
        {
        }

        public UserRoleContext(DbConnection existingConnection, bool contextOwnsConnection, IConfiguration configuration)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
