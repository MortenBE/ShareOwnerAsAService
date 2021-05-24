using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RequesterService.Models;

    public class RequesterDbContext : DbContext
    {
        public RequesterDbContext (DbContextOptions<RequesterDbContext> options)
            : base(options)
        {
        }

        public DbSet<RequesterService.Models.RequesterModel> RequesterModel { get; set; }
    }
