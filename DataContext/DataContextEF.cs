using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using PlanningAPI.Models;
using System.Numerics;

namespace PlanningAPI.DataContext
{
    public sealed class DataContextEF : DbContext
    {
        public DataContextEF(DbContextOptions<DataContextEF> config) : base(config)
        {
        }

        public DbSet<Routine> Routines { get; set; }
        public DbSet<Plan> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");


            modelBuilder.Entity<Routine>()
                .ToTable("Routines", "dbo")
                .HasKey(x => x.Id);


            modelBuilder.Entity<Plan>()
                .ToTable("Plans", "dbo")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Routine>()
                .HasMany(c => c.Plans)
                .WithOne(e => e.Routine)
                .HasForeignKey("RoutineId");
        }
    }
}
