using AutoMapper;
using EmployeeManagement.Contracts.DTOs.Employee;
using EmployeeManagement.Contracts.DTOs.Department;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using EmployeeManagement.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagement.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(EmployeeWithoutIdDto dto)
        {
            Employee employee = _mapper.Map<Employee>(dto);

            await _repository.CreateAsync(employee);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task UpdateAsync(EmployeeWithIdDto dto)
        {
            Employee employee = _mapper.Map<Employee>(dto);

            await _repository.UpdateAsync(employee);
        }
        public async Task<EmployeeWithoutIdDto> GetEmployeeAsync(int id)
        {
            Employee? employee = await _repository.GetByIdAsync(id);
            if (employee is null)
            {
                throw new ArgumentNullException("No such employee exists!");
            }
            return _mapper.Map<EmployeeWithoutIdDto>(employee);
        }

        public EmployeeWithoutIdDto GetEmployeeByEmail(string email)
        {
            Employee? employee = _repository.GetEmployeeByEmail(email);
            if (employee is null)
            {
                throw new ArgumentNullException("No such employee exists!");
            }
            return _mapper.Map<EmployeeWithoutIdDto>(employee);
        }

        public async Task<List<EmployeeWithoutIdDto>> GetAllAsync()
        {
            List<Employee> employee = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<EmployeeWithoutIdDto>>(employee);
        }

        public async Task<List<EmployeeWithoutIdDto>> GetAllAsync(Expression<Func<EmployeeWithIdDto, bool>> filter)
        {
            var employeeFilter = _mapper.Map<Expression<Func<Employee, bool>>>(filter);
            List<Employee> employees = await _repository.GetAll(employeeFilter).ToListAsync();
            return _mapper.Map<List<EmployeeWithoutIdDto>>(employees);
        }

        public async Task<List<EmployeeWithoutIdDto>> TopFiveEmployeesOfTheWeekAsync()
        {
            var previousMonth = DateTime.Now.AddMonths(-1).Month;
            var employees = await GetAllAsync();
            var employeesWithTasksFromPreviousMonth = employees.Where(e => e.Tasks.Any(t => t.DueDate.Month == previousMonth));

            if (employeesWithTasksFromPreviousMonth is null)
            {
                throw new ArgumentNullException("No employees with tasks from the previous month");
            }

            if (employeesWithTasksFromPreviousMonth.OrderBy(e => e.Tasks.Count).ToList().Count < 5)
            {
                return employeesWithTasksFromPreviousMonth.OrderBy(e => e.Tasks.Count).ToList();
            }

            return employeesWithTasksFromPreviousMonth.OrderBy(e => e.Tasks.Count).Take(5).ToList();
        }

        public async Task<string> DisplayEmployeeInfoByIdAsync(int id)
        {
            var employee = await GetEmployeeAsync(id);
            return string.Format($"Employee name: {employee.FullName}{Environment.NewLine}" +
                $"Email: {employee.Email}{Environment.NewLine}Phone number: {employee.PhoneNumber}{Environment.NewLine}" +
                $"Date of birth: {employee.DateOfBirth}{Environment.NewLine}Monthly salary: {employee.MonthlySalary}");
        }
    }
}
