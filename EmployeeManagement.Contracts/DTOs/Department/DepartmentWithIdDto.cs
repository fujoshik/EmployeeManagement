using EmployeeManagement.Contracts.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.DTOs.Department
{
    public class DepartmentWithIdDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<EmployeeWithoutIdDto>? Employees { get; set; }
    }
}
