using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraderControl.Models;

namespace TraderControl.Data
{
    public class TraderDbContext : DbContext
    {
        public TraderDbContext (DbContextOptions<TraderDbContext> options)
            : base(options)
        {
        }

        public DbSet<TraderControl.Models.Trader> Trader { get; set; }
    }
}
