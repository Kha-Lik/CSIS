using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Impl
{
    public sealed class CsisDbContext : DbContext
    {
        public CsisDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cosmetic> Cosmetics { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Consignment> Consignments { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
    }
}