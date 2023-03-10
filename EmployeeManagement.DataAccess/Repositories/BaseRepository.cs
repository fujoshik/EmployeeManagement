using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly EmployeeManagementDbContext _context;

        public BaseRepository(EmployeeManagementDbContext context)
        {
            this._context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }

        public virtual async ValueTask<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async System.Threading.Tasks.Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async System.Threading.Tasks.Task UpdateAsync(T entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException($"No such {typeof(T)} with id: {entity.Id}");
            }

            _context.Entry(dbEntity).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async System.Threading.Tasks.Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException($"No such {typeof(T)} with id: {id}");
            }

            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
