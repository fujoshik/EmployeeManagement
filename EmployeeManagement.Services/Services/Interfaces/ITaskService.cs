using EmployeeManagement.Contracts.DTOs.Employee;
using EmployeeManagement.Contracts.DTOs.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskWithoutIdDto>> GetAll();

        Task<List<TaskWithoutIdDto>> GetAll(Expression<Func<TaskWithIdDto, bool>> filter);

        Task<TaskWithoutIdDto> GetEmployeeAsync(Guid id);

        Task AddAsync(TaskWithoutIdDto dto);

        Task UpdateAsync(TaskWithIdDto dto);

        Task DeleteAsync(Guid id);
    }
}
