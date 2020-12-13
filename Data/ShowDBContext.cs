using TVLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVLibraryAPI.Data
{
    public class ShowDBContext : DbContext
    {
        public ShowDBContext(DbContextOptions<ShowDBContext> options)
            :base(options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Show> Shows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedPlatformDB();
            modelBuilder.SeedShowDB();
        }
    }
}
