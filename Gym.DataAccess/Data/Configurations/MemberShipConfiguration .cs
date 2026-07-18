using Gym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configurations
{
    public class MemberShipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.ToTable("MemberShips");

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_MemberShips_Dates",
                    "[EndDate] > [StartDate]");
            });



            builder.HasIndex(x => new
            {

                x.MemberId,
                x.PlanId,
                x.StartDate,


            }).IsUnique();
        }
    }
}