using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null);
        Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null);
        Task InsertRange(IEnumerable<T> entities);
        Task Insert(T entity);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
