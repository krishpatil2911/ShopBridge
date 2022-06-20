using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<User> users { get; }
        public IGenericRepository<Product> products { get; }
        Task Save();
    }
}
