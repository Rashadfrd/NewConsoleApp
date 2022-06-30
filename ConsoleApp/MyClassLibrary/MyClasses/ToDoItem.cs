using MyClassLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary.MyClasses
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            _totalCount++;
            this.No = _totalCount;
            this.Status = ToDoItemStatus.ToDo;
        }

        public static int _totalCount { get; set; }
        public int No { get; }
        public ToDoItemStatus Status;
        public string Title;
        public string Description;
        public DateTime Deadline;
        public DateTime StatusChangedAt;
    }
}
