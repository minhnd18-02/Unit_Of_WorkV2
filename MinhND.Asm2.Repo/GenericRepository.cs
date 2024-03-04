using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MinhND.Asm2.Repo.Models;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MinhND.Asm2.Repo
{
    public class GenericRepository<T> where T : class
    {
        private readonly PizzaStoreContext _context;
        internal DbSet<T> _dbSet;
        public GenericRepository(PizzaStoreContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual bool AddEntity(T entity)
        {
            _dbSet.Add(entity);
            return true;
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
        }


        public virtual IEnumerable<T> Get(
                    Expression<Func<T, bool>> filter = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                    string includeProperties = "",
                    int? pageIndex = null, // Optional parameter for pagination (page number)
                    int? pageSize = null)  // Optional parameter for pagination (number of records per page)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Implementing pagination
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                // Ensure the pageIndex and pageSize are valid
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            return query.ToList();
        }

        public virtual T GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
