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
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeManagementDbContext _context)
            : base(_context)
        {
        }
        public override IQueryable<Department> GetAll()
        {
            return _context.Set<Department>().AsQueryable().Include(x => x.Employees);
        }
    }
}
