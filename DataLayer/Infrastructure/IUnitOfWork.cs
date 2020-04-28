using System;
namespace DataLayer.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
