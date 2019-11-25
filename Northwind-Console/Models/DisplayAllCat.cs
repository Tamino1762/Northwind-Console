using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

public class DisplayAllCat
{
    private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public void Display()
	{
        var db = new NorthwindContext();
        var query = db.Products.Where(p => p.Discontinued == false).OrderBy(p => p.CategoryId);
        var cQuery = db.Categories.OrderBy(c => c.CategoryName);
        Console.WriteLine($"{query.Count()} records returned");

        Console.WriteLine("Category References:");
        foreach (var catItem in cQuery)
        {
            Console.WriteLine($"Category: {catItem.CategoryId}\t {catItem.CategoryName}");
        }
        Console.WriteLine("_________________");
        Console.WriteLine();
        foreach (var item in query)
        {
            Console.WriteLine($"Category ID: {item.CategoryId}  \nProduct Name: {item.ProductName} || Discontinued: {item.Discontinued}");
        }
        Console.WriteLine();
        logger.Info("Categories with active products displayed.");

        Console.WriteLine();
    }
}
