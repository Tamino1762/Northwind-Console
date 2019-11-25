using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;


public class ViewCategory 
{
    private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public void Display()
	{
        var db = new NorthwindContext();
        var query = db.Categories.OrderBy(p => p.CategoryName);

        Console.WriteLine($"{query.Count()} records returned");
        foreach (var item in query)
        {
            Console.WriteLine($"{item.CategoryName} - {item.Description}");
        }

        logger.Info("Products viewed");
    }
}
