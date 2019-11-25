using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

namespace NorthwindConsole.Models
{
    public class EditCategoryMenu
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Menu()
        {
            EditCatName editCatName = new EditCatName();
            EditCatDescr editCatDescr = new EditCatDescr();
            string choice;

            Console.WriteLine("What would you like to edit?");
            Console.WriteLine("1) Category Name");
            Console.WriteLine("2) Category Description");

            choice = Console.ReadLine();

            switch (choice)
            {
                case ("1"):
                    editCatName.Edit();
                    break;
                case ("2"):
                    editCatDescr.Edit();
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    logger.Error("Invalid Selection");
                    break;
            }
        }
    }
}
