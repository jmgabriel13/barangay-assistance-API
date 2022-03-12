using Base.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Base.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public BaseDbContext Context { get; }
        private IDbContextTransaction _dbTransactiion;

        public UnitOfWork(BaseDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            _dbTransactiion.Commit();
        }

        public void Dispose()
        {
            Context.Dispose();
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
    }
}
