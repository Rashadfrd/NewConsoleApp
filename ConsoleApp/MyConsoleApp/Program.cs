using MyClassLibrary.Enum;
using MyClassLibrary.MyClasses;
using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            manager.AddToDoItems(new ToDoItem { Title = "akif", Description = "kakas" });
            manager.AddToDoItems(new ToDoItem { Title = "makif", Description = "kakkkkas" });
            manager.AddToDoItems(new ToDoItem { Title = "zakif", Description = "makas" });
            manager.AddToDoItems(new ToDoItem { Title = "lakif", Description = "akas" });


            foreach (var item in manager.ToDoItems)
            {
                Console.WriteLine($"{item.No} - {item.Title} - {item.Description} - {item.Status}");
            }

            manager.ChangeToDoItemStatus(1, ToDoItemStatus.Done);

            foreach (var item in manager.ToDoItems)
            {
                Console.WriteLine($"{item.No} - {item.Title} - {item.Description} - {item.Status}");
            }


        }
    }
}
