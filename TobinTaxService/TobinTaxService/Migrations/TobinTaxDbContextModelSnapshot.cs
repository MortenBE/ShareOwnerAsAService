// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TobinTaxService.Migrations
{
    [DbContext(typeof(TobinTaxDbContext))]
    partial class TobinTaxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TobinTaxService.Models.TobinTaxModel", b =>
                {
                    b.Property<Guid>("TaxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BoughtStock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PayedTax")
                        .HasColumnType("float");

                    b.Property<Guid>("TraderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TaxId");

                    b.ToTable("TobinTaxModel");
                });
#pragma warning restore 612, 618
        }
    }
}
