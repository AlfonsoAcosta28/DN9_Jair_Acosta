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

var builder = WebApplication.CreateBuilder(args);


var cultureInfo = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

/*Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt")
    .CreateLogger();

*/

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();


builder.Services.AddTransient<IMembersAppService, MemberAppService>();
builder.Services.AddTransient<IMembershipTypesAppService, MembershipTypesAppService>();
builder.Services.AddTransient<IMenuAppService, MenuAppService>();
builder.Services.AddTransient<IRepository<int, Member>, MembersReporitory>();
builder.Services.AddWkhtmltopdf();

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<GymManagerContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GymManagerContext>()
    .AddUserStore<UserStore<IdentityUser,IdentityRole, GymManagerContext>>();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{

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
