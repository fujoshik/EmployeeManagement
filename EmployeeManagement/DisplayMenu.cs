using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public static class DisplayMenu
    {
        public static void DisplayInitialMenu()
        {
            Console.WriteLine("Welcome to the menu!");
            Console.WriteLine();
            Console.WriteLine("First choose your option:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Employee");
            Console.WriteLine("2 - Task");
            Console.WriteLine("3 - Department");
            Console.WriteLine();
        }

        public static void DisplayEmployeeMenu()
        {
            Console.WriteLine("Choose what you want to do with it:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Create new employee");
            Console.WriteLine("2 - Get employee by email"); //can't get it by id
            Console.WriteLine("3 - Update employee");
            Console.WriteLine("4 - Delete employee");
        }

        public static void DisplayTaskMenu()
        {
            Console.WriteLine("Choose what you want to do with it:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Create new task");
            Console.WriteLine("2 - Get task by name"); // can't get it by id
            Console.WriteLine("3 - Update task");
            Console.WriteLine("4 - Delete task");
        }

        public static void DisplayDepartmentMenu()
        {
            Console.WriteLine("Choose what you want to do with it:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Create new department");
            Console.WriteLine("2 - Get department by name"); // should it have a get by name department? Display information maybe?
            Console.WriteLine("3 - Update department");
            Console.WriteLine("4 - Delete department");
        }
    }
}
