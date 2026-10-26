using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsClubMini.Data.Entities;

namespace SportsClubMini.Data
{
    public class SportsClubDbContext : DbContext
    {
        public SportsClubDbContext(DbContextOptions<SportsClubDbContext> options) : base(options)
        {
        }

        public DbSet<SportClub> SportClubs => Set<SportClub>();
        public DbSet<Sport> Sports => Set<Sport>();
        public DbSet<Trainer> Trainers => Set<Trainer>();
        public DbSet<Training> Trainings => Set<Training>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SportClub>()
                .HasMany(club => club.Sports)
                .WithMany()
                .UsingEntity(join => join.ToTable("SportClubSports"));

            modelBuilder.Entity<Trainer>()
                .HasOne(trainer => trainer.Club)
                .WithMany()
                .HasForeignKey(trainer => trainer.ClubId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trainer>()
                .HasOne(trainer => trainer.Sport)
                .WithMany()
                .HasForeignKey(trainer => trainer.SportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasOne(training => training.Trainer)
                    .WithMany()
                    .HasForeignKey(training => training.TrainerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
