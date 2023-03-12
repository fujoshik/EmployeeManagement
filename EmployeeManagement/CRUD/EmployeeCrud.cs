using EmployeeManagement.Contracts.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.CRUD
{
    public static class EmployeeCrud
    {
        public static EmployeeWithoutIdDto CreateEmployee()
        {
            Console.Write("Full name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Date of birth (yyyy-MM-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Monthly salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("Department ID: ");
            int depId = int.Parse(Console.ReadLine());

            return new EmployeeWithoutIdDto()
            {
                FullName = name,
                Email = email,
                PhoneNumber = phone,
                DateOfBirth = dateOfBirth,
                MonthlySalary = salary,
                DepartmentId = depId
            };
        }

        public static EmployeeWithIdDto UpdateEmployee()
        {
            Console.Write("Current ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("New full name: ");
            string name = Console.ReadLine();
            Console.Write("New email: ");
            string email = Console.ReadLine();
            Console.Write("New phone number: ");
            string phone = Console.ReadLine();
            Console.Write("New date of birth (yyyy-MM-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("New monthly salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("New department ID: ");
            int depId = int.Parse(Console.ReadLine());

            return new EmployeeWithIdDto()
            {
                Id = id,
                FullName = name,
                Email = email,
                PhoneNumber = phone,
                DateOfBirth = dateOfBirth,
                MonthlySalary = salary,
                DepartmentId = depId
            };
        }
        public static int GetEmployeeById()
        {
            Console.Write("Id: ");
            return int.Parse(Console.ReadLine());
        }

        public static string GetEmployeeByEmail()
        {
            Console.Write("Email: ");
            return Console.ReadLine();
        }

    }
}
