﻿using System;
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
                    categoryMenu.Menu();
                    /*Console.WriteLine("1) Display Categories");
                    Console.WriteLine("2) Add Category");
                    Console.WriteLine("3) Display Category and related products");
                    Console.WriteLine("4) Display all Categories and their related products");
                    Console.WriteLine("\"q\" to quit");
                    choice = Console.ReadLine();
                    Console.Clear();
                    logger.Info($"Option {choice} selected");*/
                    if (choice == "1")
                    {
                       

                        /*var db = new NorthwindContext();
                        var query = db.Categories.OrderBy(p => p.CategoryName);

                        Console.WriteLine($"{query.Count()} records returned");
                        foreach (var item in query)
                        {
                            Console.WriteLine($"{item.CategoryName} - {item.Description}");
                        }*/
                    }
                    else if (choice == "2")
                    {
                        
                        Category category = new Category();

                        Console.WriteLine("Enter Category Name:");
                        category.CategoryName = Console.ReadLine();

                        Console.WriteLine("Enter the Category Description:");
                        category.Description = Console.ReadLine();

                        var db = new NorthwindContext();
                        db.Categories.Add(category); // added later
                        db.SaveChanges(); //added later

                        foreach (var validationResult in db.GetValidationErrors())
                        {
                            foreach (var error in validationResult.ValidationErrors)
                            {
                                logger.Error(
                                    "Entity Property: {0}, Error {1}",
                                    error.PropertyName,
                                    error.ErrorMessage);
                            }
                        }

                        
                        

                        // !!! Use the foreach db.validation error thing here (see notebook/article)

                    }
                    else if (choice == "3")
                    {
                        var db = new NorthwindContext();
                        var query = db.Categories.OrderBy(p => p.CategoryId);

                        Console.WriteLine("Select the category whose products you want to display:");
                        foreach (var item in query)
                        {
                            Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
                        }

                        int id = int.Parse(Console.ReadLine());
                        Console.Clear();
                        logger.Info($"CategoryId {id} selected");
                        Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
                        Console.WriteLine($"{category.CategoryName} - {category.Description}");
                        foreach (Product p in category.Products)
                        {
                            Console.WriteLine(p.ProductName);
                        }
                    }
                    else if (choice == "4")
                    {
                        var db = new NorthwindContext();
                        var query = db.Categories.Include("Products").OrderBy(p => p.CategoryId);
                        foreach (var item in query)
                        {
                            Console.WriteLine($"{item.CategoryName}");
                            foreach (Product p in item.Products)
                            {
                                Console.WriteLine($"\t{p.ProductName}");
                            }
                        }
                    }

                    Console.WriteLine();

                } while (choice.ToLower() != "q");
            }
            catch (DbEntityValidationException e)
            {
                //specific things here
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
        }
    }
}
