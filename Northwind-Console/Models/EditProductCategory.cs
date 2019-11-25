using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

namespace NorthwindConsole.Models
{
    class EditProductCategory
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void EditCategory()
        {
            var db = new NorthwindContext();
            var query = db.Categories.OrderBy(c => c.CategoryId);
            var pQuery = db.Products.OrderBy(p => p.ProductID);
            //select product
            Console.WriteLine("Select the Product ID you want to edit:");
            foreach (var item in pQuery)
            {
                Console.WriteLine($"{item.ProductID}) {item.ProductName}");
            }
            int productId = int.Parse(Console.ReadLine());
            Product product = db.Products.FirstOrDefault(p => p.ProductID == productId);
            // edit category
            Console.WriteLine("Select the category ID you want to add the product to:");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
            }

            int catId = int.Parse(Console.ReadLine());
            product.CategoryId = catId;
            db.SaveChanges();
            logger.Info($"CategoryId {catId} selected");
            logger.Info("Category changed.");
        }
    }
}
