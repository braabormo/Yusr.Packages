using Yusr.Core.Abstractions.Interfaces;
using Yusr.Persistence.Context;

namespace Yusr.Persistence.Repositories
{
    public class UnitOfWork(YusrDbContext context) : IUnitOfWork
    {
        private readonly YusrDbContext _context = context;

        public async Task<ITransaction> BeginTransactionAsync()
        {
            var efTransaction = await _context.Database.BeginTransactionAsync();
            return new EfTransactionWrapper(efTransaction);
        }
    }
}