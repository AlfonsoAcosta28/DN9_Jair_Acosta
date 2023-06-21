using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(options =>
{
    options.FileProviders.Add(new PhysicalFileProvider(AppContext.BaseDirectory));
});
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

app.MapControllerRoute(name: "default", pattern: "{controller=Members}/{action=Index}/{id?}");

app.MapControllerRoute(name: "default", pattern: "{controller=Modal}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "attendance",
        pattern: "attendance/{action=MemberIn}/{id?}",
        defaults: new { controller = "Attendance" });
});

app.Run();
