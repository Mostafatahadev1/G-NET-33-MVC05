using Gym.BusinessLogic.ViewModel.Members;
using Gym.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.BusinessLogic.ViewModel.Members;

namespace Gym.BusinessLogic.Services

    //view models => presentation Layer
    // view models => BLL (OK) => Presentation Layer 
    // 1 - Vw in BLL(problem reused ) 
    // 2- Vw in pressentation Layer (Best Practice )
    // BLL => Dtos 
{
    public interface IMemberService
    {
        public Task<IEnumerable<MemberIndexViewModel>> GetAllAsync(CancellationToken cancellationToken = default);

        public Task <bool> CreateAsync(CreateMemberViewModel model, CancellationToken cancellationToken = default);
    }


}
