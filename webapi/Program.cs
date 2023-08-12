//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : Point d'entré, aucunne définition de nom.
// Description : Projet des gestion de tournois.
//               BackEnd développé en C# pour traiter les requêtes provenant de
//               l'application FrontEnd.
//               Un ensemble de contrôleur ont été développé pour répondre au besoin
//               du projet.
//               Le gestionnaire base de données sélectionné est Oracle MySql.
//               Le code du projet Backend est compilé avec Visual Studio 2022
//               Community. Vous pouvez utiliser n'importe quel envirionnement
//               Visuel Studio 2022 ou plus récent pour compiler ce projet. Il est
//               possible que vous deviez appliquer des modification mineur aux
//               codes pour que celui-ci puisse fonctionner sur votre environnemet.
//
//----------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using webapi.Context;

//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Définition de Class
// Nom : Program
// Héritage : Aucun
//
//----------------------------------------------------------------------------------
internal class Program
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Niveau d'accès : Privte
    // Base d'enregistrement : Static
    // Type de retour : Aucun
    // Nom : Main
    // Description : Fonction d'appel principale qui lance le service de gestion pour
    //               les appels d'API Web pour l'application de gestion de tournoi.
    // Paramètres : 
    //      String[]    Args    Listes tous les paramètres qui sont envoyés lors de
    //                          l'appel de la commande. Ce programme ne gère pas les
    //                          paramètres reçu.
    //
    //----------------------------------------------------------------------------------
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        string connectionString = string.Format("Server={0};User ID={1};Password={2};Database={3}",
            builder.Configuration.GetValue<string>("MySqlConnection:Server"),
            builder.Configuration.GetValue<string>("MySqlConnection:User"),
            builder.Configuration.GetValue<string>("MySqlConnection:Password"),
            builder.Configuration.GetValue<string>("MySqlConnection:Database"));

        builder.Services.AddDbContextPool<UserRoleContext>(x =>
            x.UseMySql(builder.Configuration.GetConnectionString(connectionString),
                       ServerVersion.AutoDetect(builder.Configuration.GetConnectionString(connectionString))));
        builder.Services.AddSingleton(x => new UserRoleContext(connectionString, builder.Configuration));

        //builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //app.UseSwagger();
            //app.UseSwaggerUI();
        }
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}