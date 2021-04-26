using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareOwnerAsAService.Models;

namespace ShareOwnerAsAService.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext (DbContextOptions<StockDbContext> options)
            : base(options)
        {
        }

        public DbSet<StockOwner> StockOwner { get; set; }

        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Owner)
                .WithMany(o => o.StockPortfolio);        
        }
    }
}
