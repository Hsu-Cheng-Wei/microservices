using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GeekTime.Infrastructure.Core
{
    public class EFContext : DbContext, IUnitOfWork, ITransaction
    {
        protected IMediator _mediator;
        //ICapPublisher _capBus;

        public EFContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
            //_capBus = capBus;
        }

        #region IUnitOfWork
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _ = await base.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ITransaction
        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = Database.BeginTransaction();

            return Task.FromResult(_currentTransaction);
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if(transaction == null) throw new ArgumentNullException(nameof(transaction));

            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await transaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                DisposeTransaction();
            }
        }
        #endregion

        private void DisposeTransaction()
        {
            if (_currentTransaction == null) return;

            _currentTransaction.Dispose();

            _currentTransaction = null;
        }
    }
}
