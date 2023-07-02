using webapi.Context;
using webapi.Models.Tournaments;
using webapi.Models.Repository.Tournament.TypesRetour;
using webapi.Models.Repository.Tournament.Types;

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

        public List<TournamentType>? GetAllTypes()
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            return (_roleContext.TournamentTypes.Where(e => e.IdTournamentType > 0).ToList());
        }

        public Add? TournamentTypeAdd(String type)
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var add = _roleContext.TournamentTypes.Add(new TournamentType() { Name = type});
            var save = _roleContext.SaveChanges();

            return GetTypeInfo(type);
        }

        private Add? GetTypeInfo(String type)
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var rec = _roleContext.TournamentTypes.Where(e => e.Name == type).FirstOrDefault();

            if (rec == null) return null;
            Add nouv = new  Add()
            {
                Name = type,
                Id = rec.IdTournamentType
            };
            return nouv;
        }

        public Add? TournamenetTypeModify(TournamentTypeModify data)
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var rec = _roleContext.TournamentTypes.Where(e => e.Name == data.Origin).FirstOrDefault();
            if (rec != null)
            {
                rec.Name = data.Destination;
                _roleContext.TournamentTypes.Update(rec);
                _roleContext.SaveChanges();

                Add nouv = new Add() { Id = rec.IdTournamentType, Name = data.Destination };
                return nouv;
            }
            return null;
        }
    }
}
