using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
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
    }
}
