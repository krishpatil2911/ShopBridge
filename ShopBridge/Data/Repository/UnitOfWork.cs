using Data.Entity;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
#pragma warning disable S3881 // "IDisposable" should be implemented correctly
    public  class UnitOfWork : IUnitOfWork
#pragma warning restore S3881 // "IDisposable" should be implemented correctly
    {
        private readonly DatabaseContext dbContext;
        private GenericRepository<User> _users;
        private GenericRepository<Product> _products;
        public UnitOfWork(DatabaseContext context)
        {
            dbContext = context;
        }

        public IGenericRepository<User> users => _users ??= new GenericRepository<User>(dbContext);
        public IGenericRepository<Product> products => _products ??= new GenericRepository<Product>(dbContext);

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }

    }
}
