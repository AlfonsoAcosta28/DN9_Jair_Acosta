using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Cors.Example.Data
{
    public class JwtDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public JwtDbContext(DbContextOptions<JwtDbContext> options) : base(options)
        {

        }
    }
}
