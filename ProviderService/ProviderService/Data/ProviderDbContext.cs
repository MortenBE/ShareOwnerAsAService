using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProviderService.Models;

    public class ProviderDbContext : DbContext
    {
        public ProviderDbContext (DbContextOptions<ProviderDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProviderService.Models.ProviderModel> ProviderModel { get; set; }
    }
