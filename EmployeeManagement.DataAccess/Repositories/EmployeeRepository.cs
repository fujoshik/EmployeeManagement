using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(EmployeeManagementDbContext _context) 
            : base(_context) 
        {
        }
        public Employee? GetEmployeeByEmail(string email)
        {
            return _context.Employees.SingleOrDefault(x => x.Email == email);
        }
        public override IQueryable<Employee> GetAll()
        {
            return _context.Set<Employee>().AsQueryable().Include(x => x.Tasks);
        }
    }
}
