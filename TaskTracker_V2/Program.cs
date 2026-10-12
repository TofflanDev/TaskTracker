using System.Dynamic;

namespace TaskTracker_V2
{
    internal class Program
    {
        static int id = 3;
        static void Main(string[] args)
        {
            List<TaskItem> taskList = new List<TaskItem>();
            //CRUD INC. Create Read Update Delete
            //DEBUG
            taskList.Add(new TaskItem { TaskID = 1, Title = "Buy Milk", IsCompleted = false });
            taskList.Add(new TaskItem { TaskID = 2, Title = "Buy SL", IsCompleted = false });
            taskList.Add(new TaskItem { TaskID = 3, Title = "Buy Candy", IsCompleted = false });
            while (true)
            {


                Console.WriteLine("\nTask Tracker\n============================\n");
                Console.WriteLine("\n1. Add Task" +
                    "\n2. View Tasks" +
                    "\n3. Complete Task" +
                    "\n4. Delete Task" +
                    "\n5. Get Task" +
                    "\n6. Edit Task" +
                    "\n7. Exit\n");


                if (!int.TryParse(Console.ReadLine(), out int userInput))
                {
                    Console.WriteLine("Invalid input.\n");
                    continue;
                }
                else
                    Console.Clear();


                switch (userInput)
                {
                    case 1:
                        AddTask(taskList);
                        break;
                    case 2:
                        ViewTasks(taskList);
                        break;
                    case 3:
                        CompleteTask(taskList);
                        break;
                    case 4:
                        DeleteTask(taskList);
                        break;
                    case 5:
                        GetTask(taskList);
                        break;
                    case 6:
                        EditTask(taskList);
                        break;
                    case 7:
                        return;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

        }

        private static void EditTask(List<TaskItem> taskList)
        {
            Console.WriteLine("All tasks");

            foreach (var item in taskList)
            {
                Console.WriteLine(item);
            }

            if (!int.TryParse(Console.ReadLine(), out int taskID))
            {
                Console.WriteLine("\nInvalid input.\n");
                return;
            }

            TaskItem? taskRef = taskList.Find(t => t.TaskID == taskID);

            if (taskRef == null)
            {
                Console.WriteLine("Can't find task.");
                return;
            }

            Console.WriteLine(taskRef);
            Console.WriteLine("\n-------");
            Console.WriteLine("Enter new name for task:");
            string newName = Console.ReadLine() ?? "NoName";
            taskRef.Title = newName;
            Console.WriteLine("Edit confirmed!");


        }

      
        private static void GetTask(List<TaskItem> taskList)
        {
            Console.WriteLine("Enter Task ID: ");

            if (!int.TryParse(Console.ReadLine(), out int taskID))
            {
                Console.WriteLine("\nInvalid input.\n");
                return;
            }
            
            TaskItem? taskRef = taskList.Find(t => t.TaskID == taskID);

            if (taskRef != null)
            {
                Console.WriteLine(taskRef);
                return;
            }
            else
            {
                Console.WriteLine("Can't find task");
                return;
            }
        }

        static public void DeleteTask(List<TaskItem> taskList)
        {
            Console.WriteLine("All tasks");
            foreach (var item in taskList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nEnter task ID to edit: \n");

            if (!int.TryParse(Console.ReadLine(), out int taskID))
            {
                Console.WriteLine("\nInvalid input.\n");
                return;
            }

            TaskItem? taskItemRef = taskList.Find(t => t.TaskID == taskID);

            if (taskItemRef != null)
            {
                taskList.Remove(taskItemRef);
                Console.WriteLine("\nTask deleted!\n");
                return;

            }
            else
            {
                Console.WriteLine("Can't find task");
                return;
            }

        }

        static public void AddTask(List<TaskItem> list)
        {

            Console.WriteLine("\nEnter task title: \n");
            id++;
            string userInputTitle = Console.ReadLine() ?? "";
            list.Add(new TaskItem { TaskID = id, Title = userInputTitle, IsCompleted = false });
            Console.WriteLine("\nTask Added!\n");

        }
        static public void ViewTasks(List<TaskItem> list)
        {
            foreach (var task in list)
            {
                Console.WriteLine(task);
            }
        }
        static public bool CompleteTask(List<TaskItem> list)
        {

            Console.WriteLine("\nAll tasks: \n");
            foreach (var task in list)
            {
                Console.WriteLine(task);
            }

            Console.WriteLine("\nEnter task ID to mark as completed: \n");


            if (!int.TryParse(Console.ReadLine(), out int taskID))
            {
                Console.WriteLine("\nInvalid input.\n");
                return false;
            }

            TaskItem? taskItemRef = list.Find(t => t.TaskID == taskID);

            if (taskItemRef != null)
            {

                taskItemRef.IsCompleted = true;
                Console.WriteLine("\nTask marked as completed!\n");
                Console.WriteLine(taskItemRef);
                return true;

            }
            else
            {
                Console.WriteLine("Can't find task");
                return false;
            }

        }

    }
}
