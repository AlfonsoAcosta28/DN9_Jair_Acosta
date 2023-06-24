using GymManager.ApplicationServices.Members;
using GymManager.ApplicationServices.Navegation;
using GymManager.DataAcces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(options =>
{
    options.FileProviders.Add(new PhysicalFileProvider(AppContext.BaseDirectory));
    
});

builder.Services.AddTransient<IMembersAppService, MemberAppService>();

builder.Services.AddTransient<IMenuAppService, MenuAppService>();

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<GymManagerContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GymManagerContext>();

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

app.MapControllerRoute(name: "default", pattern: "{controller=Modal}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Members}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "attendance",
        pattern: "attendance/{action=MemberIn}/{id?}",
        defaults: new { controller = "Attendance" });
});

app.Run();
