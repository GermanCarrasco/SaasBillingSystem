using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaaSBillingSystem.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id,CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync (TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync (IEnumerable<TEntity> entities ,CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
        Task<bool> ExistAsync(int id, CancellationToken cancellationToken = default);
    }
}