using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;


public class DeleteCategory
{
    private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public void Delete()
	{
    var db = new NorthwindContext();
        var query = db.Categories.OrderBy(p => p.CategoryId);

        Console.WriteLine("Select the category ID you want to delete:");
        foreach (var item in query)
        {
            Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
        }
        int id = int.Parse(Console.ReadLine());
        Console.Clear();
        logger.Info($"CategoryId {id} selected");
        Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);

        db.Categories.Remove(category);
        db.SaveChanges();
        logger.Info($"Category Id {id} deleted");
    }
}
