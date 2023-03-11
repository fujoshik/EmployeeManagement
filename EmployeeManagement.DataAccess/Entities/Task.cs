using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssigneeId { get; set; }
        public Employee Assignee { get; set; }
        public DateTime DueDate { get; set; }
    }
}
