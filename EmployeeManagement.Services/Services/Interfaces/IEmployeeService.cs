using EmployeeManagement.Contracts.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeWithoutIdDto>> GetAll();

        Task<List<EmployeeWithoutIdDto>> GetAll(Expression<Func<EmployeeWithIdDto, bool>> filter);

        Task<EmployeeWithoutIdDto> GetEmployeeAsync(Guid id);

        Task AddAsync(EmployeeWithoutIdDto dto);

        Task UpdateAsync(EmployeeWithIdDto dto);

        Task DeleteAsync(Guid id);
        EmployeeWithoutIdDto GetEmployeeByEmail(string email);
    }
}
