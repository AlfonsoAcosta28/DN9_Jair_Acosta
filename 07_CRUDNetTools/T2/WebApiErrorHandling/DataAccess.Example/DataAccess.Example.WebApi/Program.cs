using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

try
{
    Log.Information("Starting up");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Host.UseSerilog();

    //----------------------
    string connectionString = builder.Configuration.GetConnectionString("Default");

    var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
    var dbName = Environment.GetEnvironmentVariable("DB_NAME");
    var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");


    builder.Services.AddDbContext<VehiclesDataContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

    builder.Services.AddTransient<IQueriesExample, QueriesExample>();

    builder.Services.AddTransient<IColorsDataManager, ColorsDataManager>();
    builder.Services.AddTransient<IVehiclesDataManager, VehiclesDataManager>();

    builder.Services.Configure<ApiBehaviorOptions>(op =>
    {
        op.SuppressModelStateInvalidFilter = true;
    });

    builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());
    //------------------------
    Log.Information("Stopped cleanly");


    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseExceptionHandler("/error");
    }
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhanldled exeption occured during bootstrapping");
}
finally
{
    Log.CloseAndFlush();
}
