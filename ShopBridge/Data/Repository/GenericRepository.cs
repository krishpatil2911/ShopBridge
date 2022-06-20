using Data.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private readonly DatabaseContext dbContext;
        private readonly DbSet<T> db;
        public GenericRepository(DatabaseContext context)
        {
            dbContext = context;
            db = dbContext.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await db.FindAsync(id);
            db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            db.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
