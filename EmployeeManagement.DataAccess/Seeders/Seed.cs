using EmployeeManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Seeders
{
    public static class Seed
    {
        private static List<Employee> _employees;
        private static List<Department> _departments;
        private static List<Entities.Task> _tasks;
        public static async System.Threading.Tasks.Task SeedEmployeesAsync(EmployeeManagementDbContext context)
        {
            if (await context.Employees.AnyAsync()) return;

            _employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FullName = "Alexander Dinkov",
                    Email = "alex77@abc.de",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(2000, 1, 18),
                    MonthlySalary = 1200,
                    Tasks = _tasks.Take(3).ToList(),
                    Department = _departments[2],
                    DepartmentId = _departments[2].Id
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Nina Sergeeeva",
                    Email = "nina_s18@abc.de",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(1997, 4, 7),
                    MonthlySalary = 1800,
                    Tasks = _tasks.Skip(3).Take(1).ToList(),
                    Department = _departments[0],
                    DepartmentId = _departments[0].Id
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Dominic Raven",
                    Email = "domRaven33@abc.de",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(1989, 12, 12),
                    MonthlySalary = 2000,
                    Tasks = _tasks.Skip(4).Take(2).ToList(),
                    Department = _departments[1],
                    DepartmentId = _departments[1].Id
                },
                new Employee
                {
                    Id = 4,
                    FullName = "Savannah Colleen",
                    Email = "savannahColl11@abc.de",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(2003, 7, 25),
                    MonthlySalary = 2000,
                    Tasks = _tasks.Skip(6).ToList(),
                    Department = _departments[2],
                    DepartmentId = _departments[2].Id
                }
            };

            await context.Employees.AddRangeAsync(_employees);
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task SeedDepartmentsAsync(EmployeeManagementDbContext context)
        {
            if (await context.Departments.AnyAsync()) return;

            _departments = new List<Department>
            {
                new Department
                {
                    Id = 1,
                    Name = "Finances",
                    Description = "Manages finances",
                    Employees = new List<Employee>(){_employees[1]}
                },
                new Department
                {
                    Id = 2,
                    Name = "HR",
                    Description = "Manages people",
                    Employees = new List<Employee>(){_employees[2]}
                },
                new Department
                {
                    Id = 3,
                    Name = "IT",
                    Description = "Manages software",
                    Employees = new List<Employee>(){_employees[0], _employees[3] }
                }
            };

            await context.Departments.AddRangeAsync(_departments);
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task SeedTasksAsync(EmployeeManagementDbContext context)
        {
            if (await context.Tasks.AnyAsync()) return;

            _tasks = new List<Entities.Task>
            {
                new Entities.Task
                {
                    Id = 1,
                    Title = "Entities",
                    Description = "Implement necessary entities",
                    DueDate = DateTime.Now.AddDays(-3),
                    Assignee = _employees[0],
                    AssigneeId = _employees[0].Id
                },
                new Entities.Task
                {
                    Id = 2,
                    Title = "Interfaces",
                    Description = "Implement necessary interfaces",
                    DueDate = DateTime.Now.AddDays(-15),
                    Assignee = _employees[0],
                    AssigneeId = _employees[0].Id
                },
                new Entities.Task
                {
                    Id = 3,
                    Title = "Repositories",
                    Description = "Implement necessary repositories",
                    DueDate = DateTime.Now.AddDays(-5),
                    Assignee = _employees[0],
                    AssigneeId = _employees[0].Id
                },
                new Entities.Task
                {
                    Id = 4,
                    Title = "Monthy expenses",
                    Description = "Check necessary montly expenses",
                    DueDate = DateTime.Now.AddDays(-8),
                    Assignee = _employees[1],
                    AssigneeId = _employees[1].Id
                },
                new Entities.Task
                {
                    Id = 5,
                    Title = "Internship",
                    Description = "Check applications for internship",
                    DueDate = DateTime.Now.AddDays(-18),
                    Assignee = _employees[2],
                    AssigneeId = _employees[2].Id
                },
                new Entities.Task
                {
                    Id = 6,
                    Title = "Intern Tasks",
                    Description = "Check each intern's task",
                    DueDate = DateTime.Now.AddDays(-3),
                    Assignee = _employees[2],
                    AssigneeId = _employees[2].Id
                },
                new Entities.Task
                {
                    Id = 7,
                    Title = "Entities",
                    Description = "Implement necessary entities",
                    DueDate = DateTime.Now.AddDays(-23),
                    Assignee = _employees[3],
                    AssigneeId = _employees[3].Id
                },
                new Entities.Task
                {
                    Id = 8,
                    Title = "Interfaces",
                    Description = "Implement necessary interfaces",
                    DueDate = DateTime.Now.AddDays(-15),
                    Assignee = _employees[3],
                    AssigneeId = _employees[3].Id
                },
                new Entities.Task
                {
                    Id = 9,
                    Title = "Repositories",
                    Description = "Implement necessary repositories",
                    DueDate = DateTime.Now.AddDays(-5),
                    Assignee = _employees[3],
                    AssigneeId = _employees[3].Id
                }
            };

            await context.Tasks.AddRangeAsync(_tasks);
            await context.SaveChangesAsync();
        }

    }
}
