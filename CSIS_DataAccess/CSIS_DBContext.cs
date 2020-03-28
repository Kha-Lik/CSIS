using Microsoft.EntityFrameworkCore;
namespace CSIS_DataAccess
{
    public class CSIS_DBContext : DbContext
    {
        public DbSet<CosmeticEntity> CosmeticEntities { get; set; }

        public DbSet<CosmeticUsedSlowlyEnity> CosmeticUsedSlowlyEnities { get; set; }

        public CSIS_DBContext(DbContextOptions<CSIS_DBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public CSIS_DBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost;Database=CSIS_DB;Trusted_Connection=True;");
        }
    }
}