using EmployeeManagement.Contracts.DTOs.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.DTOs.Employee
{
    public class EmployeeWithoutIdDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal MonthlySalary { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<TaskWithIdDto> Tasks { get; set; } = new List<TaskWithIdDto>();
    }
}
