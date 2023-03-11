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
        public Task<List<DepartmentWithoutIdDto>> GetAllAsync();

        public Task<List<DepartmentWithoutIdDto>> GetAllAsync(Expression<Func<DepartmentWithIdDto, bool>> filter);

        public Task<DepartmentWithoutIdDto> GetDepartmentAsync(int id);

        public Task AddAsync(DepartmentWithoutIdDto dto);

        public Task UpdateAsync(DepartmentWithIdDto dto);

        public Task DeleteAsync(int id);

        public Task<double> PercentageOfAllEmployeesInCurrentDepartmentAsync(int id);

        public Task<string> DisplayDepartmentInfoByIdAsync(int id);

        public Task<string> TopDepartmentOfTheMonthInfoAsync();
    }
}
