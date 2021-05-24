using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareControl.Models;

namespace ShareControl.Data
{
    public class ShareDbContext : DbContext
    {
        public ShareDbContext (DbContextOptions<ShareDbContext> options)
            : base(options)
        {
        }

        public DbSet<Share> Share { get; set; }
    }
}
