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
    EditProductCategory editProductCategory = new EditProductCategory();
    DeleteProduct deleteProduct = new DeleteProduct();

    public void Delete()
	{
        var db = new NorthwindContext();
        var query = db.Categories.Include("Products").OrderBy(p => p.CategoryId);

        Console.WriteLine("Select the category ID you want to delete:");
        foreach (var item in query)
        {
            Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
        }
        int id = int.Parse(Console.ReadLine());
        Console.Clear();
        logger.Info($"CategoryId {id} selected");
        Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
        if (category.Products != null)
        {
            Console.WriteLine("You must first update or delete the products in the category you wish to delete");
            do
            {
                Console.WriteLine("Please choose an action");
                Console.WriteLine("1) Edit product category");
                Console.WriteLine("2) Delete a product");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    editProductCategory.EditCategory();
                }
                else
                {
                    deleteProduct.Delete();
                }
            } while (category.Products != null);

        }
        else { 
            db.Categories.Remove(category);
            db.SaveChanges();
            logger.Info($"Category Id {id} deleted");
        }
    }
}
