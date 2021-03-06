﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Impl.Migrations
{
    [DbContext(typeof(CsisDbContext))]
    internal class CSIS_DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Impl.CosmeticEntity", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("DeliveryTime")
                    .HasColumnType("int");

                b.Property<bool>("IsEnding")
                    .HasColumnType("bit");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Price")
                    .HasColumnType("int");

                b.Property<int>("ShelfLife")
                    .HasColumnType("int");

                b.Property<int>("Units")
                    .HasColumnType("int");

                b.Property<int>("UsingTime")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("CosmeticEntities");

                b.HasData(
                    new
                    {
                        Id = 1,
                        DeliveryTime = 13,
                        IsEnding = false,
                        Name = "1st",
                        Price = 567,
                        ShelfLife = 180,
                        Units = 987,
                        UsingTime = 100
                    },
                    new
                    {
                        Id = 2,
                        DeliveryTime = 3,
                        IsEnding = true,
                        Name = "2nd",
                        Price = 134,
                        ShelfLife = 360,
                        Units = 20,
                        UsingTime = 300
                    },
                    new
                    {
                        Id = 3,
                        DeliveryTime = 18,
                        IsEnding = false,
                        Name = "3rd",
                        Price = 111,
                        ShelfLife = 90,
                        Units = 70,
                        UsingTime = 80
                    });
            });
#pragma warning restore 612, 618
        }
    }
}