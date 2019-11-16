using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

namespace NorthwindConsole
{
    class MainClass
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            
            logger.Info("Program started");
            try
            {
                CategoryMenu categoryMenu = new CategoryMenu();
                string choice;
                do
                {
                    Console.WriteLine("Which menu would you like to see?");
                    Console.WriteLine("1) Category"); 
                    Console.WriteLine("2) Products");
                    Console.WriteLine("Enter 'q' to quit.");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case ("1"):
                            categoryMenu.Menu();
                            logger.Info("Category menu");
                            break;
                        case ("2"):
                            Console.WriteLine("Products");
                            logger.Info("Products menu");
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice");
                            logger.Error("Invaid Selection");
                            break;
                    }
                } while (choice.ToLower() != "q");
            }
            /*catch (DbEntityValidationException e)
            {
                //specific things here
            }*/
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
        }
    }
}
