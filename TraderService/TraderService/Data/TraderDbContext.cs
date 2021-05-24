using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraderService.Models;

    public class TraderDbContext : DbContext
    {
        public TraderDbContext (DbContextOptions<TraderDbContext> options)
            : base(options)
        {
        }

        public DbSet<TraderService.Models.TraderModel> TraderModel { get; set; }
    }
