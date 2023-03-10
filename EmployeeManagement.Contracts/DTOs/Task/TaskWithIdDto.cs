using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Contracts.DTOs.Employee;

namespace EmployeeManagement.Contracts.DTOs.Task
{
    public class TaskWithIdDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public EmployeeWithIdDto? Assignee { get; set; }
        public DateTime DueDate { get; set; }
    }
}
