using AutoMapper;
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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper, IEmployeeService employeeService)
        {
            _repository = repository;
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task AddAsync(DepartmentWithoutIdDto dto)
        {
            Department department = _mapper.Map<Department>(dto);

            await _repository.CreateAsync(department);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task UpdateAsync(DepartmentWithIdDto dto)
        {
            Department department = _mapper.Map<Department>(dto);

            await _repository.UpdateAsync(department);
        }
        public async Task<DepartmentWithoutIdDto> GetDepartmentAsync(int id)
        {
            Department? department = await _repository.GetByIdAsync(id);
            if (department is null)
            {
                throw new ArgumentNullException("No such department exists!");
            }
            return _mapper.Map<DepartmentWithoutIdDto>(department);
        }

        public async Task<List<DepartmentWithoutIdDto>> GetAllAsync()
        {
            List<Department> departments = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<DepartmentWithoutIdDto>>(departments);
        }

        public async Task<List<DepartmentWithoutIdDto>> GetAllAsync(Expression<Func<DepartmentWithIdDto, bool>> filter)
        {
            var departmentFilter = _mapper.Map<Expression<Func<Department, bool>>>(filter);
            List<Department> departments = await _repository.GetAll(departmentFilter).ToListAsync();
            return _mapper.Map<List<DepartmentWithoutIdDto>>(departments);
        }

        public async Task<double> PercentageOfAllEmployeesInCurrentDepartmentAsync(int id)
        {
            var totalEmployees = await _employeeService.GetAllAsync();
            var employeesFromDepartment = totalEmployees.Select(e => e.DepartmentId == id).ToList();
            return employeesFromDepartment.Count / totalEmployees.Count * 100;
        }

        public async Task<string> DisplayDepartmentInfoByIdAsync(int id)
        {
            var department = await GetDepartmentAsync(id);
            double percentage = await PercentageOfAllEmployeesInCurrentDepartmentAsync(id);
            return string.Format($"Department name: {department.Name}{Environment.NewLine}Description: {department.Description}{Environment.NewLine}The percentage of all employees that work here: {percentage}");
        }

        public async Task<string> TopDepartmentOfTheMonthInfoAsync()
        {
            var departments = await _employeeService.TopFiveEmployeesOfTheWeekAsync();
            int departmentId = departments.First().DepartmentId;
            return await DisplayDepartmentInfoByIdAsync(departmentId);
        }
    }
}
