using AutoMapper;
using EmployeeManagement.Contracts.DTOs.Employee;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using EmployeeManagement.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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

        public async System.Threading.Tasks.Task AddAsync(EmployeeWithoutIdDto dto)
        {
            Employee employee = _mapper.Map<Employee>(dto);

            await _repository.CreateAsync(employee);
        }
        public async System.Threading.Tasks.Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
        public async System.Threading.Tasks.Task UpdateAsync(EmployeeWithIdDto dto)
        {
            Employee employee = _mapper.Map<Employee>(dto);

            await _repository.UpdateAsync(employee);
        }
        public async Task<EmployeeWithoutIdDto> GetEmployeeAsync(Guid id)
        {
            Employee? employee = await _repository.GetByIdAsync(id);
            if (employee is null)
            {
                throw new ArgumentException("No such employee exists!");
            }
            return _mapper.Map<EmployeeWithoutIdDto>(employee);
        }

        public EmployeeWithoutIdDto GetEmployeeByEmail(string email)
        {
            Employee? employee = _repository.GetEmployeeByEmail(email);
            if (employee is null)
            {
                throw new ArgumentException();
            }
            return _mapper.Map<EmployeeWithoutIdDto>(employee);
        }

        public async Task<List<EmployeeWithoutIdDto>> GetAll()
        {
            List<Employee> employee = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<EmployeeWithoutIdDto>>(employee);
        }

        public async Task<List<EmployeeWithoutIdDto>> GetAll(Expression<Func<EmployeeWithIdDto, bool>> filter)
        {
            var employeeFilter = _mapper.Map<Expression<Func<Employee, bool>>>(filter);
            List<Employee> employees = await _repository.GetAll(employeeFilter).ToListAsync();
            return _mapper.Map<List<EmployeeWithoutIdDto>>(employees);
        }
    }
}
