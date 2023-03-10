using AutoMapper;
using EmployeeManagement;
using EmployeeManagement.Contracts.MapperConfiguration;
using EmployeeManagement.CRUD;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Repositories;
using EmployeeManagement.DataAccess.Repositories.Interfaces;
using EmployeeManagement.DataAccess.Seeders;
using EmployeeManagement.Services.Services;
using EmployeeManagement.Services.Services.Interfaces;


//Configurations
EmployeeManagementDbContext dbContext = new();
var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperConfig>());
IMapper mapper = config.CreateMapper();

IEmployeeRepository employeeRepo = new EmployeeRepository(dbContext);
ITaskRepository taskRepo = new TaskRepository(dbContext);
IDepartmentRepository departmentRepo = new DepartmentRepository(dbContext);

IEmployeeService employeeService = new EmployeeService(employeeRepo, mapper);
ITaskService taskService = new TaskService(taskRepo, mapper);
IDepartmentService departmentService = new DepartmentService(departmentRepo, mapper, employeeService);

await Seed.SeedDepartmentsAsync(dbContext);
await Seed.SeedEmployeesAsync(dbContext);
await Seed.SeedTasksAsync(dbContext);



DisplayMenu.DisplayInitialMenu();
string input = Console.ReadLine();
while(input != "0")
{
    switch (input)
    {
        case "1": EmployeeMenu(); break;
        case "2": TaskMenu(); break;
        case "3": DepartmentMenu(); break;
        default: break;
    }
    DisplayMenu.DisplayInitialMenu();
    input = Console.ReadLine();
}
Console.WriteLine("Thank you for using this program!");


async void EmployeeMenu()
{
    DisplayMenu.DisplayEmployeeMenu();
    string secondInput = Console.ReadLine();
    if (secondInput != "0")
    {
        switch (secondInput)
        {
            case "1":
                employeeService.AddAsync(EmployeeCrud.CreateEmployee());
                Console.WriteLine("Done!");
                break;
            case "2":
                Console.WriteLine(employeeService.GetEmployeeAsync(EmployeeCrud.GetEmployeeById()).Result.FullName);
                break;
            case "3":
                Console.WriteLine(employeeService.GetEmployeeByEmail(EmployeeCrud.GetEmployeeByEmail()).FullName); 
                break;
            case "4":
                employeeService.UpdateAsync(EmployeeCrud.UpdateEmployee());
                Console.WriteLine("Done!");
                break;
            case "5":
                Console.WriteLine(string.Join("; ", employeeService.TopFiveEmployeesOfTheWeekAsync().Result.Select(e => e.FullName)));
                break;
            case "6":
                employeeService.DeleteAsync(EmployeeCrud.GetEmployeeById());
                Console.WriteLine("Done!");
                break;
            default: break;
        }
        Console.ReadKey();
        Console.Clear();
    }
}

void TaskMenu()
{
    DisplayMenu.DisplayTaskMenu();
    string secondInput = Console.ReadLine();
    if (secondInput != "0")
    {
        switch (secondInput)
        {
            case "1":
                taskService.AddAsync(TaskCrud.CreateTask());
                Console.WriteLine("Done!");
                break;
            case "2":
                Console.WriteLine(taskService.DisplayTaskInfoByIdAsync(TaskCrud.GetTaskById()).Result);
                break;
            case "3":
                taskService.UpdateAsync(TaskCrud.UpdateTask());
                Console.WriteLine("Done!");
                break;
            case "4":
                taskService.DeleteAsync(TaskCrud.GetTaskById());
                Console.WriteLine("Done!");
                break;
            default: break;
        }
        Console.ReadKey();
        Console.Clear();
    }
}

async void DepartmentMenu()
{
    DisplayMenu.DisplayDepartmentMenu();
    string secondInput = Console.ReadLine();
    if (secondInput != "0")
    {
        switch (secondInput)
        {
            case "1":
                departmentService.AddAsync(DepartmentCrud.CreateDepartment());
                Console.WriteLine("Done!");
                break;
            case "2":
                Console.WriteLine(departmentService.DisplayDepartmentInfoByIdAsync(DepartmentCrud.GetDepartmentById()).Result);
                break;
            case "3":
                departmentService.UpdateAsync(DepartmentCrud.UpdateDepartment());
                Console.WriteLine("Done");
                break;
            case "4":
                List<int> departmentIds = departmentService.TopDepartmentOfTheMonthInfoAsync().Result;
                foreach (var id in departmentIds)
                {
                    Console.WriteLine(departmentService.DisplayDepartmentInfoByIdAsync(id).Result);
                    Console.WriteLine();
                }
                Console.WriteLine("Done!");
                break;
            case "5":
                departmentService.DeleteAsync(DepartmentCrud.GetDepartmentById());
                Console.WriteLine("Done!");
                break;
            default: break;
        }
        Console.ReadKey();
        Console.Clear();
    }
}




