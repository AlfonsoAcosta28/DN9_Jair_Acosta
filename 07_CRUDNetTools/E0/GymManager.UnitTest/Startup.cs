using GymManager.ApplicationServices.Attendace;
using GymManager.ApplicationServices.Entities.Equipment;
using GymManager.ApplicationServices.Entities;
using GymManager.ApplicationServices.Members;
using GymManager.ApplicationServices.MembershipTypes;
using GymManager.ApplicationServices.Navegation;
using GymManager.Core.Entities;
using GymManager.Core.Members;
using GymManager.Core.MembershipTypes;
using GymManager.DataAcces.Repositories;
using GymManager.DataAcces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManager.ApplicationServices;

namespace GymManager.UnitTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { 
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<IMemberAppService, MemberAppService>();
            services.AddTransient<IMembershipTypesAppService, MembershipTypesAppService>();
            services.AddTransient<IMenuAppService, MenuAppService>();
            services.AddTransient<IEquipmentAppService, EquipmentAppService>();
            services.AddTransient<IAttendaceAppService, AttendaceAppService>();

            services.AddTransient<IRepository<int, Attendance>, AttendaceRepository>();
            services.AddTransient<IRepository<int, Member>, MembersReporitory>();
            services.AddTransient<IRepository<int, MembershipType>, MembershipTypesRepository>();
            services.AddTransient<IRepository<int, EquipmentType>, EquipmentTypeRepository>();


            services.AddDbContext<GymManagerContext>(options => options.UseInMemoryDatabase("DataTest"));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
