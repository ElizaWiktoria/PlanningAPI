using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planning.Domain.Models;

namespace Planning.Infrastructure.AutoMappers.EntityTypeConfigurations
{
    public class PlanEntityTypeConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> modelBuilder)
        {
            modelBuilder
                .ToTable("Plans", "dbo")
                .HasKey(x => x.Id);
        }
    }
}
