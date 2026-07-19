using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BusinessLogic.ViewModel.HealthRecords
{
    public class HealthRecordDetailsViewModel
    {
        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string BloodType { get; set; } = default!;
        public string? Note { get; set; } = default!;
    }
}
