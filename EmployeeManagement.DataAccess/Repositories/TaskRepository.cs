using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Repositories
{
    public class TaskRepository : BaseRepository<Entities.Task>, ITaskRepository
    {
        public TaskRepository(EmployeeManagementDbContext _context) 
            : base(_context) 
        { 
        }
    }
}
