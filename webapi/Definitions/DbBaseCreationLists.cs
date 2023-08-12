﻿//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Definitions
// Description : Classe qui effectue l'enregistrement des valeurs par défaut
//               présente dans la base de données.
//
//----------------------------------------------------------------------------------
using webapi.Models.Database.Building;

namespace webapi.Definitions
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Definitions
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class DbBaseCreationLists
    {
        public List<TransitAdresseValue> Addresss { get; private set; } = new List<TransitAdresseValue>();
        public List<TransitUserValue> Users { get; private set; } = new List<TransitUserValue>();
        public List<TransitTournementType> TournamentType { get; private set; } = new List<TransitTournementType>();
        public List<TransitRoles> Roles { get; private set; } = new List<TransitRoles>();

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Constructeur
        // Nom : DbBaseCreationList
        // Description : Classe responsable de la cération des données de base de la base de
        //               donnée. Toutes les données par défaut devant être entreposé dans la
        //               base de données le sont par le biais de cette classe et des ses
        //               fonctions.
        // Paramètres : Aucun
        // 
        //----------------------------------------------------------------------------------
        public DbBaseCreationLists()
        {
            InitAddress();
            InitRoles();
            InitUsers();
            InitTournamentType();
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Private
        // Base d'enregistrement : Aucun
        // Type de retour : Aucun
        // Nom : InitUsers
        // Description : Ajout des usager par défaut responsable de la gestion des données
        //               du projet.
        // Paramètres : Aucun
        // 
        //----------------------------------------------------------------------------------
        private void InitUsers()
        {
            this.Users.Clear();
            this.Users.AddRange(new List<TransitUserValue>()
            {
                new TransitUserValue() { Firstname="Mario", Lastname="Bossé", Gender="M", Roles = 129, IsActivated = true, Email="mario.bosse@cssc.gouv.qc.ca", Password="Smf1968/#123", Birthdate=new DateTime(1968,03,08), DoorNumber="464", StreetName="Rte François Gignac", Infos = new string[] { "Terrain 826" }, ProfilePicture="C:\\Users\\31673\\OneDrive - CSS de la Capitale\\Images\\Pellicule\\Moi - 2021-09-01.jpg" }
            });
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Private
        // Base d'enregistrement : Aucun
        // Type de retour : Aucun
        // Nom : InitTournamentType
        // Description : Ajout des déférents type de tournoi supporté par défaut dans
        //               l'application. D'autre peuvent être ajoutés via les différents
        //               interface offert.
        // Paramètres : Aucune
        // 
        //----------------------------------------------------------------------------------
        private void InitTournamentType()
        {
            TournamentType.Clear();
            TournamentType.AddRange(new List<TransitTournementType>()
            {
                new TransitTournementType() { Name = "Pétancle" },
                new TransitTournementType() { Name = "Fer" },
                new TransitTournementType() { Name = "Whist militaire" },
                new TransitTournementType() { Name = "Cribe" },
                new TransitTournementType() { Name = "Tenis" },
                new TransitTournementType() { Name = "Washer" },
                new TransitTournementType() { Name = "Art martial" },
                new TransitTournementType() { Name = "Hockey" }
            });
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Private
        // Base d'enregistrement : Aucun
        // Type de retour : Aucun
        // Nom : InitRoles
        // Description : Ajoute les définitions de Roles qui sont disponible pour
        //               l'utilisation de l'application de gestion de tournoi.
        // Paramètres : Aucun
        // 
        //----------------------------------------------------------------------------------
        private void InitRoles()
        {
            this.Roles.Clear();
            this.Roles.AddRange(new List<TransitRoles>()
            {
                new TransitRoles() { Name = "Administrateur",           IsActivated = true, GuardName = "Admin",                Mask =   1 },
                new TransitRoles() { Name = "Superviseur",              IsActivated = true, GuardName = "Supervisor",           Mask =   2 },
                new TransitRoles() { Name = "Proprietaire",             IsActivated = true, GuardName = "Owner",                Mask =   4 },
                new TransitRoles() { Name = "TournoiAdministrateur",    IsActivated = true, GuardName = "TournamentAdmin",      Mask =   8 },
                new TransitRoles() { Name = "CoPropietaire",            IsActivated = true, GuardName = "CoOwner",              Mask =  16 },
                new TransitRoles() { Name = "TournoiSuperviseur",       IsActivated = true, GuardName = "TournamentSupervisor", Mask =  32 },
                new TransitRoles() { Name = "Participant",              IsActivated = true, GuardName = "Player",               Mask =  64 },
                new TransitRoles() { Name = "Developeur",               IsActivated = true, GuardName = "Devloper",             Mask = 128 },
                new TransitRoles() { Name = "Juge",                     IsActivated = true, GuardName = "Judge",                Mask = 256 },
                new TransitRoles() { Name = "Marqueur",                 IsActivated = true, GuardName = "Marquee",              Mask = 512 }
            });
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Private
        // Base d'enregistrement : Aucun
        // Type de retour : Aucun
        // Nom : InitAddress
        // Description : Ajoute les addresses par défaut qui sont enregistré dans la base
        //               de données. Dans le cadre de ce projet, les adresses inscrit sont
        //               celles des terrains de camping gèré par l'entreprise Parkbridge
        //               Canada.
        // Paramètres : Aucun
        // 
        //----------------------------------------------------------------------------------
        private void InitAddress()
        {
            this.Addresss.Clear();
            this.Addresss.AddRange( new List<TransitAdresseValue>()
            {
                new TransitAdresseValue() { NamePlace="Gallager Lake"      , DoorNumber="8439",         StreetName="BC-97",                       City="Oliver",                   Zipcode="V0H 1T2", Province="Colombie Britanique", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Oceanside"          , DoorNumber="3000",         StreetName="Stautw Rd",                   City="Saanichton",               Zipcode="V8M 2K5", Province="Colombie Britanique", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Riverside"          , DoorNumber="8018",         StreetName="Mons Rd",                     City="Whistler",                 Zipcode="V8E 1K6", Province="Colombie Britanique", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Rondalyn"           , DoorNumber="1350",         StreetName="Timberlands Rd",              City="Ladysmith",                Zipcode="V9G 1L5", Province="Colombie Britanique", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Pine Lake Leisure"  , DoorNumber="25125",        StreetName="Township Rd Hwy 42 E",        City="Pine Lake",                Zipcode="T0M 1S0", Province="Alberta", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="RT Dev Test 7 March", DoorNumber="",             StreetName="RT Dev Test 7 March",         City="32",                       Zipcode="",        Province="Alberta", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Shadybrook"         , DoorNumber="53104",        StreetName="AB-31",                       City="Seba Beach",               Zipcode="T0E 2B0", Province="Alberta", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Bailey's Bay"       , DoorNumber="78",           StreetName="Lindsay Rd",                  City="Selwyn",                   Zipcode="K9J 0C5", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Beaver Narrows"     , DoorNumber="433",          StreetName="Beaver Rd",                   City="Omemee",                   Zipcode="K0L 2W0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Grand River"        , DoorNumber="1001",         StreetName="Haldimand County Rd 17",      City="Cayuga",                   Zipcode="N0A 1E0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Grandview"          , DoorNumber="626",          StreetName="Kerry Line",                  City="Ennismore",                Zipcode="K0L 1T0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Leisure Lake"       , DoorNumber="510",          StreetName="County Rd 31",                City="Ruthven",                  Zipcode="N0P 2G0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Lonesome Pine"      , DoorNumber="2346",         StreetName="Pigeon Lake Rd",              City="Bobcaygeon",               Zipcode="H0M 1A0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Melody Bay"         , DoorNumber="33",           StreetName="Fire Rte 26A",                City="Buckhorn",                 Zipcode="K0L 1J0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Nestle In"          , DoorNumber="2152",         StreetName="Kawartha Lakes County Rd 36", City="Dunsford",                 Zipcode="K0M 1L0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Our Ponderosa"      , DoorNumber="9338",         StreetName="W Ipperwash Rd",              City="Lambton Shores",           Zipcode="N0N 1J2", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Pioneer Point"      , DoorNumber="2560",         StreetName="Westview Rd",                 City="Lakefield",                Zipcode="K0L 2H0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Scugog Landing"     , DoorNumber="225",          StreetName="Platten Blvd",                City="Port Perry",               Zipcode="L9L 1B4", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Shady Acres"        , DoorNumber="6R6P+WP, 740", StreetName="Serpent Mounds Rd",           City="Keene",                    Zipcode="K0L 2G0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Silent Valley"      , DoorNumber="142571",       StreetName="35 Rd",                       City="Ayton",                    Zipcode="N0G 1C0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Skyline"            , DoorNumber="920",          StreetName="Skyline Rd",                  City="Ennismore",                Zipcode="K0L 1T0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Spring Lake"        , DoorNumber="263459",       StreetName="rouse Road, RR#1",            City="Mount Elgin",              Zipcode="N0J 1N0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Spring Valley"      , DoorNumber="7489",         StreetName="Sideroad 5 E",                City="Mount Forest",             Zipcode="N0G 2L0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Victoria Harbour"   , DoorNumber="10",           StreetName="Winfield Dr",                 City="Victoria Harbour",         Zipcode="L0K 2A0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Wasaga CountryLife" , DoorNumber="40",           StreetName="Mosley St",                   City="Wasaga Beach",             Zipcode="L9Z 2K3", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Wasaga Dunes"       , DoorNumber="4300",         StreetName="County Rd 29",                City="Tiny",                     Zipcode="L0L 2T0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Wasaga Pines"       , DoorNumber="1780",         StreetName="County Rd. #92 Elmvale",      City="Springwater",              Zipcode="L0L 1P0", Province="Ontario", Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Alouette"           , DoorNumber="3449",         StreetName="De L'Industrie",              City="Saint-Mathieu-de-Beloeil", Zipcode="J3G 0R9", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Caravelle"          , DoorNumber="180",          StreetName="Rang de la Gare",             City="Sainte-Sabine",            Zipcode="J0J 2B0", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Domaine de la Chute", DoorNumber="74",           StreetName="Chem. de la Chute",           City="Saint-Apollinaire",        Zipcode="G0S 2E0", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Domaine des Érables", DoorNumber="500",          StreetName="Rue Saint-Pierre",            City="Saint-Rock-De-Richelieu",  Zipcode="J0L 2M0", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Domaine Parc Estrie", DoorNumber="19",           StreetName="Rue du Domaine",              City="Magog",                    Zipcode="J1X 5Z3", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="La Roche d'Or"      , DoorNumber="3005",         StreetName="Route-du-Président-Kennedy",  City="Notre-Dame-des-Pins",      Zipcode="G0M 1K0", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Lac du Repos"       , DoorNumber="5715",         StreetName="Rang de la Rivière N",        City="Saint-Jean-Baptiste",      Zipcode="J0L 2B0", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Lac Lafontaine"     , DoorNumber="1100",         StreetName="Bd du Grand Héron",           City="Saint-Jérôme",             Zipcode="J5L 1G2", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Panoramique"        , DoorNumber="464",          StreetName="Rte François Gignac",         City="Portneuf",                 Zipcode="G0A 2Y0", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Parc La Conception" , DoorNumber="1158",         StreetName="Rte des Ormes",               City="La Conception",            Zipcode="J0T 1M0", Province="Québec",  Pays="Canada" },
                new TransitAdresseValue() { NamePlace="Royal Papineau"     , DoorNumber="237",          StreetName="Chem. du Golf",               City="Notre-Dame-de-la-Selette", Zipcode="J0X 2L0", Province="Québec",  Pays="Canada" }
            });
        }
    }
}
