using Microsoft.EntityFrameworkCore;

namespace CSIS_DataAccess
{
    public sealed class CsisDbContext : DbContext
    {
        public CsisDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }


        public CsisDbContext()
        {
        }

        public DbSet<CosmeticEntity> CosmeticEntities { get; set; }

        public DbSet<CosmeticUsedSlowlyEnity> CosmeticUsedSlowlyEnities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CSIS_DB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}