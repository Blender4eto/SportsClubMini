using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportClubMini.Data.Entities;

namespace SportClubMini.Data
{
    public class SportClubDbContext : DbContext
    {
        public SportClubDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SportClub> SportClubs => Set<SportClub>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SportClub>(entity =>
            { 
                entity.Property(s => s.Name).IsRequired();
                entity.Property(s => s.Sport).IsRequired();
                entity.Property(s => s.City).IsRequired();
            });
        }
    }
}
