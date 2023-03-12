using EmployeeManagement.Contracts.DTOs.Employee;
using EmployeeManagement.Contracts.DTOs.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.CRUD
{
    public static class TaskCrud
    {
        public static TaskWithoutIdDto CreateTask()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Assignee ID: ");
            int assigneeId = int.Parse(Console.ReadLine());
            Console.Write("Due date (yyyy-MM-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            return new TaskWithoutIdDto()
            {
                Title = title,
                Description = description,
                AssigneeId = assigneeId,
                DueDate = dueDate
            };
        }

        public static TaskWithIdDto UpdateTask()
        {
            Console.Write("Current ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("New title: ");
            string title = Console.ReadLine();
            Console.Write("New description: ");
            string description = Console.ReadLine();
            Console.Write("New assignee ID: ");
            int assigneeId = int.Parse(Console.ReadLine());
            Console.Write("New due date (yyyy-MM-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            return new TaskWithIdDto()
            {
                Id = id,
                Title = title,
                Description = description,
                AssigneeId = assigneeId,
                DueDate = dueDate
            };
        }
        public static int GetTaskById()
        {
            Console.Write("Id: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
