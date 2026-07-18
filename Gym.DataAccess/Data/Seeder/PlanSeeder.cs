using Gym.DataAccess.Entities;
using Gym.Presentation.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Gym.DataAccess.Data.Seeder
{
    public static class PlanSeeder
    {
        public static async Task SeedAsync(GymDbContext dbContext)
        {
            if (await dbContext.Plans.AnyAsync())
                return;

            var plans = new List<Plan>
            {
                new Plan
                {
                    Name = "Basic",
                    Description = "Access to gym only",
                    DurationDays = 30,
                    Price = 300,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Plan
                {
                    Name = "Silver",
                    Description = "Gym + Cardio",
                    DurationDays = 30,
                    Price = 450,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Plan
                {
                    Name = "Gold",
                    Description = "Gym + Cardio + Sauna",
                    DurationDays = 30,
                    Price = 600,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Plan
                {
                    Name = "Premium",
                    Description = "All services included",
                    DurationDays = 30,
                    Price = 800,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Plan
                {
                    Name = "Student",
                    Description = "Discounted plan for students",
                    DurationDays = 90,
                    Price = 700,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Plan
                {
                    Name = "Quarterly",
                    Description = "3 months membership",
                    DurationDays = 90,
                    Price = 1200,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Plan
                {
                    Name = "Semi Annual",
                    Description = "6 months membership",
                    DurationDays = 180,
                    Price = 2200,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Plan
                {
                    Name = "Annual",
                    Description = "12 months membership",
                    DurationDays = 365,
                    Price = 4000,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Plan
                {
                    Name = "VIP",
                    Description = "VIP membership with personal trainer",
                    DurationDays = 365,
                    Price = 7000,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Plan
                {
                    Name = "Inactive Plan",
                    Description = "Old membership plan",
                    DurationDays = 30,
                    Price = 250,
                    IsActive = false,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await dbContext.Plans.AddRangeAsync(plans);
            await dbContext.SaveChangesAsync();
        }
    }
}
