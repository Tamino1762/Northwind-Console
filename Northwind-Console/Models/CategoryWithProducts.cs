using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;


public class CategoryWithProducts
{
    private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public void View()
	{
        var db = new NorthwindContext();
        var query = db.Categories.Include("Products").OrderBy(p => p.CategoryId);
        Console.WriteLine("Select the Category ID you want to view:");
        foreach (var item in query)
        {
            Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
        }
        int id = int.Parse(Console.ReadLine());
        logger.Info($"CategoryId {id} selected");
        Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
        Console.WriteLine($"Category: {category.CategoryName}\nProducts: ");

        foreach (Product p in category.Products)
        {
            Console.WriteLine($"  {p.ProductName}");
        }

        Console.WriteLine();

    }
}
