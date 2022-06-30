using MyClassLibrary.Enum;
using MyClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary.MyClasses
{
    public class Manager : IToDoManager
    {
        private List<ToDoItem> _toDoItems = new List<ToDoItem>();
        public List<ToDoItem> ToDoItems { get => _toDoItems;}

        public void AddToDoItems(ToDoItem toDoItem)
        {
            _toDoItems.Add(toDoItem);
            Console.WriteLine("Ugurla elave edildi!");
        }

        public void ChangeToDoItemStatus(int no, ToDoItemStatus status)
        {
            int index = ToDoItems.FindIndex(x => x.No == no);
            ToDoItems[index].Status = status;
        }

        public void DeleteToDoItem(int no)
        {
            int index = _toDoItems.FindIndex(x=> x.No == no);
            _toDoItems.RemoveAt(index);
        }

        public void EditToDoItem(int no, string title, string description, DateTime deadline)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> FIlterToDoItems(ToDoItemStatus status, DateTime fromDate, DateTime toDate)
        {
            List<ToDoItem> toDoItems = ToDoItems.FindAll(x => x.Status == status && x.Deadline > fromDate && x.Deadline > toDate);
            return toDoItems;
        }

        public void GetAllDelayedTasks()
        {
            throw new NotImplementedException();
        }

        public void GetAllToDoItems()
        {
            foreach (var item in ToDoItems)
            {
                Console.WriteLine($"{item.No} - {item.Title} - {item.Description} - {item.Deadline} - {item.Status} - {item.StatusChangedAt}");
            }
        }

        public List<ToDoItem> GetAllToDoItemsByStatus(ToDoItemStatus status)
        {
            List<ToDoItem> toDoItems = ToDoItems.FindAll(x => x.Status == status);
            return toDoItems;
        }

        public List<ToDoItem> SearchToDoItems(string input)
        {
            List<ToDoItem> newToDoItems = _toDoItems.FindAll(x => x.Title.Contains(input));
            return newToDoItems;
        }
    }
}
