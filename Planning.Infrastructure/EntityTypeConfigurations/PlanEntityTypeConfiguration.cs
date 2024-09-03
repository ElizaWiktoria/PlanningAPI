using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningAPI.Models;

namespace PlanningAPI.EntityTypeConfigurations
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
