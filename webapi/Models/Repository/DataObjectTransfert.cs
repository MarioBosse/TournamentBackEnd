//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository
// Description : Classe qui établie les valeurs par défauts de la base de données
//               du projet. Toutes les tables devant avoir dds valeurs par défaut
//               doivent être inscrites dans cette classe.
//
//----------------------------------------------------------------------------------
using webapi.Context;

namespace webapi.Models.Repository
{
    //----------------------------------------------------------------------------------
    //
    // Définition de Class
    // Nom : DataObjectTransfert
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class DataObjectTransfert
    {
        public Login.Complements.Address? GetAddress(Database.Address.Address address, UserRoleContext context)
        {
            if (context == null) return null;

            if (context != null &&
                context.Cities != null && context.Provinces != null && context.Countries != null &&
                context.Cities.Any() && context.Provinces.Any() && context.Countries.Any())
            {
                return new Login.Complements.Address()
                {
                    DoorNumber = address.DoorNumber,
                    AppNumber = address.AppNumber,
                    StreetName = address.StreetName,
                    StreetName2 = address.StreetName2,
                    City = GetCityName(context, address.IdCity),
                    State = GetProvinceName(context, address.IdCity),
                    Zipcode = address.Zipcode,
                    Country = GetCountryName(context, address.IdCity)
                };
            }
            return null;
        }

        private String GetCountryName(UserRoleContext ctx, Int64? Id)
        {
            if (ctx == null || ctx.Cities == null || ctx.Provinces == null || ctx.Countries == null) return String.Empty;

            var c = ctx.Cities.Where(e => e.IdCity == Id).FirstOrDefault();
            if (c == null) return String.Empty;

            var p = ctx.Provinces.Where(e => e.IdProvince == c.IdProvince).FirstOrDefault();
            if (p == null) return String.Empty;

            var cy = ctx.Countries.Where(e => e.IdCountry == p.IdCountry).FirstOrDefault();
            if(cy == null) return String.Empty;

            return cy.Name;
        }

        private String GetProvinceName(UserRoleContext ctx, Int64? Id)
        {
            if (ctx == null || ctx.Cities == null || ctx.Provinces == null) return String.Empty;

            var c = ctx.Cities.Where(e => e.IdCity == Id).FirstOrDefault();
            if (c == null) return String.Empty;

            var p = ctx.Provinces.Where(e => e.IdProvince == c.IdProvince).FirstOrDefault();
            if (p == null) return String.Empty;

            return p.Name;
        }

        private String GetCityName(UserRoleContext ctx, Int64? Id)
        {
            if (ctx == null || ctx.Cities == null) return String.Empty;

            var c = ctx.Cities.Where(e => e.IdCity == Id).FirstOrDefault();
            if (c == null) return String.Empty;

            return c.Name;
        }
    }
}
