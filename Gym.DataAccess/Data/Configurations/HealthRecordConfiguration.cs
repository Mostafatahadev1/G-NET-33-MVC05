using Gym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configurations
{
    public class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.ToTable("HealthRecords");


            builder.Property(x => x.Height)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.Weight)
                .HasPrecision(5, 2)
                .IsRequired();


            builder.Property(x => x.BloodType)
                .HasConversion<string>()
                .HasMaxLength(200)
                .IsRequired();

            builder.ToTable("HealthRecords", t =>
            {
                t.HasCheckConstraint("CK_HealthRecords_Height", "[Height] > 0");
                t.HasCheckConstraint("CK_HealthRecords_Weight", "[Weight] > 0");
            });

            builder.HasQueryFilter(h => !h.IsDeleted);

        }
    }
}