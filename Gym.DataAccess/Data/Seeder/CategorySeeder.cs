using Gym.DataAccess.Entities;
using Gym.Presentation.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Gym.DataAccess.Data.Seeder
{
    public static class CategorySeeder
    {
        public static async Task SeedAsync(GymDbContext dbContext)
        {
            if (await dbContext.Categories.AnyAsync())
                return;

            var categories = new List<Category>
            {
                new Category { Name = "Strength Training" },
                new Category { Name = "Cardio" },
                new Category { Name = "Bodybuilding" },
                new Category { Name = "CrossFit" },
                new Category { Name = "Yoga" },
                new Category { Name = "Pilates" },
                new Category { Name = "Powerlifting" },
                new Category { Name = "Weight Loss" },
                new Category { Name = "Functional Training" },
                new Category { Name = "HIIT" }
            };

            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
        }
    }
}