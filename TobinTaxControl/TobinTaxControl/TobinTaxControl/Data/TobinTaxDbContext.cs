using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TobinTaxControl.Models;

namespace TobinTaxControl.Data
{
    public class TobinTaxDbContext : DbContext
    {
        public TobinTaxDbContext (DbContextOptions<TobinTaxDbContext> options)
            : base(options)
        {
        }

        public DbSet<TobinTaxControl.Models.Tax> Tax { get; set; }
    }
}
