using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Capstone2_Task_List
{
    class Tasks
    {
        //Variable instances or fields
        private string name;
        private string description;
        private DateTime dueDate;
        private bool complete;


        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public bool Complete
        {
            get { return complete; }
            set { complete = value; }
        }



        //Constructors
        public Tasks()
        {

        }

        public Tasks(string _name, string _description, DateTime _dueDate, bool _complete)
        {
            Name = _name;
            Description = _description;
            DueDate = _dueDate;
        }

        //Method to Display menu
        public static void DisplayMenu()
        {
            Console.WriteLine($"1.List tasks\n2.Add task\n3.Delete task\n4.Mark task complete\n5.Quit");
        }


        //Method for user input
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }


        //Method to display Updated Tasklist 
        public static void DisplayTasks(List<Tasks> list)
        {
            int taskNumber = 1;
            foreach (Tasks t in list)
            {
                Console.WriteLine($"{taskNumber++}.\t{t.name}\t{t.dueDate.ToShortDateString()}\t{t.complete} \t{ t.description}");
            }
        }


        //Method to Add New Task To The List
        public static List<Tasks> AddToList(List<Tasks> addList)
        {
            List<Tasks> tempList = new List<Tasks>(addList);
            Console.WriteLine("ADD TASK");

            Console.WriteLine("Please enter Team member Name:");
            string teamMemberName = Console.ReadLine();

            Console.WriteLine("Please enter Task Description:");
            string taskDescription = Console.ReadLine();

            Console.WriteLine("Please enter Task Due Date:");
            DateTime taskDuedate = DateTime.Parse(Console.ReadLine());

            tempList.Add(new Tasks { name = teamMemberName, description = taskDescription, dueDate = taskDuedate, complete = false });

            Console.WriteLine("Task Entered!");

            return tempList;
        }

        //Method to Delete Task from the List
        public static List<Tasks> DeleteFromList(List<Tasks> deleteList)
        {
            List<Tasks> tempList = new List<Tasks>(deleteList);


            int taskNumber = ValidateTaskNumber(tempList, "Please enter the Task Number you want to delete:");


            Console.WriteLine($"You have selected below task:\n{taskNumber}.  {tempList[taskNumber - 1].name}  {tempList[taskNumber - 1].dueDate.ToShortDateString()}  {tempList[taskNumber - 1].complete}  {tempList[taskNumber - 1].description}");

            string areSure = GetUserInput("Are you sure you want to delete this task?").ToLower();
            if (areSure != "y")
            {
                return tempList;
            }

            tempList.RemoveAt(taskNumber - 1);

            Console.WriteLine("Task Deleted!");

            return tempList;
        }

        //Method to Mark the Task Complete
        public static List<Tasks> MarkComplete(List<Tasks> markList)
        {
            List<Tasks> tempList = new List<Tasks>(markList);

            int taskNumber = ValidateTaskNumber(tempList, "Please enter the Task Number you want to mark complete:");

            Console.WriteLine($"You have selected below task:\n{taskNumber}.  {tempList[taskNumber - 1].name}  {tempList[taskNumber - 1].dueDate.ToShortDateString()}  {tempList[taskNumber - 1].complete}  {tempList[taskNumber - 1].description}");

            string areSure = GetUserInput("Are you sure you want to mark this task complete?").ToLower();
            if (areSure != "y")
            {
                return tempList;
            }

            tempList[taskNumber - 1].complete = true;

            Console.WriteLine("Task Marked Completed!");

            return tempList;
        }

        //Method to validate task number entered by user
        public static int ValidateTaskNumber(List<Tasks> taskList, string message)
        {
            string userInput = GetUserInput(message);

            if (!(userInput.All(char.IsDigit)) || 
                (int.Parse(userInput) < 1 || int.Parse(userInput) > taskList.Count))
            { 
                Console.Write("Invalid number entry, ");

                return ValidateTaskNumber(taskList, message);
            }
            
            return int.Parse(userInput);
        }


        //Method to ask user if they want to continue
        public static bool KeepGoing(string message, string option1, string option2)
        {
            string keepGoing = GetUserInput(message).ToLower();
            if (keepGoing == option1)
            {
                return false;
            }
            else if (keepGoing == option2)
            {
                return true;
            }
            else
            {
                return KeepGoing("Not valid! " + message, option1, option2);
            }
        }
    }
}

