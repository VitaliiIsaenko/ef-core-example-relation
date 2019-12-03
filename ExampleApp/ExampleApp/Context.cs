using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                @"Data Source=../../../addresses.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .ToTable("address_state");
            modelBuilder.Entity<Country>()
                .ToTable("address_country");
            
            modelBuilder.Entity<Country>().HasKey(c => new {c.Id, c.Locale});
            modelBuilder.Entity<State>().HasKey(s => new {s.Id, s.Locale});
            
            modelBuilder.Entity<State>()
                .HasMany(a => a.CountryLocales)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .HasPrincipalKey(x => x.CountryId);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}