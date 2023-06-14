using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

using webapi.Context;

internal class Program
{
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
        builder.Services.AddSingleton(x => new UserRoleContext(connectionString));
        builder.Services.AddSingleton(x => new MySqlDataConnector(builder.Configuration));

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