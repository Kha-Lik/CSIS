﻿using Microsoft.EntityFrameworkCore;

namespace CSIS_DataAccess
{
    public class CSIS_DBContext : DbContext
    {
        public CSIS_DBContext(DbContextOptions<CSIS_DBContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }


        public CSIS_DBContext()
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