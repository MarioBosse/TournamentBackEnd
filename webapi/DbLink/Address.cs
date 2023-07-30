using webapi.Context;
using webapi.Models.Database.Address;
using webapi.Models.Database.Building;
using webapi.Models.Repository.Users;

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

        public UserAddress? Get(Int64? id)
        {
            if(id == null ||
               _roleContext == null ||
               _roleContext.Addresses == null ||
               _roleContext.Cities == null ||
               _roleContext.Provinces == null ||
               _roleContext.Countries == null)
                return null;

            Models.Database.Address.Address? adr = _roleContext.Addresses.Where(e => e.IdAddress == id).FirstOrDefault();
            List<Appartement> app = _roleContext.Appartements.Where(a => a.IdAddress == id).ToList();

            if (adr == null) return null;
            City? city = _roleContext.Cities.Where(c => c.IdCity == adr.IdCity).FirstOrDefault();
            if (city == null) return null;
            Province? prov = _roleContext.Provinces.Where(p => p.IdProvince == city.IdProvince).FirstOrDefault();
            if (prov == null) return null;
            Country? pays = _roleContext.Countries.Where(py => py.IdCountry == prov.IdCountry).FirstOrDefault();
            if (pays == null) return null;

            return BuildUserBase(new Object[] { adr, app, city, prov, pays });
        }

        private UserAddress? BuildUserBase(Object[] obj)
        {
            UserAddress addr = new UserAddress();
            foreach (var item in obj)
            {
                switch(item.GetType().ToString())
                {
                    case "webapi.Models.Database.Address.Address":
                        var t = (webapi.Models.Database.Address.Address)item;
                        addr.DoorNumber = t.DoorNumber;
                        addr.StreetName = t.StreetName;
                        addr.StreetName2 = t.StreetName2;
                        addr.Zipcode = t.Zipcode;
                        addr.AppNumber = t.AppNumber;
                        break;
                    case "webapi.Models.Database.Address.City":
                        addr.City = new UserCity();
                        var ct = (City)item;
                        addr.City.IdCity = ct.IdCity;
                        addr.City.Name = ct.Name;
                        break;
                    case "webapi.Models.Database.Address.Province":
                        var pr = (Province)item;
                        addr.Province = new UserProvince();
                        addr.Province.IdProvince = pr.IdProvince;
                        addr.Province.Name = pr.Name;
                        break;
                    case "webapi.Models.Database.Address.Country":
                        var py = (Country)item;
                        addr.Pays = new UserPays();
                        addr.Pays.IdPays = py.IdCountry;
                        addr.Pays.Name = py.Name;
                        break;
                    case "System.Collections.Generic.List`1[webapi.Models.Database.Address.Appartement]":
                        List<Appartement>? a = (List<Appartement>)item;
                        if(a != null)
                        {
                            foreach(Appartement p in a)
                            {
                                addr.lComplement.Add(p.Information);
                                addr.Complement = addr.lComplement.ToArray();
                            }
                        }
                        break;
                }
            }
            return addr;
        }
    }
}
