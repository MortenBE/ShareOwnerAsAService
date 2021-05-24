using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TobinTaxService.Models;

    public class TobinTaxDbContext : DbContext
    {
        public TobinTaxDbContext (DbContextOptions<TobinTaxDbContext> options)
            : base(options)
        {
        }

        public DbSet<TobinTaxService.Models.TobinTaxModel> TobinTaxModel { get; set; }
    }
