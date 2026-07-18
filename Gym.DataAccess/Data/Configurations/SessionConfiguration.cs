using Gym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions");


            builder.Property(x => x.Description)
                   .HasMaxLength(500)
                   .IsRequired();

     



            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Sessions_Capacity",
                    "[Capacity] BETWEEN 1 AND 25");

                t.HasCheckConstraint(
                    "CK_Sessions_Dates",
                    "[EndDate] > [StartDate]");
            });


            builder.HasQueryFilter(s => !s.IsDeleted);

        }
    }
}