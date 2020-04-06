using Microsoft.EntityFrameworkCore;

namespace CSIS_DataAccess
{
    public sealed class CsisDbContext : DbContext
    {
        public CsisDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        public CsisDbContext()
        {
        }

        public DbSet<CosmeticEntity> CosmeticEntities { get; set; }

        //public DbSet<CosmeticUsedSlowlyEnity> CosmeticUsedSlowlyEnities { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=localhost;Database=CsisDb;Trusted_Connection=True;");
        //     base.OnConfiguring(optionsBuilder);
        // }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cosm1 = new CosmeticEntity() 
            {
                Id = 1, 
                DeliveryTime = 13, 
                Name = "1st", 
                Price = 567, 
                Units = 987, 
                IsEnding = false, 
                ShelfLife = 180, 
                UsingTime = 100
            };
            var cosm2 = new CosmeticEntity()
            {
                Id = 2, 
                DeliveryTime = 3, 
                Name = "2nd", 
                Price = 134, 
                Units = 20,
                IsEnding = true, 
                ShelfLife = 360, 
                UsingTime = 300
            };
            var cosm3 = new CosmeticEntity()
            {
                Id = 3, 
                DeliveryTime = 18, 
                Name = "3rd", 
                Price = 111, 
                Units = 70, 
                IsEnding = false, 
                ShelfLife = 90, 
                UsingTime = 80
            };

            modelBuilder.Entity<CosmeticEntity>().HasData(cosm1, cosm2, cosm3);
            
            /*var cosm4 = new CosmeticUsedSlowlyEnity(){Id = 1, Name = "4th", Price = 456, Units = 123, DeliveryTime = 56, IsEnding = true, ShelfLife = 180, UsingTime = 100};

            modelBuilder.Entity<CosmeticUsedSlowlyEnity>().HasData(cosm4);*/
        }
    }
}