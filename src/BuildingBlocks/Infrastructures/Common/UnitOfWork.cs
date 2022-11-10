using Contracts.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Common
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync() => _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
