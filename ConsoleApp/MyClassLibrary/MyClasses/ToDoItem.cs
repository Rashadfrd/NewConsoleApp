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
            this._no = _totalCount;
        }

        public static int _totalCount { get; set; }
        public int _no { get; }
        public string Title;
        public string Description;
        public DateTime Deadline;
        public DateTime StatusChangedAt;
    }
}
