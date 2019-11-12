using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

public class CategoryMenu
    {
        private string choice;
        ViewCategory view = new ViewCategory();
        AddCategory addCategory = new AddCategory();
        CategoryWithProducts categoryWithProducts = new CategoryWithProducts();
        DisplayAllCat displayAllCat = new DisplayAllCat();

	    public Menu()
	    {
            Console.WriteLine("1) Display Categories");
            Console.WriteLine("2) Add Category");
            Console.WriteLine("3) Display Category and related products");
            Console.WriteLine("4) Display all Categories and their related products");
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
                default:
                    System.Console.WriteLine("Please enter a valid number");
                    logger.Error("Invaid Entry.");
            }
        }
    }

