using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;


public class CategoryWithProducts
{
	public View()
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

    }
}
