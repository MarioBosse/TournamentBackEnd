//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.DbLink
// Description : Cette classe effectue le lien entre les controleurs et les différents
//               DbContext lié à l'interprétation et a l'utilisation des données de
//               la base de donnée en lien avec les tournois et leurs définition.
//               Celle-ci effectue tous les appels vers la base de données ainsi
//               que l'interprétation  de ces données avant d'être retourné vers
//               l'application pour être affiché à l'écran.
//
//----------------------------------------------------------------------------------
using webapi.Context;
using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Tournament.TypesRetour;
using webapi.Models.Repository.Tournament.Types;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Tournament;

namespace webapi.DbLink
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Tournament
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class Tournament
    {
        private UserRoleContext _roleContext { get; set; }
        private IConfiguration _configuration { get; set; }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Constructeur
        // Nom : Tournament
        // Description : Fonction contructeur pour la classe Tournament. Cette classe
        //               effectue tous les appels et le traitement des données en lien avec
        //               les définitions de tournoi.
        // Paramètres : Deux (2) valeurs sont passé en paramêtre afin d'effectuer cette
        //              tâche.
        //      UserRoleContext context         Pointe sur le DbContext de la base de
        //                                      données du projet.
        //      IConfiguration  contiguration   Pointe sur le fichier de configuration
        //                                      utilisé pour le gestionnaire de tournoi.
        //
        //----------------------------------------------------------------------------------
        public Tournament(UserRoleContext context, IConfiguration configuration)
        {
            _roleContext = context;
            _configuration = configuration;
        }



        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : GetAllType  La valeur de retour peut être NULL
        // Nom : GetAllTypes
        // Description : Retourne la liste de tous les types de tournoi définie dans la base
        //               de données.
        // Paramètres : Tokencheck  tokenCheck  Contien les information du jeton de
        //                                      connexion a valider.
        //
        //----------------------------------------------------------------------------------
        public GetAllType? GetAllTypes(TokenCheck tokenCheck)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new GetAllType() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var r = new GetAllType()
            {
                TournamentTypes = _roleContext.TournamentTypes.Where(e => e.IdTournamentType > 0).ToArray(),
                Validation = token
            };
            return r;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : DeleteType
        // Nom : TournamentTypeDelete
        // Description : Fonction qui désactive un élément de la table TournamentType.
        // Paramètres : TournamentTypeDelete    deleteType  Contien les informatiosn de
        //                                                  l'élément TournamnentType a
        //                                                  désactiver.
        //
        //----------------------------------------------------------------------------------
        public DeleteType? TournamentTypeDelete(TournamentTypeDelete deleteType)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(deleteType.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(deleteType.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new DeleteType() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            TournamentType? tourType = new TournamentType();
            if (deleteType.tournamentType.Name.Length > 1)
                tourType = _roleContext.TournamentTypes.Where(t => t.Name == deleteType.tournamentType.Name).FirstOrDefault();
            else if (deleteType.tournamentType.IdTournamentType > 0)
                tourType = _roleContext.TournamentTypes.Where(e => e.IdTournamentType == deleteType.tournamentType.IdTournamentType).FirstOrDefault();
            if(tourType == null) return new DeleteType() { Validation = token, DeleteDone = false };

            var result = _roleContext.TournamentTypes.Remove(tourType);
            DeleteType? delete = new DeleteType() { Validation = token, DeleteDone = true };
            return delete;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : AddType     La valeur de retour peut être NULL
        // Nom : TournamentTypeAdd
        // Description : Cette fonction ajoute un nouveau type de tournoi dans la base de
        //               données.
        // Paramètres : TournamentTypeAddRead   ajoutType   Contient les informations du
        //                                                  nouveau type de tournoi a
        //                                                  ajouter dans la base de données.
        //
        //----------------------------------------------------------------------------------
        public AddType? TournamentTypeAdd(TournamentTypeAddRead ajoutType)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(ajoutType.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(ajoutType.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new AddType() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            _roleContext.TournamentTypes.Add(new TournamentType() { Name = ajoutType.Description });
            _roleContext.SaveChanges();

            AddType? add = GetTypeInfo(ajoutType.Description);
            if (add == null) { return null; }

            add.Validation = token;
            return add;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : AddType     La valeur de retour peut être NULL
        // Nom : TournamentTypeModify
        // Description : Cette fonction modify les informations contenue dans le type de
        //               tournois.
        // Paramètres : TournamentTypeModify    Contient les informations au type de tournois
        //                                      à modifier ainsi que les nouvelles
        //                                      informations a enregistrer dans la base de
        //                                      données.
        //
        //----------------------------------------------------------------------------------
        public AddType? TournamentTypeModify(TournamentTypeModify data)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(data.TokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(data.TokenCheck);
            if (isValide == null || !isValide.IsValid) return (new AddType() { Validation = token });

            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var rec = _roleContext.TournamentTypes.Where(e => e.Name == data.Origin).FirstOrDefault();
            if (rec != null)
            {
                rec.Name = data.Destination;
                _roleContext.TournamentTypes.Update(rec);
                _roleContext.SaveChanges();

                AddType nouv = new AddType() { Id = rec.IdTournamentType, Name = data.Destination, Validation = token };
                return nouv;
            }
            return null;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Private
        // Base d'enregistrement : Aucun
        // Type de retour : AddType     La valeur de retour peut être NULL
        // Nom : GetTypeInfo
        // Description : Retourne les information sur le type de tournoi recherché.
        // Paramètres : String  type    Chaine de caractère contenant le type de tournoi a
        //                              rechercher.
        //
        //----------------------------------------------------------------------------------
        private AddType? GetTypeInfo(String type)
        {
            if (_roleContext == null || _roleContext.TournamentTypes == null) return null;
            var rec = _roleContext.TournamentTypes.Where(e => e.Name == type).FirstOrDefault();

            if (rec == null) return null;
            AddType nouv = new AddType()
            {
                Name = type,
                Id = rec.IdTournamentType
            };
            return nouv;
        }


        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : GetAll  La valeur de retour peut être NULL.
        // Nom : GetAllActive
        // Description : Retourne les informations pour les tournois toujours actifs.
        // Paramètres : TokenCheck  tokenCheck  Contient le jeton de connexion de
        //                                      l'utilisateur actif. Si le jeton est valide,
        //                                      les information sur les tournois actifs
        //                                      seront retournées.
        //
        //----------------------------------------------------------------------------------
        public GetAll? GetAllActive(TokenCheck tokenCheck)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new GetAll() { Validation = token });

            if (_roleContext == null || _roleContext.Tournaments == null) return null;

            List<Models.Database.Tournaments.Tournament> test = _roleContext.Tournaments.Where(e => e.IdTournament > 0).ToList();
            var allT = _roleContext.Tournaments.Where(e => e.IdTournament > 0).ToList();
            if (allT == null) return null;

            var r = new GetAll()
            {
                Tournaments = GetInfo(allT),
                Validation = token
            };
            return r;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Acun
        // Type de retour : Delete  La valeur de retour peut être NULL
        // Nom : TournamentDelete
        // Description : Cette fonction désactive un tournoi de la base de données. Les
        //               informations sont toujours présente, mais celle-ci ne peut être
        //               affiché dans l'application.
        // Paramètres : TournamentDelete    deleteType  Contient les informations du tournoi
        //                                              a désactiver.
        //
        //----------------------------------------------------------------------------------
        public Delete? TournamentDelete(TournamentDelete deleteType)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(deleteType.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(deleteType.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Delete() { Validation = token });

            if (_roleContext == null || _roleContext.Tournaments == null) return null;
            Models.Database.Tournaments.Tournament? tourType = new Models.Database.Tournaments.Tournament();
            if (deleteType.tournament.Name.Length > 1)
                tourType = _roleContext.Tournaments.Where(t => t.Name == deleteType.tournament.Name).FirstOrDefault();
            else if (deleteType.tournament.IdTournament > 0)
                tourType = _roleContext.Tournaments.Where(e => e.IdTournament == deleteType.tournament.IdTournament).FirstOrDefault();
            if (tourType == null) return new Delete() { Validation = token, Deleted = false };

            var result = _roleContext.Tournaments.Remove(tourType);
            Delete? delete = new Delete() { Validation = token, Deleted = true };
            return delete;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Add     La valeur de retour peut être NULL.
        // Nom : TournamentAdd
        // Description : Cette fonction, ajoute une nouvelle description de tournoi dans la
        //               base de données.
        // Paramètres : Definition  Tournament  Contient la définition du nouveau tournoi a
        //                                      ajouter dans la base de données.
        //
        //----------------------------------------------------------------------------------
        public Add? TournamentAdd(Definition Tournament)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(Tournament.Validation);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(Tournament.Validation);
            if (isValide == null || !isValide.IsValid) return (new Add() { Validation = token });

            if (_roleContext == null || _roleContext.Tournaments == null) return null;
            _roleContext.Tournaments.Add(new Models.Database.Tournaments.Tournament()
            {
                IdTournamentType = Tournament.Tournament.IdTournament,
                Name = Tournament.Tournament.Name,
                Picture = Tournament.Tournament.Picture
            });
            _roleContext.SaveChanges();

            Models.Database.Tournaments.Tournament? a = _roleContext.Tournaments.Where(e => e.Name == Tournament.Tournament.Name).FirstOrDefault();
            if(a == null || a.Picture == null) return null;

            Add add = new Add()
            {
                Validation = token,
                idTournament = a.IdTournament,
                idTournamentType = a.IdTournamentType,
                Picture = a.Picture,
                Name = a.Name
            };
            return add;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Add     La valeur retourné peut être NULL
        // Nom : TournamentModify
        // Description : Cette fonction modifie les information d'un tournoi.
        // Paramètres : TournamentModify    data    Cette structure contiens les infmations
        //                                          d'orgine ainsi que les nouvelles
        //                                          informations a modifier dans la base de
        //                                          données.
        //
        //----------------------------------------------------------------------------------
        public Add? TournamentModify(TournamentModify data)
        {
            TokenConnexion token = new ConnexionState(_roleContext, _configuration).GetConnexionState(data.tokenCheck);
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(data.tokenCheck);
            if (isValide == null || !isValide.IsValid) return (new Add() { Validation = token });

            if (_roleContext == null || _roleContext.Tournaments == null) return null;
            var rec = _roleContext.Tournaments.Where(e => e.Name == data.Origin.Name).FirstOrDefault();
            if (rec == null || rec.Picture == null) return null;

            if (rec != null)
            {
                rec.Name = data.NewName;
                _roleContext.Tournaments.Update(rec);
                _roleContext.SaveChanges();

                Add nouv = new Add()
                {
                    idTournament = rec.IdTournament,
                    idTournamentType = rec.IdTournamentType,
                    Name = data.NewName,
                    Picture = rec.Picture,
                    Validation = token
                };
                return nouv;
            }
            return null;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Private
        // Base d'enregistrement : Aucun
        // Type de retour : List<ReadTournament>    Liste des tournois demandés.
        // Nom : GetInfo
        // Description : Cette fonction, retourne les informations détaillé des tournois qui
        //               lui sont demandés. Elle reçois une liste somaire de tournois et
        //               retourne les informations détaillées.
        // Paramètres : List<Tournament>    tournament  Liste de tournois a retrouver
        //
        //----------------------------------------------------------------------------------
        private List<ReadTournament>? GetInfo(List<Models.Database.Tournaments.Tournament> tournaments)
        {
            if(tournaments == null) return null;
            if (_roleContext == null || _roleContext.TournamentTypes == null || _roleContext.Tournaments == null) return null;

            List<ReadTournament> infos = new List<ReadTournament>();
            foreach (var tournament in tournaments)
            {
                Models.Database.Tournaments.Tournament? rec = _roleContext.Tournaments.Where(e => e.IdTournament == tournament.IdTournament).FirstOrDefault();

                var tType = _roleContext.TournamentTypes.Where(e => e.IdTournamentType == tournament.IdTournament).FirstOrDefault();
                if (rec == null || tType == null) return null;

                ReadTournament nouv = new ReadTournament()
                {
                    IdTournament = tournament.IdTournament,
                    Name = tournament.Name,
                    tournamentType = tType,
                    Picture = tournament.Picture,
                    TournamentType = tType.Name
                };
                infos.Add(nouv);
            }
            return infos;
        }
    }
}
