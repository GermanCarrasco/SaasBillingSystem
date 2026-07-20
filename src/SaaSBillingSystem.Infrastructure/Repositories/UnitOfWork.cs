using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaaSBillingSystem.Application.Repositories;
using SaaSBillingSystem.Infrastructure.Persistence;

namespace SaaSBillingSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbcontext _dbcontext;

        public UnitOfWork(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbcontext.SaveChangesAsync(cancellationToken);
        }
    }
}