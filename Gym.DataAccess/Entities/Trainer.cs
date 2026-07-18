using Gym.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Entities
{
    public class Trainer : User
    {
        public  Speciality Speciality { get; set; }

        public DateTime HireDate { get; set; }


        // ICollection <Sessions>

        public ICollection<Session> Sessions { get; set; } = [];



    }
}
