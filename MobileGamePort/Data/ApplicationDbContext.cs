using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobileGamePort.Models;

namespace MobileGamePort.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Recharge> Recharges { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ScratchCard> ScratchCards { get; set; }
        public DbSet<GiftCode> GiftCode { get; set; }
        public DbSet<GiftCodeUse> GiftCodeUse { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var table = entityType.Relational().TableName;
                if (table.StartsWith("AspNet"))
                {
                    entityType.Relational().TableName = table.Substring(6);
                }
            }

            modelBuilder.Entity<News>()
            .HasOne(p => p.Author);

            modelBuilder.Entity<ScratchCard>()
            .HasOne(p => p.User);

            modelBuilder.Entity<Recharge>()
            .HasOne(p => p.User);

            modelBuilder.Entity<GiftCodeUse>()
                .HasKey(c => new { c.GiftCodeId, c.UserId });
        }
        
    }
}
