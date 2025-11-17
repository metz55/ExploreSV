using Ardalis.Specification.EntityFrameworkCore;
using ExploreSV.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.DataAccess.Repositories
{
    class EfRepository<T> : RepositoryBase<T>, IEfRepository<T> where T : class
    {
        private readonly ExploreSVContext _context;
        private IDbContextTransaction? _transaction;

        public EfRepository(ExploreSVContext context) : base(context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                return;
            }

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
            {
                return;
            }

            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;

        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
            {
                return;
            }

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity); // Usa Remove de DbSet<T>
            await _context.SaveChangesAsync(cancellationToken); // Guarda los cambios
        }
    }
}