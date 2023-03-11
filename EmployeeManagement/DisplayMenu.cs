

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
            Console.WriteLine("2 - Get employee by id");
            Console.WriteLine("3 - Get employee by email");
            Console.WriteLine("4 - Update employee");
            Console.WriteLine("5 - Get top 5 employees:");
            Console.WriteLine("6 - Delete employee by id");
        }

        public static void DisplayTaskMenu()
        {
            Console.WriteLine("Choose what you want to do with it:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Create new task");
            Console.WriteLine("2 - Get task by id");
            Console.WriteLine("3 - Update task");
            Console.WriteLine("4 - Delete task by id");
        }

        public static void DisplayDepartmentMenu()
        {
            Console.WriteLine("Choose what you want to do with it:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Create new department");
            Console.WriteLine("2 - Get department by id");
            Console.WriteLine("3 - Update department");
            Console.WriteLine("4 - Delete department by id");
        }

        
    }
}
