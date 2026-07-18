using Gym.BusinessLogic;
using Gym.DataAccess.Repositries;
using Gym.Presentation.Data.Contexts;
using Gym.Presentation.Data.Seeder;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;






var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GymDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddControllersWithViews();

 string? connectionString = builder.Configuration.GetConnectionString ("DefaultConnection")
    ??throw new InvalidOperationException("Connection string 'DefaultConnection' Not found");

builder.Services.AddGymDataAccess(connectionString);
builder.Services.AddBusinessLogic();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

if(app.Environment.IsDevelopment())
{
    await using var Scope = app.Services.CreateAsyncScope();
    var dbContext = Scope.ServiceProvider.GetRequiredService<GymDbContext>();
    await dbContext.Database.MigrateAsync(); // update database 
    await DatabaseSeeder.SeedAllAsync(dbContext);

}






app.Run();

