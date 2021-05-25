﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RequesterService.Migrations
{
    [DbContext(typeof(RequesterDbContext))]
    partial class RequesterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("RequesterService.Models.RequesterModel", b =>
                {
                    b.Property<Guid>("RequesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Share")
                        .HasColumnType("TEXT");

                    b.HasKey("RequesterId");

                    b.ToTable("RequesterModel");
                });
#pragma warning restore 612, 618
        }
    }
}
