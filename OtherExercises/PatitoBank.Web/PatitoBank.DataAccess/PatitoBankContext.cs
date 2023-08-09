using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatitoBank.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitoBank.DataAccess
{
    public class PatitoBankContext : DbContext
    {
        public PatitoBankContext(DbContextOptions<PatitoBankContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
       // public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Retiro> Retiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Cuenta>()
                .HasMany(c => c.Retiros)
                .WithOne()
                .HasForeignKey(t => t.Id);

            modelBuilder.Entity<Cuenta>()
                .HasMany(c => c.Depositos)
                .WithOne()
                .HasForeignKey(t => t.Id);
        }

    }
}
