using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BusinessLogic.ViewModel.Members
{
    public class MemberIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string? PhotoUrl {  get; set; }

        public string Phone { get; set; }
        public string? Photo {  get; set; }
        public DateOnly JoinDate { get; set; }

        public string Gender { get; set; } = null!;




    }
}
