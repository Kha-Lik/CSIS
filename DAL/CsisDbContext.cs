using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public sealed class CsisDbContext : DbContext
    {
        public CsisDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }

        public DbSet<CosmeticEntity> CosmeticEntities { get; set; }
        
    }
}