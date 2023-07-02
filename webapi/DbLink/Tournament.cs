using webapi.Context;
using webapi.Models.Tournaments;
using webapi.Models.Repository.Tournament.TypesRetour;

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

        public List<TournamentType> GetAllTypes()
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            return (_roleContext.TournamentTypes.Where(e => e.IdTournamentType > 0).ToList());
        }

        public Add TournamentTypeAdd(String type)
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var add = _roleContext.TournamentTypes.Add(new TournamentType() { Name = type});
            var save = _roleContext.SaveChanges();


            return GetTypeInfo(type);
        }

        private Add GetTypeInfo(String type)
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var rec = _roleContext.TournamentTypes.Where(e => e.Name == type).FirstOrDefault();
            Add nouv = new  Add()
            {
                Name = type,
                Id = rec.IdTournamentType
            };
            return nouv;
        }
    }
}
