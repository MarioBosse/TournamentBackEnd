﻿using webapi.Models.Address;
using webapi.Models.Building;
using webapi.Models.Camping;

namespace webapi.Definitions
{
    public class DbBaseCreationLists
    {
        public List<TransitValue> Addresss { get; private set; } = new List<TransitValue>();

        public DbBaseCreationLists()
        {
            InitAddress();
        }

        private void InitAddress()
        {
            this.Addresss.Clear();
            this.Addresss.AddRange( new List<TransitValue>()
            {
                new TransitValue() { NamePlace="Gallager Lake"      , DoorNumber="8439",         StreetName="BC-97",                       City="Oliver",                   Zipcode="V0H 1T2", Province="Colombie Britanique", Pays="Canada" },
                new TransitValue() { NamePlace="Oceanside"          , DoorNumber="3000",         StreetName="Stautw Rd",                   City="Saanichton",               Zipcode="V8M 2K5", Province="Colombie Britanique", Pays="Canada" },
                new TransitValue() { NamePlace="Riverside"          , DoorNumber="8018",         StreetName="Mons Rd",                     City="Whistler",                 Zipcode="V8E 1K6", Province="Colombie Britanique", Pays="Canada" },
                new TransitValue() { NamePlace="Rondalyn"           , DoorNumber="1350",         StreetName="Timberlands Rd",              City="Ladysmith",                Zipcode="V9G 1L5", Province="Colombie Britanique", Pays="Canada" },
                new TransitValue() { NamePlace="Pine Lake Leisure"  , DoorNumber="25125",        StreetName="Township Rd Hwy 42 E",        City="Pine Lake",                Zipcode="T0M 1S0", Province="Alberta", Pays="Canada" },
                new TransitValue() { NamePlace="RT Dev Test 7 March", DoorNumber="",             StreetName="RT Dev Test 7 March",         City="32",                       Zipcode="",        Province="Alberta", Pays="Canada" },
                new TransitValue() { NamePlace="Shadybrook"         , DoorNumber="53104",        StreetName="AB-31",                       City="Seba Beach",               Zipcode="T0E 2B0", Province="Alberta", Pays="Canada" },
                new TransitValue() { NamePlace="Bailey's Bay"       , DoorNumber="78",           StreetName="Lindsay Rd",                  City="Selwyn",                   Zipcode="K9J 0C5", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Beaver Narrows"     , DoorNumber="433",          StreetName="Beaver Rd",                   City="Omemee",                   Zipcode="K0L 2W0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Grand River"        , DoorNumber="1001",         StreetName="Haldimand County Rd 17",      City="Cayuga",                   Zipcode="N0A 1E0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Grandview"          , DoorNumber="626",          StreetName="Kerry Line",                  City="Ennismore",                Zipcode="K0L 1T0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Leisure Lake"       , DoorNumber="510",          StreetName="County Rd 31",                City="Ruthven",                  Zipcode="N0P 2G0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Lonesome Pine"      , DoorNumber="2346",         StreetName="Pigeon Lake Rd",              City="Bobcaygeon",               Zipcode="H0M 1A0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Melody Bay"         , DoorNumber="33",           StreetName="Fire Rte 26A",                City="Buckhorn",                 Zipcode="K0L 1J0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Nestle In"          , DoorNumber="2152",         StreetName="Kawartha Lakes County Rd 36", City="Dunsford",                 Zipcode="K0M 1L0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Our Ponderosa"      , DoorNumber="9338",         StreetName="W Ipperwash Rd",              City="Lambton Shores",           Zipcode="N0N 1J2", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Pioneer Point"      , DoorNumber="2560",         StreetName="Westview Rd",                 City="Lakefield",                Zipcode="K0L 2H0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Scugog Landing"     , DoorNumber="225",          StreetName="Platten Blvd",                City="Port Perry",               Zipcode="L9L 1B4", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Shady Acres"        , DoorNumber="6R6P+WP, 740", StreetName="Serpent Mounds Rd",           City="Keene",                    Zipcode="K0L 2G0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Silent Valley"      , DoorNumber="142571",       StreetName="35 Rd",                       City="Ayton",                    Zipcode="N0G 1C0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Skyline"            , DoorNumber="920",          StreetName="Skyline Rd",                  City="Ennismore",                Zipcode="K0L 1T0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Spring Lake"        , DoorNumber="263459",       StreetName="rouse Road, RR#1",            City="Mount Elgin",              Zipcode="N0J 1N0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Spring Valley"      , DoorNumber="7489",         StreetName="Sideroad 5 E",                City="Mount Forest",             Zipcode="N0G 2L0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Victoria Harbour"   , DoorNumber="10",           StreetName="Winfield Dr",                 City="Victoria Harbour",         Zipcode="L0K 2A0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Wasaga CountryLife" , DoorNumber="40",           StreetName="Mosley St",                   City="Wasaga Beach",             Zipcode="L9Z 2K3", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Wasaga Dunes"       , DoorNumber="4300",         StreetName="County Rd 29",                City="Tiny",                     Zipcode="L0L 2T0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Wasaga Pines"       , DoorNumber="1780",         StreetName="County Rd. #92 Elmvale",      City="Springwater",              Zipcode="L0L 1P0", Province="Ontario", Pays="Canada" },
                new TransitValue() { NamePlace="Alouette"           , DoorNumber="3449",         StreetName="De L'Industrie",              City="Saint-Mathieu-de-Beloeil", Zipcode="J3G 0R9", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="Caravelle"          , DoorNumber="180",          StreetName="Rang de la Gare",             City="Sainte-Sabine",            Zipcode="J0J 2B0", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="Domaine de la Chute", DoorNumber="74",           StreetName="Chem. de la Chute",           City="Saint-Apollinaire",        Zipcode="G0S 2E0", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="Domaine des Érables", DoorNumber="500",          StreetName="Rue Saint-Pierre",            City="Saint-Rock-De-Richelieu",  Zipcode="J0L 2M0", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="Domaine Parc Estrie", DoorNumber="19",           StreetName="Rue du Domaine",              City="Magog",                    Zipcode="J1X 5Z3", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="La Roche d'Or"      , DoorNumber="3005",         StreetName="Route-du-Président-Kennedy",  City="Notre-Dame-des-Pins",      Zipcode="G0M 1K0", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="Lac du Repos"       , DoorNumber="5715",         StreetName="Rang de la Rivière N",        City="Saint-Jean-Baptiste",      Zipcode="J0L 2B0", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="Lac Lafontaine"     , DoorNumber="1100",         StreetName="Bd du Grand Héron",           City="Saint-Jérôme",             Zipcode="J5L 1G2", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="Panoramique"        , DoorNumber="464",          StreetName="Rte François Gignac",         City="Portneuf",                 Zipcode="G0A 2Y0", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="Parc La Conception" , DoorNumber="1158",         StreetName="Rte des Ormes",               City="La Conception",            Zipcode="J0T 1M0", Province="Québec",  Pays="Canada" },
                new TransitValue() { NamePlace="Royal Papineau"     , DoorNumber="237",          StreetName="Chem. du Golf",               City="Notre-Dame-de-la-Selette", Zipcode="J0X 2L0", Province="Québec",  Pays="Canada" }
            });
        }
    }
}