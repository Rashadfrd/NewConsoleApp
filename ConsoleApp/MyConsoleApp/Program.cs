using MyClassLibrary.Enum;
using MyClassLibrary.Exceptions;
using MyClassLibrary.MyClasses;
using System;
using System.Collections.Generic;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            string input;

            do
            {
                Console.WriteLine("\n1.Tapsiriq yarat:");
                Console.WriteLine("2.Butun tapsiriqlara bax:");
                Console.WriteLine("3.Vaxti kecmis tapsiriqlara bax:");
                Console.WriteLine("4.Secilmis statuslu tapsiriqlara bax:");
                Console.WriteLine("5.Tarix intervalina gore axtar:");
                Console.WriteLine("6.Tapsirigin statusunu deyismek:");
                Console.WriteLine("7.Tapsirigi editlemek");
                Console.WriteLine("8.Tapsiriq silmek:");
                Console.WriteLine("9.Tapsiriqlarda axtaris:");
                Console.WriteLine("0.Cixis:");
                Console.WriteLine("\nSeciminizi daxil edin:");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        manager.AddToDoItems(CreateTask());
                        break; 
                    case "2":
                        List<ToDoItem> toDoItems = manager.GetAllToDoItems();
                        foreach (var item in toDoItems)
                        {
                            Console.WriteLine($"{item.No} - {item.Title} - {item.Description} - {item.Deadline} - {item.Status}");
                        }
                        break; 
                    case "3":
                        List<ToDoItem> toDoItems1 = manager.GetAllDelayedTasks();
                        foreach (var item in toDoItems1)
                        {
                            Console.WriteLine($"{item.No} - {item.Title} - {item.Description} - {item.Deadline} - {item.Status}");
                        }
                        break; 
                    case "4":
                        List<ToDoItem> newtoDoItemArr = manager.GetAllToDoItemsByStatus(GetStatus());
                        foreach (var item in newtoDoItemArr)
                        {
                            Console.WriteLine($"{item.No} - {item.Title} - {item.Description} - {item.Deadline} - {item.Status}");
                        }
                        break; 
                    case "5":
                        List<ToDoItem> toDoItems2 = manager.FIlterToDoItems(GetStatus(), GetFromDate(), GetToDate());
                        foreach (var item in toDoItems2)
                        {
                            Console.WriteLine($"{item.No} - {item.Title} - {item.Description} - {item.Deadline} - {item.Status}");
                        }
                        break; 
                    case "6":
                        manager.ChangeToDoItemStatus(GetNumberOfTask(manager), GetStatus());
                        break; 
                    case "7":
                        manager.EditToDoItem(GetNumberOfTask(manager), GetTitle(), GetDescription(), GetDeadline());
                        break; 
                    case "8":
                        manager.DeleteToDoItem(GetNumberOfTask(manager));
                        break; 
                    case "9":
                        List<ToDoItem> newtoDoItems = manager.SearchToDoItems(GetOption());
                        foreach (var item in newtoDoItems)
                        {
                            Console.WriteLine($"{item.No} - {item.Title} - {item.Description} - {item.Deadline} - {item.Status}");
                        }
                        break;
                }
            } while (input!="0");




        }


        static ToDoItem CreateTask()
        {
            Console.WriteLine("1.Tapsirigin basligini daxil edin:");
            string title = Console.ReadLine();
            Console.WriteLine("2.Tapsirigin aciqlamasini daxil edin:");
            string description = Console.ReadLine();
        DeadlineCreating:
            Console.WriteLine("3.Tapsirigin bitmeli oldugu vaxti daxil edin:");
            
            string deadlineStr;
            DateTime deadline;
            do
            {
                deadlineStr = Console.ReadLine();
            } while (!DateTime.TryParse(deadlineStr, out deadline));

            try
            {
                ToDoItem.CheckDeadline(deadline);
            }
            catch (DateTimeIsWrongException exp)
            {
                Console.WriteLine(exp.Message);
                goto DeadlineCreating;
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmeyen xeta bas verdi");
                goto DeadlineCreating;
            }

            ToDoItem toDoItem = new ToDoItem
            {
                Deadline = deadline,
                Description = description,
                Title = title
            };
            return toDoItem;
        }

        static int GetNumberOfTask(Manager manager)
        {
            GettingNumber:
            Console.WriteLine("Uzerinde emeliyyat aparmaq istediyiniz tapsirigin nomresini daxil edin:");
            string noStr;
            int no;
            do
            {
                noStr = Console.ReadLine();
            } while (!int.TryParse(noStr, out no));

            try
            {
                manager.IsNumberExist(no);
            }
            catch (NumberIsWrongException exp)
            {
                Console.WriteLine(exp.Message);
                goto GettingNumber;
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmedik bir xeta bas verdi");
                goto GettingNumber;
            }
            return no;
        }

        static string GetOption()
        {
            Console.WriteLine("Axtaris etmek istediyiniz deyeri daxil edin:");
            string option = Console.ReadLine();
            return option;
        }

        static string GetDescription()
        {
            Console.WriteLine("Yeni aciqlamani daxil edin:");
            string description = Console.ReadLine();
            return description;
        }

        static string GetTitle()
        {
            Console.WriteLine("Yeni basligi daxil edin:");
            string title = Console.ReadLine();
            return title;
        }

        static DateTime GetDeadline()
        {
        DeadlineCreating:
            Console.WriteLine("Tapsirigin bitmeli oldugu yeni vaxti daxil edin:");

            string deadlineStr;
            DateTime deadline;
            do
            {
                deadlineStr = Console.ReadLine();
            } while (!DateTime.TryParse(deadlineStr, out deadline));

            try
            {
                ToDoItem.CheckDeadline(deadline);
            }
            catch (DateTimeIsWrongException exp)
            {
                Console.WriteLine(exp.Message);
                goto DeadlineCreating;
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmeyen xeta bas verdi");
                goto DeadlineCreating;
            }

            return deadline;
        }

        static ToDoItemStatus GetStatus()
        {
            Console.WriteLine("Tapsirigin statusunu daxil edin:");
            foreach (var item in Enum.GetValues(typeof(ToDoItemStatus)))
            {
                Console.WriteLine($"{(byte)item} - {item}");
            }
            string optStr;
            byte opt;
            do
            {
                optStr = Console.ReadLine();
            } while (!byte.TryParse(optStr, out opt) || !Enum.IsDefined(typeof(ToDoItemStatus), opt));

            ToDoItemStatus status = (ToDoItemStatus)opt;
            return status;
        }

        static DateTime GetFromDate()
        {
            Console.WriteLine("Axtaris etmek istediyiniz tarix araligini daxil edin");
            Console.WriteLine("From:");
            string fromDateStr;
            DateTime fromDate;
            do
            {
                fromDateStr = Console.ReadLine();
            } while (DateTime.TryParse(fromDateStr, out fromDate));
            return fromDate;
        }

        static DateTime GetToDate()
        {
            GettinToDate:
            Console.WriteLine("To:");
            string toDateStr;
            DateTime toDate;
            do
            {
                toDateStr = Console.ReadLine();
            } while (!DateTime.TryParse(toDateStr, out toDate));

            try
            {
                ToDoItem.CheckDeadline(toDate);
            }
            catch (DateTimeIsWrongException exp)
            {
                Console.WriteLine(exp.Message);
                goto GettinToDate;
            }
            return toDate;
        }
    }
}
