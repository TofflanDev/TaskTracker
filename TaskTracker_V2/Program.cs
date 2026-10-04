namespace TaskTracker_V2
{
    internal class Program
    {
          static int id = 0;
        static void Main(string[] args)
        {
            List<TaskItem> taskList = new List<TaskItem>();
            //DEBUG
            //taskList.Add(new TaskItem { TaskID = 1, Title = "Buy Milk", IsCompleted = false });
            //taskList.Add(new TaskItem { TaskID = 2, Title = "Buy SL", IsCompleted = false });
            //taskList.Add(new TaskItem { TaskID = 3, Title = "Buy Candy", IsCompleted = false });
            while (true)
            {


                Console.WriteLine("\nTask Tracker\n============================\n");
                Console.WriteLine("\n1. Add Task\n2. View Tasks\n3. Complete Task\n4. Exit\n");


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
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

        }

        static public void AddTask(List<TaskItem> list)
        {
            
            Console.WriteLine("\nEnter task title: \n");
            id++;
            string userInputTitle = Console.ReadLine();
            list.Add(new TaskItem { TaskID = id, Title = userInputTitle, IsCompleted = false });
            Console.WriteLine("\nTask Added!\n");

        }
        static public void ViewTasks(List<TaskItem> list)
        {
            foreach (var task in list)
            {
                string completedStatus = task.IsCompleted ? "X" : " ";
                Console.WriteLine($"[{completedStatus}] {task.TaskID} - {task.Title} ");
            }
        }
        static public bool CompleteTask(List<TaskItem> list)
        {

            Console.WriteLine("\nAll tasks: \n");
            foreach (var task in list)
            {
                string completedStatus = task.IsCompleted ? "X" : " ";
                Console.WriteLine($"\n[{completedStatus}] {task.TaskID} - {task.Title} ");
            }

            Console.WriteLine("\nEnter task ID to mark as completed: \n");


            if (!int.TryParse(Console.ReadLine(), out int taskID))
            {
                Console.WriteLine("\nInvalid input.\n");
                return false;
            }

            TaskItem taska = list.Find(t => t.TaskID == taskID);

            if (taska != null)
            {

                taska.IsCompleted = true;
                Console.WriteLine("\nTask marked as completed!\n");
                string completedStatus = taska.IsCompleted ? "X" : " ";
                Console.WriteLine($"[{completedStatus}] {taska.TaskID} - {taska.Title}");
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
