using System;
using Cooperativa.Investimentos.Poupancas;
using Cooperativa.Investimentos.Usuarios;
using Infraestructure.Core.Data;
using Infraestructure.Core.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Cooperativa.Investimentos.Storer
{
    public class InvestimentoDbContext : DbContext, ISessionContext
    {
        public DbSet<Poupanca> Poupancas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityBase>().HasKey(c => c.Id);
            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}