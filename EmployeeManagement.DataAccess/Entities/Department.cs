using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Entities
{
    public class Department : BaseEntity
    {
        //Data annotations?
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
