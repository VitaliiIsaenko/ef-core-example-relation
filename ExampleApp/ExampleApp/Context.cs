using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                @"Data Source=addresses.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressDto>()
                .ToTable("address");

            modelBuilder.Entity<CountryLocaleDto>()
                .ToTable("address_country");

            modelBuilder.Entity<CountryLocaleDto>()
                .HasKey(cl => new {cl.Id, cl.Locale});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AddressDto> Addresses { get; set; }
    }
}