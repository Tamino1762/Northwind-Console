using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

public class EditCatName
{
	public Edit()
	{
        var db = new NorthwindContext();
        var query = db.Categories.OrderBy(p => p.CategoryId);

        Console.WriteLine("Select the category ID you want to edit:");
        foreach (var item in query)
        {
            Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
        }
        int id = int.Parse(Console.ReadLine());
        Console.Clear();
        logger.Info($"CategoryId {id} selected");
        Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);

        Console.WriteLine("Enter the new category name:");
        var name = Console.ReadLine();
        logger.Info($"Category Name {name} entered");

        category.CategoryName = name;
        db.SaveChanges();
        logger.Info($"Category Name {name} updated");

    }
}
