using Base.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Base.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public BaseDbContext Context { get; }
        private IDbContextTransaction _dbTransactiion;
        private bool disposed = false;

        public UnitOfWork(BaseDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            _dbTransactiion.Commit();
        }

        public void RollBack()
        {
            _dbTransactiion.Rollback();
        }

        public void BeginTransaction()
        {
            _dbTransactiion = Context.Database.BeginTransaction();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
