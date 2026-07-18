using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaaSBillingSystem.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository <TEntity>() where TEntity : class;
        // ICustomerRepository Customers { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);        
    }
}