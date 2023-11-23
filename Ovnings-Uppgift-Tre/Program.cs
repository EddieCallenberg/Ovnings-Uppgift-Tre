internal class Program
{
    private static void Main(string[] args)
    {
        List<string> toDoList = new List<string>();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("-----------------------------------------");
            PrintToDoList(toDoList);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. Add task to do to the list");
            Console.WriteLine("2. Mark a task as done");
            Console.WriteLine("3. Clear the list of all tasks");
            Console.WriteLine("4. Exit");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    AddToList(toDoList);
                    break;
                case 2:
                    MarkDone(toDoList);
                    break;
                case 3:
                    toDoList.Clear();
                    Console.Clear();
                    Console.WriteLine("List has been cleared.");
                    break;
                case 4:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }
        }
    }

    public static void AddToList(List<string> toDoList)
    {
        Console.Clear();
        Console.WriteLine("Enter what you would like to add to the list");
        string? newTaskToDo = Console.ReadLine();
        if (string.IsNullOrEmpty(newTaskToDo))
        {
            Console.WriteLine("Cannot be empty, please try again.");
        }
        else
        {
            toDoList.Add(newTaskToDo);
            Console.Clear();
            Console.WriteLine(toDoList.LastOrDefault() + " Was added to the list");
        }
    }

    public static void MarkDone(List<string> toDoList)
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------");
        PrintToDoList(toDoList);
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Enter the number of the task you wish to mark as done.");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= toDoList.Count)
        {
            string task = toDoList[taskNumber - 1];
            toDoList[taskNumber - 1] = $"{task} - Done";
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{task} marked as done");
        }
        else
        {
            Console.WriteLine("Invalid number, try again");
        }
    }

    public static void PrintToDoList(List<string> toDoList)
    {
        Console.WriteLine("To-do list");
        if (toDoList.Count > 0)
        {
            int toDoListItemNumber = 1;
            foreach (string taskToDo in toDoList)
            {
                Console.WriteLine($"{toDoListItemNumber}. {taskToDo}");
                toDoListItemNumber++;
            }
        }
        else
        {
            Console.WriteLine("To-do list is empty");
        }
    }
}