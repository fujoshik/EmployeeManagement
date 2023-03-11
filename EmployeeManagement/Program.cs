using EmployeeManagement;
using EmployeeManagement.Contracts.DTOs.Employee;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Repositories;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using EmployeeManagement.Services.Services;
using EmployeeManagement.Services.Services.Interfaces;



EmployeeManagementDbContext dbContext = new();
IEmployeeRepository employeeRepo = new EmployeeRepository(dbContext);
ITaskRepository taskRepo = new TaskRepository(dbContext);
IDepartmentRepository departmentRepo = new DepartmentRepository(dbContext);

IEmployeeService employeeService = new EmployeeService(employeeRepo, );
ITaskService taskService = new TaskService(taskRepo, );
IDepartmentService departmentService = new DepartmentService(departmentRepo, , employeeService);




DisplayMenu.DisplayInitialMenu();
string input = Console.ReadLine();
while(input != "0")
{
    switch (input)
    {
        case "1": EmployeeMenu(); break;
        case "2": DisplayMenu.DisplayTaskMenu(); break;
        case "3": DisplayMenu.DisplayDepartmentMenu(); break;
        default: break;
    }
    DisplayMenu.DisplayInitialMenu();
    input = Console.ReadLine();
}
Console.WriteLine("Thank you!");


// fix
void EmployeeMenu()
{
    DisplayMenu.DisplayEmployeeMenu();
    string secondInput = Console.ReadLine();
    while (secondInput != "0")
    {
        switch (secondInput)
        {
            case "1":
                employeeService.AddAsync(EmployeeCrud.CreateEmployee()); 
                break;
            case "2":
                employeeService.GetEmployeeAsync(EmployeeCrud.GetEmployeeById());
                break;
            case "3":
                employeeService.GetEmployeeByEmail(EmployeeCrud.GetEmployeeByEmail()); 
                break;
            case "4":
                employeeService.UpdateAsync(EmployeeCrud.UpdateEmployee());
                break;
            case "5":
                Console.WriteLine(string.Join(" ", employeeService.TopFiveEmployeesOfTheWeek().Select(e => e.FullName)));
                break;
            case "6":
                employeeService.DeleteAsync(EmployeeCrud.GetEmployeeById()); 
                break;
            default: break;
        }
        Console.Clear();
        DisplayMenu.DisplayInitialMenu();
        secondInput = Console.ReadLine();
    }
}




