using webapi.Context;

namespace webapi.DbLink
{
    public class Address
    {
        private UserRoleContext _roleContext;
        public Address(UserRoleContext userRoleContext)
        {
            _roleContext = userRoleContext;
        }
        public Int64 GetID(String doorNumber, String streetName)
        {
            if (_roleContext == null || _roleContext.Addresses == null) return 0;
            var add = _roleContext.Addresses.Where(e => e.DoorNumber == doorNumber && e.StreetName == streetName).FirstOrDefault();
            if (add == null) return 0;

            return add.IdAddress;
        }

        public void AddInfos(Int64 idAddr, String[] infos)
        {
            foreach (var info in infos)
            {
                _roleContext.Appartements.Add(new Models.Database.Address.Appartement() { IdAddress = idAddr, Information = info });
            }
            _roleContext.SaveChanges();
        }
    }
}
