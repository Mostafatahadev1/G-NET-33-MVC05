using Gym.DataAccess.Entities;
using Gym.Presentation.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Repositries
{
    public class PlanRepository(GymDbContext dbContext) : Repository <Plan>(dbContext),IPlanRepository
    {
       
        // All common methods 



    }
}
