using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BusinessLogic.ViewModel.Members
{
    public class MemberDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? PhotoUrl { get; set; } 


        public string Email { get; set; } = null!;


        public string? PhoneNumber { get; set; } = null!;

        public string Gender { get; set; } = null!;


        public string DateOfBirth { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PlanName { get; set; } = null!;

        public string MembershipStartDate { get; set; } = null!;

        public string MembershipEndDate { get; set;} = null!;






    }
}
