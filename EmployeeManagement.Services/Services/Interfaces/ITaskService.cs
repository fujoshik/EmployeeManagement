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
        public Task<List<TaskWithoutIdDto>> GetAllAsync();

        public Task<List<TaskWithoutIdDto>> GetAllAsync(Expression<Func<TaskWithIdDto, bool>> filter);

        public Task<TaskWithoutIdDto> GetTaskAsync(int id);

        public Task AddAsync(TaskWithoutIdDto dto);

        public Task UpdateAsync(TaskWithIdDto dto);

        public Task DeleteAsync(int id);
    }
}
