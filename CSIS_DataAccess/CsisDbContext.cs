using Microsoft.EntityFrameworkCore;

namespace CSIS_DataAccess
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