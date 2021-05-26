﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TobinTaxService.Migrations
{
    [DbContext(typeof(TobinTaxDbContext))]
    [Migration("20210526154545_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("TobinTaxService.Models.TobinTaxModel", b =>
                {
                    b.Property<Guid>("TaxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BoughtStock")
                        .HasColumnType("TEXT");

                    b.Property<double>("PayedTax")
                        .HasColumnType("REAL");

                    b.Property<Guid>("TraderId")
                        .HasColumnType("TEXT");

                    b.HasKey("TaxId");

                    b.ToTable("TobinTaxModel");
                });
#pragma warning restore 612, 618
        }
    }
}