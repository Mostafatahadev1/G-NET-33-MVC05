using Gym.DataAccess.Data.Seeder;
using Gym.Presentation.Data.Contexts;

namespace Gym.Presentation.Data.Seeder
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAllAsync(GymDbContext dbContext)
        {
            await PlanSeeder.SeedAsync(dbContext);
            await CategorySeeder.SeedAsync(dbContext);
        }
    }
}
