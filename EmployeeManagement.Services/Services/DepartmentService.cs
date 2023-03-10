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

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(DepartmentWithoutIdDto dto)
        {
            Department department = _mapper.Map<Department>(dto);

            await _repository.CreateAsync(department);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task UpdateAsync(DepartmentWithIdDto dto)
        {
            Department department = _mapper.Map<Department>(dto);

            await _repository.UpdateAsync(department);
        }
        public async Task<DepartmentWithoutIdDto> GetDepartmentAsync(Guid id)
        {
            Department? department = await _repository.GetByIdAsync(id);
            if (department is null)
            {
                throw new ArgumentException("No such department exists!");
            }
            return _mapper.Map<DepartmentWithoutIdDto>(department);
        }

        public async Task<List<DepartmentWithoutIdDto>> GetAll()
        {
            List<Department> departments = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<DepartmentWithoutIdDto>>(departments);
        }

        public async Task<List<DepartmentWithoutIdDto>> GetAll(Expression<Func<DepartmentWithIdDto, bool>> filter)
        {
            var departmentFilter = _mapper.Map<Expression<Func<Department, bool>>>(filter);
            List<Department> departments = await _repository.GetAll(departmentFilter).ToListAsync();
            return _mapper.Map<List<DepartmentWithoutIdDto>>(departments);
        }

        //public double PercentageOfEmployees()
        //{

        //}
    }
}
