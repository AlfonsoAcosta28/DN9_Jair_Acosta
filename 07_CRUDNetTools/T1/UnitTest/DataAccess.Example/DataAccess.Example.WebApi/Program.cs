using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//----------------------
string connectionString = builder.Configuration.GetConnectionString("Default");

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

//var connectionString = $"Data Source={dbHost};Initial Catalog={dbName}; User ID=sa;Password{dbPassword}";

builder.Services.AddDbContext<VehiclesDataContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddTransient<IQueriesExample, QueriesExample>();

builder.Services.AddTransient<IColorsDataManager, ColorsDataManager>();
builder.Services.AddTransient<IVehiclesDataManager, VehiclesDataManager>();

builder.Services.Configure<ApiBehaviorOptions>(op =>
{
    op.SuppressModelStateInvalidFilter = true;
});
//Modificar el puerto de salida para evitar conflictos con docker
/*builder.Host.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseUrls("http://*:5024");
});
*/
//------------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
