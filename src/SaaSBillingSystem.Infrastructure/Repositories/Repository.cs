using Microsoft.EntityFrameworkCore;
using SaaSBillingSystem.Application.Repositories;
using SaaSBillingSystem.Infrastructure.Persistence;

namespace SaaSBillingSystem.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbcontext _dbcontext;

        public Repository(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
             await _dbcontext.AddAsync(entity,cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbcontext.AddRangeAsync(entities,cancellationToken);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbcontext.Set<TEntity>()
                .FindAsync(new object[] { id }, cancellationToken);

            return entity is not null;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbcontext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbcontext.Set<TEntity>()
                .FindAsync(new object[] { id }, cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            _dbcontext.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbcontext.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbcontext.Update(entity);
        }
    }
}