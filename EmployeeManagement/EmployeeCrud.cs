using EmployeeManagement.Contracts.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public static class EmployeeCrud
    {
        private static int id = 4;
        public static EmployeeWithoutIdDto CreateEmployee()
        {
            Console.Write("Full name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Date of birth (yyyy-MM-dd: ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Monthly salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("Department ID: ");
            string depId = Console.ReadLine();

            return new EmployeeWithoutIdDto()
            {
                FullName = name,
                Email = email,
                PhoneNumber = phone,
                DateOfBirth = dateOfBirth,
                MonthlySalary = salary,
                DepartmentId = int.Parse(depId)
            };
        }

        public static EmployeeWithIdDto UpdateEmployee()
        {
            id++;
            Console.Write("Full name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Date of birth (yyyy-MM-dd: ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Monthly salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("Department ID: ");
            string depId = Console.ReadLine();

            return new EmployeeWithIdDto()
            {
                Id = id,
                FullName = name,
                Email = email,
                PhoneNumber = phone,
                DateOfBirth = dateOfBirth,
                MonthlySalary = salary,
                DepartmentId = int.Parse(depId)
            };
        }
        public static int GetEmployeeById()
        {
            Console.Write ("Id: ");
            return int.Parse(Console.ReadLine());
        }

        public static string GetEmployeeByEmail()
        {
            Console.Write("Email: ");
            return Console.ReadLine();
        }
        public static List<EmployeeWithoutIdDto> GetTopFiveEmployees()
        {

        }

    }
}
