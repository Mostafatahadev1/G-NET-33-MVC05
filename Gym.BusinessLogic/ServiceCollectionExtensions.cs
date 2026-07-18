using Gym.BusinessLogic.Services;
using Gym.DataAccess.Interceptors;
using Gym.Presentation.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BusinessLogic;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services )
    {
        services.AddScoped<IMemberService, MemberService>();

        return services;
    }
}
