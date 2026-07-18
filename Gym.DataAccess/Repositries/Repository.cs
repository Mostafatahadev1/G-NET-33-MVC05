using Gym.DataAccess.Entities;
using Gym.Presentation.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gym.DataAccess.Repositries
{
    public class Repository<TEntity> (GymDbContext dbContext): IRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly GymDbContext _dbContext = dbContext;

        private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.AsNoTracking().ToListAsync(cancellationToken); 

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
           => await _dbSet.FirstOrDefaultAsync(t=>t.Id == id, cancellationToken);

        public async Task<TEntity?> GetByIdIncludingDeletedAsync(
                 int id, CancellationToken cancellationToken = default)
          => await _dbSet.IgnoreQueryFilters().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);


        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
         => await _dbSet.AddAsync(entity, cancellationToken);    

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        =>await _dbSet.AnyAsync(predicate, cancellationToken);

        public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
           => await _dbSet.Where(predicate).ToListAsync(cancellationToken);

   

        public Task SoftDeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.IsDeleted = true;

            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public void Update(TEntity entity)
           => _dbSet.Update(entity);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
       =>_dbContext.SaveChangesAsync(cancellationToken);
    }
}
