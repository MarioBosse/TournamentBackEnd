using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
String connectionString = String.Format("Server={0};User ID={1};Password={2};Database={3}", 
    builder.Configuration.GetValue<String>("MySqlConnection:Server"),
    builder.Configuration.GetValue<String>("MySqlConnection:User"),
    builder.Configuration.GetValue<String>("MySqlConnection:Password"),
    builder.Configuration.GetValue<String>("MySqlConnection:Database"));

builder.Services.AddTransient<MySqlConnection>(_ => 
    new MySqlConnection(connectionString));

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
