using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

public class CategoryMenu
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private string choice;
        ViewCategory view = new ViewCategory();
        AddCategory addCategory = new AddCategory();
        CategoryWithProducts categoryWithProducts = new CategoryWithProducts();
        DisplayAllCat displayAllCat = new DisplayAllCat();
        EditCatName editCatName = new EditCatName();
        DeleteCategory deleteCategory = new DeleteCategory();

        public void Menu()
	    {
            Console.WriteLine("1) Display Categories");
            Console.WriteLine("2) Add Category");
            Console.WriteLine("3) Display Category and related products");
            Console.WriteLine("4) Display all Categories and their related products");
            Console.WriteLine("5) Edit the Category name");
            Console.WriteLine("6) Delete a Category");//delete products first?
            Console.WriteLine("\"q\" to quit");
            choice = Console.ReadLine();
            Console.Clear();
            logger.Info($"Option {choice} selected");

            switch (choice)
            {
                case ("1"):
                    view.Display();
                    logger.Info("Display All Categories.");
                    break;
                case ("2"):
                    addCategory.Add();
                    logger.Info("Add a Category.");
                break;
                case ("3"):
                    categoryWithProducts.View();
                    logger.Info("Display Category with Product.");
                break;
                case ("4"):
                    displayAllCat.Display();
                    logger.Info("Display all Categories with Products.");
                break;
                case ("5"):
                    editCatName.Edit();
                    logger.Info("Edit Category");
                break;
                case ("6"):
                    deleteCategory.Delete();
                    logger.Info("Delete Category");
                    break;
                default:
                    System.Console.WriteLine("Please enter a valid number");
                    logger.Error("Invaid Entry.");
                    break;
            }
        }
    }

