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
        public Task<List<EmployeeWithoutIdDto>> GetAllAsync();

        public Task<List<EmployeeWithoutIdDto>> GetAllAsync(Expression<Func<EmployeeWithIdDto, bool>> filter);

        public Task<EmployeeWithoutIdDto> GetEmployeeAsync(int id);

        public Task AddAsync(EmployeeWithoutIdDto dto);

        public Task UpdateAsync(EmployeeWithIdDto dto);

        public Task DeleteAsync(int id);

        public EmployeeWithoutIdDto GetEmployeeByEmail(string email);

        public List<EmployeeWithoutIdDto> TopFiveEmployeesOfTheWeek();

        public Task<string> DisplayEmployeeInfoByIdAsync(int id);
    }
}
