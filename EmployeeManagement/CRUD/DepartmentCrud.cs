using EmployeeManagement.Contracts.DTOs.Department;
using EmployeeManagement.Contracts.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.CRUD
{
    public static class DepartmentCrud
    {
        private static int id = 3;
        public static DepartmentWithoutIdDto CreateDepartment()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();

            return new DepartmentWithoutIdDto()
            {
                Name = name,
                Description = description
            };
        }

        public static DepartmentWithIdDto UpdateDepartment()
        {
            id++;
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();

            return new DepartmentWithIdDto()
            {
                Id = id,
                Name = name,
                Description = description
            };
        }
        public static int GetDepartmentById()
        {
            Console.Write("Id: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
