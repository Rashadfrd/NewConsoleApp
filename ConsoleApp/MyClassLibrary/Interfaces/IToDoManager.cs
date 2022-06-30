using MyClassLibrary.Enum;
using MyClassLibrary.MyClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary.Interfaces
{
    interface IToDoManager
    {
        List<ToDoItem> ToDoItems { get; }
        void AddToDoItems(ToDoItem toDoItem);
        void GetAllToDoItems();
        void GetAllDelayedTasks();
        void ChangeToDoItemStatus(int no, ToDoItemStatus status);
        void EditToDoItem(int no, string title, string description, DateTime deadline);


    }
}
