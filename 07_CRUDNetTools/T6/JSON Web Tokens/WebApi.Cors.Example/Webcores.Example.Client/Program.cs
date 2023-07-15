using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using Webcores.Example.Client.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Webcores.Example.Client.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Webcores.Example.Client.Utils.Config;
using Microsoft.Data.SqlClient;
using WebApi.Shared.Config;
using Webcores.Example.Client.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Webcores.Example.Client.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddViewLocalization().AddDataAnnotationsLocalization(op =>
{
    op.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(CommonResources).GetTypeInfo().Assembly.FullName);
        return factory.Create(nameof(CommonResources), assemblyName.Name);
    };
 });

builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("UserOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
    });
});

var authorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.Configure<CookiePolicyOptions>(op =>
{
    op.CheckConsentNeeded = context => true; 
    op.MinimumSameSitePolicy = SameSiteMode.None;
});


builder.Services.Configure<JwtTokenValidationSettings>(builder.Configuration.GetSection(nameof(JwtTokenValidationSettings)));
builder.Services.AddSingleton<IJwtTokenValidationSettings, JwtTokenValidationSettingsFactory>();

builder.Services.Configure<JwtTokenIssuerSettings>(builder.Configuration.GetSection(nameof(JwtTokenIssuerSettings)));
builder.Services.AddSingleton<IJwtTokenIssuerSettings, JwtTokenIssuerSettingsFactory>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IClaimPrincipalManager, ClaimPrincipalManager>();

builder.Services.Configure<AuthenticationSettings>(builder.Configuration.GetSection(nameof(AuthenticationSettings)));
builder.Services.AddSingleton<IAuthenticationSettings, AuthenticationSettingsFactory>();

var serviceProvider = builder.Services.BuildServiceProvider();

var authenticationSettings = serviceProvider.GetService<IAuthenticationSettings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(JwtBearerDefaults.AuthenticationScheme, op => 
    {
        op.LoginPath = authenticationSettings.LoginPath;
        op.AccessDeniedPath = authenticationSettings.AccessDeniedPath;
        op.Events = new CookieAuthenticationEvents
        {
            OnValidatePrincipal = RefreshTokenMonitor.ValidateAsync
        };
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient("WebApi", (client) =>
{
    client.BaseAddress = new Uri(builder.Configuration["JwtTokenIssuerSettings:BaseAddress"]);
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
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.Run();
