
using EmployeeManagement;



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

void EmployeeMenu()
{
    DisplayMenu.DisplayEmployeeMenu();
    string secondInput = Console.ReadLine();
    while (input != "0")
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
}




