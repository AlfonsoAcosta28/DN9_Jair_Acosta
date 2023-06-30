using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//----------------------
string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<VehiclesDataContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddTransient<IQueriesExample, QueriesExample>();

builder.Services.AddTransient<IColorsDataManager, ColorsDataManager>();
builder.Services.AddTransient<IVehiclesDataManager, VehiclesDataManager>();

builder.Services.Configure<ApiBehaviorOptions>(op =>
{
    op.SuppressModelStateInvalidFilter = true;
});

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
