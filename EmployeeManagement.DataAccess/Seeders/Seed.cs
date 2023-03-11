using EmployeeManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
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
            using (var transaction = context.Database.BeginTransaction())
            {
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
                        DepartmentId = 3
                    },
                    new Employee
                    {
                        Id = 2,
                        FullName = "Nina Sergeeeva",
                        Email = "nina_s18@abc.de",
                        PhoneNumber = "1234567890",
                        DateOfBirth = new DateTime(1997, 4, 7),
                        MonthlySalary = 1800,
                        DepartmentId = 1
                    },
                    new Employee
                    {
                        Id = 3,
                        FullName = "Dominic Raven",
                        Email = "domRaven33@abc.de",
                        PhoneNumber = "1234567890",
                        DateOfBirth = new DateTime(1989, 12, 12),
                        MonthlySalary = 2000,
                        DepartmentId = 2
                    },
                    new Employee
                    {
                        Id = 4,
                        FullName = "Savannah Colleen",
                        Email = "savannahColl11@abc.de",
                        PhoneNumber = "1234567890",
                        DateOfBirth = new DateTime(2003, 7, 25),
                        MonthlySalary = 2000,
                        DepartmentId = 3
                    }
                };

                await context.Employees.AddRangeAsync(_employees);
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Employees ON;");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Employees OFF;");
                transaction.Commit();
            }
            
        }

        public static async System.Threading.Tasks.Task SeedDepartmentsAsync(EmployeeManagementDbContext context)
        {
            if (await context.Departments.AnyAsync()) return;

            using (var transaction = context.Database.BeginTransaction())
            {
                _departments = new List<Department>
                {
                    new Department
                    {
                        Id = 1,
                        Name = "Finances",
                        Description = "Manages finances"
                    },
                    new Department
                    {
                        Id = 2,
                        Name = "HR",
                        Description = "Manages people"
                    },
                    new Department
                    {
                        Id = 3,
                        Name = "IT",
                        Description = "Manages software"
                    }
                };

                await context.Departments.AddRangeAsync(_departments);
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Departments ON;");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Departments OFF;");
                transaction.Commit();
            }
                
        }

        public static async System.Threading.Tasks.Task SeedTasksAsync(EmployeeManagementDbContext context)
        {
            if (await context.Tasks.AnyAsync()) return;

            using (var transaction = context.Database.BeginTransaction())
            {
                _tasks = new List<Entities.Task>
                {
                    new Entities.Task
                    {
                        Id = 1,
                        Title = "Entities",
                        Description = "Implement necessary entities",
                        DueDate = DateTime.Now.AddDays(-3),
                        AssigneeId = 1
                    },
                    new Entities.Task
                    {
                        Id = 2,
                        Title = "Interfaces",
                        Description = "Implement necessary interfaces",
                        DueDate = DateTime.Now.AddDays(-15),
                        AssigneeId = 1
                    },
                    new Entities.Task
                    {
                        Id = 3,
                        Title = "Repositories",
                        Description = "Implement necessary repositories",
                        DueDate = DateTime.Now.AddDays(-5),
                        AssigneeId = 1
                    },
                    new Entities.Task
                    {
                        Id = 4,
                        Title = "Monthy expenses",
                        Description = "Check necessary montly expenses",
                        DueDate = DateTime.Now.AddDays(-8),
                        AssigneeId = 2
                    },
                    new Entities.Task
                    {
                        Id = 5,
                        Title = "Internship",
                        Description = "Check applications for internship",
                        DueDate = DateTime.Now.AddDays(-18),
                        AssigneeId = 3
                    },
                    new Entities.Task
                    {
                        Id = 6,
                        Title = "Intern Tasks",
                        Description = "Check each intern's task",
                        DueDate = DateTime.Now.AddDays(-3),
                        AssigneeId = 3
                    },
                    new Entities.Task
                    {
                        Id = 7,
                        Title = "Entities",
                        Description = "Implement necessary entities",
                        DueDate = DateTime.Now.AddDays(-23),
                        AssigneeId = 4
                    },
                    new Entities.Task
                    {
                        Id = 8,
                        Title = "Interfaces",
                        Description = "Implement necessary interfaces",
                        DueDate = DateTime.Now.AddDays(-15),
                        AssigneeId = 4
                    },
                    new Entities.Task
                    {
                        Id = 9,
                        Title = "Repositories",
                        Description = "Implement necessary repositories",
                        DueDate = DateTime.Now.AddDays(-5),
                        AssigneeId = 4
                    }
                };

                await context.Tasks.AddRangeAsync(_tasks);
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Tasks ON;");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Tasks OFF;");
                transaction.Commit();
            }

        }

    }
}
