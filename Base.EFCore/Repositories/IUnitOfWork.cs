using Base.Entities;
using System;
namespace Base.EFCore.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        BaseDbContext Context { get; }
        void Commit();
        void RollBack();
        void BeginTransaction();
        void SaveChanges();
    }
}
