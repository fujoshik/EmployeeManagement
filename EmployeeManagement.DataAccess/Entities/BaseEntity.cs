using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Entities
{
    public class BaseEntity
    {
        // The chosen type of the Id is int so that the application doesn't get overcomplicated
        // (and it's easier to demonstrate the functionality.
        // Otherwise, the chosen type would have been Guid
        public int Id { get; set; } 
    }
}
