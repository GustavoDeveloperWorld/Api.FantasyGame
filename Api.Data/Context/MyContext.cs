using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<TimeEntity> Times { get; set; }
        public DbSet<ChampionshipEntity> Championship { get; set; }
        public DbSet<MatchEntity> Match { get; set; }
        public DbSet<ChampionshipPointsEntity> ChampionshipPoints { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options){
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TimeEntity>(new TimeMap().Configure);

            modelBuilder.Entity<TimeEntity>().HasData(
                new TimeEntity { Id = Guid.NewGuid(), name = "Santos" },
                new TimeEntity { Id = Guid.NewGuid(), name = "Santos" },
                new TimeEntity { Id = Guid.NewGuid(), name = "Corinthias" }
            );
        }
    }
}
