using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Entities.ValueObject
{
    public class Address
    {
        public string City { get; set; } = null!;

        public string Street { get; set; } = null!; 

        public int BuildingNumber { get; set; }
    }
}
