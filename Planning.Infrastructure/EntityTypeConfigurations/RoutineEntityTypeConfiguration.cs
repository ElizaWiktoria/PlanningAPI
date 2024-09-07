using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planning.Domain.Models;

namespace Planning.Infrastructure.AutoMappers.EntityTypeConfigurations
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
