using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Contracts.DTOs.Employee;

namespace EmployeeManagement.Contracts.DTOs.Department
{
    public class DepartmentWithoutIdDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        //EmployeeWithIdDto or EmployeeWithoutId?
        public ICollection<EmployeeWithoutIdDto>? Employees { get; set; }
    }
}
