using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using Webcores.Example.Client.Resources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddViewLocalization().AddDataAnnotationsLocalization(op =>
{
    op.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(CommonResources).GetTypeInfo().Assembly.FullName);
        return factory.Create(nameof(CommonResources), assemblyName.Name);
    };
 });

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
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var localizationOptions = services.GetService<IOptions<RequestLocalizationOptions>>().Value;
    app.UseRequestLocalization(localizationOptions);
}

app.UseAuthorization();

app.MapRazorPages();

app.Run();
