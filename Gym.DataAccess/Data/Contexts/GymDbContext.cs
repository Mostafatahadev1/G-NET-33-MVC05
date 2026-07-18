using Gym.DataAccess.Entities;
using Gym.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Presentation.Data.Contexts;

public class GymDbContext : DbContext
{
    public GymDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasDiscriminator<string>("UserType")
            .HasValue<Member>("Member")
            .HasValue<Trainer>("Trainer");

        modelBuilder.Entity<User>()
            .HasQueryFilter(u => !u.IsDeleted);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDbContext).Assembly);
    }

    public DbSet<DataAccess.Entities.Plan> Plans { get; set; } = default!;

    public DbSet<Category> Categories { get; set; }

    public DbSet<Member> Members { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Session> Sessions { get; set; }

    public DbSet<MemberShip> MemberShips { get; set; }

    public DbSet<Booking> Bookings { get; set; }

    public DbSet<HealthRecord> HealthRecords { get; set; }
}