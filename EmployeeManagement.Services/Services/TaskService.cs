using AutoMapper;
using EmployeeManagement.Contracts.DTOs.Task;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using EmployeeManagement.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(TaskWithoutIdDto dto)
        {
            EmployeeManagement.DataAccess.Entities.Task task = _mapper.Map<EmployeeManagement.DataAccess.Entities.Task>(dto);

            await _repository.CreateAsync(task);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task UpdateAsync(TaskWithIdDto dto)
        {
            EmployeeManagement.DataAccess.Entities.Task task = _mapper.Map<EmployeeManagement.DataAccess.Entities.Task>(dto);

            await _repository.UpdateAsync(task);
        }
        public async Task<TaskWithoutIdDto> GetTaskAsync(Guid id)
        {
            EmployeeManagement.DataAccess.Entities.Task? task = await _repository.GetByIdAsync(id);
            if (task is null)
            {
                throw new ArgumentNullException("No such task exists!");
            }
            return _mapper.Map<TaskWithoutIdDto>(task);
        }

        public async Task<List<TaskWithoutIdDto>> GetAll()
        {
            List<EmployeeManagement.DataAccess.Entities.Task> tasks = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<TaskWithoutIdDto>>(tasks);
        }

        public async Task<List<TaskWithoutIdDto>> GetAll(Expression<Func<TaskWithIdDto, bool>> filter)
        {
            var taskFilter = _mapper.Map<Expression<Func<EmployeeManagement.DataAccess.Entities.Task, bool>>>(filter);
            List<EmployeeManagement.DataAccess.Entities.Task> tasks = await _repository.GetAll(taskFilter).ToListAsync();
            return _mapper.Map<List<TaskWithoutIdDto>>(tasks);
        }
    }
}
