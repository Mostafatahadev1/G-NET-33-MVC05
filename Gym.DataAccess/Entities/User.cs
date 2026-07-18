using Gym.DataAccess.Entities.ValueObject;
using Gym.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public Gender Gender { get; set; } // 0,1

        public Address Address { get; set; } = null!;

        public string? Photo { get; set; }

    }
}
