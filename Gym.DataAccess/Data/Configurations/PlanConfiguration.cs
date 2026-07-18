using Gym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Data.Configurations;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.Property(b => b.Name)
               .HasMaxLength(50);

        builder.Property(b => b.Description)
               .HasMaxLength(200);

        builder.Property(b => b.Price)
               .HasPrecision(18, 2);

        builder.ToTable(tb =>
        {
            tb.HasCheckConstraint(
                "CK_Plan_DurationDays",
                "DurationDays BETWEEN 1 AND 365");
        });

        builder.HasIndex(b => b.Name)
               .IsUnique();


        builder.HasQueryFilter(p => !p.IsDeleted);

    }
}