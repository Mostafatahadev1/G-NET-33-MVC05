using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }


        public DateTime? UpdatedAt {get; set; }

        public DateTime? DeletedAt {  get; set; }

        public bool IsDeleted { get; set; }


    }
}
