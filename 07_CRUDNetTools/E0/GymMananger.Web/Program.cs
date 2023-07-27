using GymManager.ApplicationServices.Members;
using GymManager.ApplicationServices.MembershipTypes;
using GymManager.ApplicationServices.Navegation;
using GymManager.DataAcces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Globalization;
using Serilog;
using Serilog.Events;
using GymManager.DataAcces.Repositories;
using GymManager.Core.Members;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Wkhtmltopdf.NetCore;
using GymManager.Core.MembershipTypes;
using GymManager.Core.Entities;
using GymManager.ApplicationServices.Entities;
using GymManager.ApplicationServices.Entities.Equipment;
using GymManager.ApplicationServices.Attendace;
using GymManager.ApplicationServices;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Reflection;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();
Log.Information("Starting up!");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddViewLocalization();
//var cultureInfo = new CultureInfo("es-MX");
//CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
//CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.Configure<RequestLocalizationOptions>(op =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("es-MX"),
    };

    op.DefaultRequestCulture = new RequestCulture("es-MX");
    op.SupportedCultures = supportedCultures;
    op.SupportedUICultures = supportedCultures;
});
builder.Services.AddLocalization(op => op.ResourcesPath = "Resources");

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddTransient<IMemberAppService, MemberAppService>();
builder.Services.AddTransient<IMembershipTypesAppService, MembershipTypesAppService>();
builder.Services.AddTransient<IMenuAppService, MenuAppService>();
builder.Services.AddTransient<IEquipmentAppService, EquipmentAppService>();
builder.Services.AddTransient<IAttendaceAppService, AttendaceAppService>();

builder.Services.AddTransient<IRepository<int, Attendance>, AttendaceRepository>();
builder.Services.AddTransient<IRepository<int, Member>, MembersReporitory>();
builder.Services.AddTransient<IRepository<int, MembershipType>, MembershipTypesRepository>();
builder.Services.AddTransient<IRepository<int, EquipmentType>, EquipmentTypeRepository>();
builder.Services.AddWkhtmltopdf();

//string connectionString = builder.Configuration.GetConnectionString("Default");

var dbHost = "localhost";
var dbName = "gymmanager";
var dbPassword = "1234";

var connectionString = $"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword}";

builder.Services.AddDbContext<GymManagerContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//builder.Services.AddDbContext<GymManagerContext>(options => options.UseMySqlServer(connectionString));

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GymManagerContext>()
    .AddUserStore<UserStore<IdentityUser,IdentityRole, GymManagerContext>>();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var localizationOptions = services.GetService<IOptions<RequestLocalizationOptions>>().Value;
    app.UseRequestLocalization(localizationOptions);
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseHsts();
}
else {
    app.UseExceptionHandler("/error");
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{

    //endpoints.MapControllerRoute(
      // name: "query",
       //pattern: "{controller=Query}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "modal",
        pattern: "{controller=Modal}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "members",
        pattern: "{controller=Members}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "attendance",
        pattern: "attendance/{action=MemberIn}/{id?}",
        defaults: new { controller = "Attendance" });

    endpoints.MapControllerRoute(
        name: "membershipTypes",
        pattern: "{controller=MembershipTypes}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "Invoicing",
        pattern: "{controller=Invoicing}/{action=GenereteInvoice}/{id?}");

    endpoints.MapControllerRoute(
        name: "Reports",
        pattern: "{controller=Reports}/{action=NewMembers}/{id?}");

  });


app.Run();
