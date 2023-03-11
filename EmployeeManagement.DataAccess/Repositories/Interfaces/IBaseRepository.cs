using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        System.Threading.Tasks.Task CreateAsync(T entity);
        System.Threading.Tasks.Task DeleteAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        ValueTask<T> GetByIdAsync(int id);
        System.Threading.Tasks.Task UpdateAsync(T entity);
    }
}
