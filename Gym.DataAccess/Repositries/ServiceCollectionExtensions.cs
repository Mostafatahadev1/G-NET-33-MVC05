using Gym.DataAccess.Interceptors;
using Gym.Presentation.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Repositries
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGymDataAccess(this IServiceCollection services ,string connectionString)
        {
            services.AddSingleton<AuditColumnsInterceptor>();
            services.AddDbContext<GymDbContext>((sp, options) =>
            {
                options.UseSqlServer(connectionString);
                options.AddInterceptors(sp.GetRequiredService<AuditColumnsInterceptor>());
            });

            services.AddScoped<IPlanRepository, PlanRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IMemberRepository, MemberRepository>();

            return services;
        }
    }
}
