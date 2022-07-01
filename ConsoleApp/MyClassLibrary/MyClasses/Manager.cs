using MyClassLibrary.Enum;
using MyClassLibrary.Exceptions;
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
            int index = _toDoItems.FindIndex(x => x.No == no);
            _toDoItems[index].Status = status;
            _toDoItems[index].StatusChangedAt = DateTime.Now;
            Console.WriteLine("Status ugurla deyisdirildi!");
        }

        public void DeleteToDoItem(int no)
        {
            int index = _toDoItems.FindIndex(x=> x.No == no);
            _toDoItems.RemoveAt(index);
            Console.WriteLine("Ugurla silindi!");
        }

        public void EditToDoItem(int no, string title, string description, DateTime? deadline)
        {
            int index = _toDoItems.FindIndex(x => x.No == no);

            if (title!=null)
                ToDoItems[index].Title = title;

            if (description != null)
                ToDoItems[index].Description = description;

            if (deadline != null)
                ToDoItems[index].Deadline = (DateTime)deadline;
            Console.WriteLine("Deyisiklikler ugurla heyata kecirildi");
        }

        public List<ToDoItem> FIlterToDoItems(ToDoItemStatus status, DateTime fromDate, DateTime toDate)
        {
            List<ToDoItem> toDoItems = _toDoItems.FindAll(x => x.Status == status && x.Deadline.Date > fromDate && x.Deadline.Date > toDate);
            return toDoItems;
        }

        public List<ToDoItem> GetAllDelayedTasks()
        {
            List<ToDoItem> toDoItems = _toDoItems.FindAll(x => x.Deadline < DateTime.Now && x.Status != ToDoItemStatus.Done);
            return toDoItems;
        }

        public List<ToDoItem> GetAllToDoItems()
        {
            return _toDoItems;
        }

        public List<ToDoItem> GetAllToDoItemsByStatus(ToDoItemStatus status)
        {
            List<ToDoItem> toDoItems = _toDoItems.FindAll(x => x.Status == status);
            return toDoItems;
        }

        public List<ToDoItem> SearchToDoItems(string input)
        {
            List<ToDoItem> newToDoItems = _toDoItems.FindAll(x => x.Title.Contains(input));
            return newToDoItems;
        }

        bool check = false;
        public int IsNumberExist(int no)
        {
            foreach (var item in _toDoItems)
            {
                if (item.No == no)
                {
                    check = true;
                    break;
                }
            }
            if (check == true)
                return no;
            else
                throw new NumberIsWrongException("Bu nomrede tapsiriq yoxdur");
        }

    }
}
