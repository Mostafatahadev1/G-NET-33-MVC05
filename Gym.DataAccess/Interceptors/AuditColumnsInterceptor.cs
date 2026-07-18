using Gym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Gym.DataAccess.Interceptors;

public sealed class AuditColumnsInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        ApplyAuditColumns(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditColumns(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void ApplyAuditColumns(DbContext? context)
    {
        if (context == null)
            return;

        var utcNow = DateTime.UtcNow;

        foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:

                    entry.Entity.CreatedAt = utcNow;
                    entry.Entity.UpdatedAt = null;

                    if (entry.Entity.IsDeleted &&
                        entry.Entity.DeletedAt == null)
                    {
                        entry.Entity.DeletedAt = utcNow;
                    }

                    break;

                case EntityState.Modified:

                    entry.Entity.UpdatedAt = utcNow;

                    if (entry.Entity.IsDeleted)
                    {
                        if (entry.Entity.DeletedAt == null)
                            entry.Entity.DeletedAt = utcNow;
                    }
                    else
                    {
                        entry.Entity.DeletedAt = null;
                    }

                    break;
            }
        }
    }
}