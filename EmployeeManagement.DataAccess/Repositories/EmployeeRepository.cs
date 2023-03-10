using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public static List<Employee> employees;
        public EmployeeRepository(EmployeeManagementDbContext _context) 
            : base(_context) 
        {
            employees = new List<Employee>();
        }
        public Employee? GetEmployeeByEmail(string email)
        {
            return _context.Employees.SingleOrDefault(x => x.Email == email);
        }
        public override System.Threading.Tasks.Task CreateAsync(Employee entity)
        {
            employees.Add(entity);
            return base.CreateAsync(entity);
        }
    }
}
