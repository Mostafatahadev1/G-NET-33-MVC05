using Gym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Data.Configurations
{
    public class TrainerConfiguration : UserConfiguration<Trainer>
    {
        public override void Configure(EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);

            // Configuration related TO "Trainers "


            builder.Property(p => p.Speciality)
                .HasConversion<string>()
                .HasMaxLength(30);
          
        }
    }
}
