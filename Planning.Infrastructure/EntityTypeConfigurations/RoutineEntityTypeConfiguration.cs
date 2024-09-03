using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlanningAPI.Models;

namespace PlanningAPI.EntityTypeConfigurations
{
    public class RoutineEntityTypeConfiguration : IEntityTypeConfiguration<Routine>
    {
        public void Configure(EntityTypeBuilder<Routine> modelBuilder)
        {
            modelBuilder
                .ToTable("Routines", "dbo")
                .HasKey(x => x.Id);

            modelBuilder
                .HasMany(c => c.Plans)
                .WithOne(e => e.Routine)
                .HasForeignKey("RoutineId");
        }
    }
}
