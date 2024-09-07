using Microsoft.EntityFrameworkCore;
using Planning.Domain.Models;
using Planning.Infrastructure.AutoMappers.EntityTypeConfigurations;

namespace Planning.Infrastructure.AutoMappers.DataContext
{
    public sealed class DataContextEF : DbContext
    {
        public DataContextEF(DbContextOptions<DataContextEF> config) : base(config)
        {
        }

        public DbSet<Routine> Routines { get; set; }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            new PlanEntityTypeConfiguration().Configure(modelBuilder.Entity<Plan>());
            new RoutineEntityTypeConfiguration().Configure(modelBuilder.Entity<Routine>());
        }
    }
}
