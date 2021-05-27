﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TraderService.Migrations
{
    [DbContext(typeof(TraderDbContext))]
    [Migration("20210527130005_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TraderService.Models.TraderModel", b =>
                {
                    b.Property<Guid>("TraderId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(86)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TraderId");

                    b.ToTable("TraderModel");
                });
#pragma warning restore 612, 618
        }
    }
}
