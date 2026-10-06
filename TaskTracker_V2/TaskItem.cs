using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker_V2
{
    internal class TaskItem
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
