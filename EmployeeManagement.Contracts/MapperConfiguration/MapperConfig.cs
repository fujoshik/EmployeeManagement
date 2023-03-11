using AutoMapper;
using EmployeeManagement.Contracts.DTOs.Department;
using EmployeeManagement.Contracts.DTOs.Employee;
using EmployeeManagement.Contracts.DTOs.Task;
using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.MapperConfiguration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Employee, EmployeeWithIdDto>().ReverseMap();
            CreateMap<Employee, EmployeeWithoutIdDto>().ReverseMap();
            CreateMap<DataAccess.Entities.Task, TaskWithIdDto>().ReverseMap();
            CreateMap<DataAccess.Entities.Task, TaskWithoutIdDto>().ReverseMap();
            CreateMap<Department, DepartmentWithIdDto>().ReverseMap();
            CreateMap<Department, DepartmentWithoutIdDto>().ReverseMap();
        }
    }
}
