using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PatitoBank.DataAccess;
using System.Net.Sockets;

namespace PatitoBank.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

           services.AddDbContext<PatitoBankContext>(options => options.UseInMemoryDatabase("DataTest"));

            // services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }

        public IConfiguration Configuration { get; }
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
