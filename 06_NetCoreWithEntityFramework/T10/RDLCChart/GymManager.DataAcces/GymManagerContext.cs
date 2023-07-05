using GymManager.Core.Members;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAcces
{
    public class GymManagerContext : IdentityDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<City> Cities { get; set; }
        public GymManagerContext(DbContextOptions<GymManagerContext> options): base(options) { }
    }
}
