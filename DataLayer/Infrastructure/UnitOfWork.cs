using System;
using DataLayer.Context;

namespace DataLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext dbContext;

        public UnitOfWork(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
