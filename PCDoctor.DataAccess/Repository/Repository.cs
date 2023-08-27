using Microsoft.EntityFrameworkCore;
using PCDoctor.DataAccess.Data;
using PCDoctor.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace PCDoctor.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();   //_db.Categories == dbSet
            _db.Products.Include(obj => obj.Category).Include(obj=>obj.CategoryId);
        }

        public void Add(T entity) 
        {
            dbSet.Add(entity);
        }

        

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var property in includeProperties
                    .Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(property);
                    };
            }
            return query.ToList();  
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                };
            }
            return query.FirstOrDefault();
         }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity); 
        }
    }
}
