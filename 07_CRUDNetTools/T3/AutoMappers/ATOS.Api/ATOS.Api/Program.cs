
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Globalization;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ATOS.ApplicationServices.UserServices;
using ATOS.DataAccess.Repositotories;
using ATOS.DataAccess;
using ATOS.ApplicationServices.ProfileServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserAppService, UserAppService>();
builder.Services.AddTransient<IProfilesAppService, ProfilesAppService>();

builder.Services.AddTransient<IRepository<int, ATOS.Core.Accounts.User>, UserReporitory>();
builder.Services.AddTransient<IRepository<int, ATOS.Core.Accounts.Profile>, ProfileRepository>();

builder.Services.AddAutoMapper(typeof(ATOS.ApplicationServices.MapperProfile));

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<Context>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
/*
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>()
    .AddUserStore<UserStore<IdentityUser, IdentityRole, Context>>();
*/

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
