using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareService.Models;

    public class ShareDbContext : DbContext
    {
        public ShareDbContext (DbContextOptions<ShareDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShareService.Models.ShareServiceModel> ShareServiceModel { get; set; }
    }
