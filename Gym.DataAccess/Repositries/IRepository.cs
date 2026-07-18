using Gym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Repositries
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync(
            CancellationToken cancellationToken = default);


        Task<TEntity?> GetByIdAsync(
         int id,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetByIdIncludingDeletedAsync(
            int id,
            CancellationToken cancellationToken = default);

        // CRUD  
        Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        //FindAsync x=> x.Name




        Task<bool> ExistsAsync(
             Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);
        Task AddAsync (TEntity entity , CancellationToken cancellationToken = default);


        void Update(TEntity entity);

        Task SoftDeleteAsync(TEntity entity, CancellationToken cancellationToken = default);


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


    }

}
