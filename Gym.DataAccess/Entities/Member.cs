using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Entities
{
    public class Member : User
    {
        public DateTime JoinDate { get; set; }


        public string? Photo { get; set; }


        // Health Record 

        public HealthRecord HealthRecord { get; set; } = null!;


        public ICollection<Booking> Bookings { get; set; }
                     = new HashSet<Booking>();

        public ICollection<MemberShip> MemberShips { get; set; }
            = new HashSet<MemberShip>();
        public string PhoneUrl { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }


}
