﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    class Program
    {
        /// <summary>
        /// Добавить новый пункт меню
        /// Добавить Таск на сегодня 
        /// Создать новый класс TodayTask и унаследоваться от Таск у которого в конструкторе будет дата автоматически = сегодня
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ToDo!");
            //TestToDo dataBase = new TestToDo();
            var dataBase = new FileToDo();
            bool flag = true;

            do
            {
                int paragraph = Menu.WriteMenu();

                switch (paragraph)
                {
                    case (int)SelectionAction.AddTask:
                        AddTask(dataBase);

                        break;
                    case (int)SelectionAction.CompletedTask:
                        CompletedTask(dataBase);

                        break;
                    case (int)SelectionAction.ShowTasksWeek:
                        ShowTasksWeek(dataBase);
                        
                        break;
                    case (int)SelectionAction.ShowTasksToday:
                        ShowTasksToday(dataBase);

                        break;
                    case (int)SelectionAction.AddTaskToday:
                        AddTaskToday(dataBase);

                        break;
                    case (int)SelectionAction.Exit:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Error! Try again!");
                        break;
                }
            } while (flag == true);
        }

        static void AddTask(FileToDo dataBase)
        {
            string nameTask = Menu.GetUserString("Name task: ");
            int dayTask = Menu.GetUserInt("Day task: ");
            int monthTask = Menu.GetUserInt("Month task: ");
            int yearTask = Menu.GetUserInt("Year task: ");
            var date = new DateTime(yearTask, monthTask, dayTask);
            Tasks task = new Tasks(nameTask, date);

            try
            {
                dataBase.AddTask(task);
                Menu.ShowMessage("This task has been succesfully added!");
            }
            catch (Exception ex)
            {
                Menu.ShowError(ex.Message);
            }
        }

        static void CompletedTask(FileToDo dataBase)
        {
            Menu.ShowMessage("All unfulfilled tasks of ToDo: ");
            Menu.ShowUnfulfilledTasks(dataBase.GetAllTasks());
            var compTask = Menu.GetTask(dataBase.GetAllTasks());

            try
            {
                dataBase.CompletedTask(compTask);
                Menu.ShowMessage("This task has been successfully completed!");
            }
            catch (Exception ex)
            {
                Menu.ShowError(ex.Message);
            }
        }

        static void ShowTasksWeek(FileToDo dataBase)
        {
            Menu.ShowMessage("All tasks on the week: ");
            Menu.ShowTaskWeek(dataBase.GetAllTasks());
        }

        static void ShowTasksToday(FileToDo dataBase)
        {
            Menu.ShowMessage("All tasks today: ");
            Menu.ShowTasksToday(dataBase.GetAllTasks());
        }

        static void AddTaskToday(FileToDo dataBase)
        {
            string nameT = Menu.GetUserString("Name task: ");
            Tasks taskToday = new Tasks(nameT);

            try
            {
                dataBase.AddTask(taskToday);
                Menu.ShowMessage("This task has been succesfully added!");
            }
            catch (Exception ex)
            {
                Menu.ShowError(ex.Message);
            }
        }
    }
}
