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
            throw new NotImplementedException();
        }

        public void DeleteToDoItem(int no)
        {
            int index = _toDoItems.FindIndex(x=> x._no == no);
            _toDoItems.RemoveAt(index);
        }

        public void EditToDoItem(int no, string title, string description, DateTime deadline)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> FIlterToDoItems(ToDoItemStatus status, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public void GetAllDelayedTasks()
        {
            throw new NotImplementedException();
        }

        public void GetAllToDoItems()
        {
            foreach (var item in ToDoItems)
            {
                Console.WriteLine($"{item._no} - {item.Title} - {item.Description} - {item.Deadline} - {item.Status} - {item.StatusChangedAt}");
            }
        }

        public ToDoItemStatus GetAllToDoItemsByStatus(ToDoItemStatus status)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> SearchToDoItems(string input)
        {
            List<ToDoItem> newToDoItems = _toDoItems.FindAll(x => x.Title.Contains(input));
            return newToDoItems;
        }
    }
}
