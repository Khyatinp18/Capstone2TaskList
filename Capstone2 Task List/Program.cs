using System;
using System.Collections.Generic;

namespace Capstone2_Task_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tasks> tasksList = new List<Tasks>
            {
                new Tasks("Shamita", "Capstone", new DateTime(2020, 2, 10), false),
                new Tasks("Mina", "Lab", new DateTime(2020, 2, 12), false),
                new Tasks("Clayton", "SoftSkill", new DateTime(2020, 2, 15), false),
                new Tasks("Kyle", "Assessment", new DateTime(2020, 2, 20), false),
                new Tasks("James", "Interview", new DateTime(2020, 2, 22), false),
                new Tasks("Hanna", "Presentation", new DateTime(2020, 2, 25), false),
                new Tasks("Cody", "Workshop", new DateTime(2020, 2, 26), false),
                new Tasks("Heather", "Midterm", new DateTime(2020, 2, 27), false),
                new Tasks("Erwin", "Lecture", new DateTime(2020, 2, 28), false),
                new Tasks("Steve", "Demo", new DateTime(2020, 3, 10), false),
            };

            Console.WriteLine("Welcome to the Task Manager!");
            bool wantToQuit = false;
            bool wantToContinue = true;
            while (wantToContinue)
            {
                wantToQuit = false;
                Console.WriteLine("Task Menu:");
                Tasks.DisplayMenu();


                string userChoice = Tasks.GetUserInput("What menu item are you interested in?\n" +
                           "Please enter your selection:").ToLower();


                //Using switch case statements calling different methods for display, add, delete or mark the task complete based on the user input 
                switch (userChoice)
                {
                    case "1":
                    case "list tasks":                        
                        Tasks.DisplayTasks(tasksList);
                        break;
                    case "2":
                    case "add tasks":
                        tasksList = Tasks.AddToList(tasksList);
                        break;
                    case "3":
                    case "delete task":
                        Tasks.DisplayTasks(tasksList);
                        tasksList = Tasks.DeleteFromList(tasksList);
                        Tasks.DisplayTasks(tasksList);
                        break;
                    case "4":
                    case "mark task complete":
                        Tasks.DisplayTasks(tasksList);
                        tasksList = Tasks.MarkComplete(tasksList);
                        Tasks.DisplayTasks(tasksList);
                        break;
                    case "5":
                    case "quit":
                        wantToQuit = true;
                        wantToContinue = false;
                        break;
                    default:  //Validating if you user entered valid number from 1-5 or correct menu iten name                       
                        Console.WriteLine("Invalid entry, please enter valid menu item.");
                        wantToQuit = true;
                        wantToContinue = true;
                        break;
                }

                //asking user if they want to continue
                if (!wantToQuit)
                {
                    wantToContinue = Tasks.KeepGoing($"Would you like to continue (y/n)?", "n", "y");
                }
               

            }
            Console.WriteLine("Thank you for your time, Have a great day!");
            Console.ReadKey();
        }

    }
}
