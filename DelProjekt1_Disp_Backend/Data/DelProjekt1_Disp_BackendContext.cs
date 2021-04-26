using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DelProjekt1_Disp_Backend.Models;

namespace DelProjekt1_Disp_Backend.Data
{
    public class DelProjekt1_Disp_BackendContext : DbContext
    {
        public DelProjekt1_Disp_BackendContext (DbContextOptions<DelProjekt1_Disp_BackendContext> options)
            : base(options)
        {
        }

        public DbSet<DelProjekt1_Disp_Backend.Models.Haandvaerker> Haandvaerker { get; set; }

        public DbSet<DelProjekt1_Disp_Backend.Models.Vaerktoej> Vaerktoej { get; set; }

        public DbSet<DelProjekt1_Disp_Backend.Models.Vaerktoejskasse> Vaerktoejskasse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaerktoej>()
                .HasOne(p => p.LiggerIvtkNavigation)
                .WithMany(b => b.Vaerktoej);

            modelBuilder.Entity<Haandvaerker>()
                .HasMany(p => p.Vaerktoejskasse)
                .WithOne(p => p.EjesAfNavigation);
               

          


        }
    }
}
