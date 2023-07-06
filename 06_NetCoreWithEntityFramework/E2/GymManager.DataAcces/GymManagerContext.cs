using GymManager.Core.Entities;
using GymManager.Core.Members;
using GymManager.Core.MembershipTypes;
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
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<EquipmentType> EquipmentType { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Measuretype> Measurements { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<Inventory>Inventories { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleLine> SaleLines { get; set; }

        public GymManagerContext(DbContextOptions<GymManagerContext> options): base(options) { }
    }
}
