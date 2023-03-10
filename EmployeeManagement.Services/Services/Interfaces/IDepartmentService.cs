using EmployeeManagement.Contracts.DTOs.Department;
using EmployeeManagement.Contracts.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentWithoutIdDto>> GetAll();

        Task<List<DepartmentWithoutIdDto>> GetAll(Expression<Func<DepartmentWithIdDto, bool>> filter);

        Task<DepartmentWithoutIdDto> GetDepartmentAsync(Guid id);

        Task AddAsync(DepartmentWithoutIdDto dto);

        Task UpdateAsync(DepartmentWithIdDto dto);

        Task DeleteAsync(Guid id);

        double PercentageOfAllEmployeesInCurrentDepartment();
    }
}
