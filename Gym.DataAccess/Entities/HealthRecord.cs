using Gym.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Entities
{
    public class HealthRecord : BaseEntity
    {
        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public BloodType BloodType { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; } = null!;

        public string? Notes { get; set; }


    }
}
