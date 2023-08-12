//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Boss� (GiMB)
// @2023 Tout droit r�serv�. Reproducion interdite
//
// Concepteur : Mario Boss�
// 16 Juillet 2023
//
// Nom : Point d'entr�, aucunne d�finition de nom.
// Description : Projet des gestion de tournois.
//               BackEnd d�velopp� en C# pour traiter les requ�tes provenant de
//               l'application FrontEnd.
//               Un ensemble de contr�leur ont �t� d�velopp� pour r�pondre au besoin
//               du projet.
//               Le gestionnaire base de donn�es s�lectionn� est Oracle MySql.
//               Le code du projet Backend est compil� avec Visual Studio 2022
//               Community. Vous pouvez utiliser n'importe quel envirionnement
//               Visuel Studio 2022 ou plus r�cent pour compiler ce projet. Il est
//               possible que vous deviez appliquer des modification mineur aux
//               codes pour que celui-ci puisse fonctionner sur votre environnemet.
//
//----------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using webapi.Context;

//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Boss� (GiMB)
// @2023 Tout droit r�serv�. Reproducion interdite
//
// Concepteur : Mario Boss�
// 16 Juillet 2023
//
// D�finition de Class
// Nom : Program
// H�ritage : Aucun
//
//----------------------------------------------------------------------------------
internal class Program
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Boss�
    // 16 Juillet 2023
    //
    // Niveau d'acc�s : Privte
    // Base d'enregistrement : Static
    // Type de retour : Aucun
    // Nom : Main
    // Description : Fonction d'appel principale qui lance le service de gestion pour
    //               les appels d'API Web pour l'application de gestion de tournoi.
    // Param�tres : 
    //      String[]    Args    Listes tous les param�tres qui sont envoy�s lors de
    //                          l'appel de la commande. Ce programme ne g�re pas les
    //                          param�tres re�u.
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