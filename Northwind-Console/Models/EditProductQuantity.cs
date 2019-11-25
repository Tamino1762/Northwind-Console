using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

namespace NorthwindConsole.Models
{
    class EditProductQuantity
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void EditQuantity()
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

            Console.WriteLine("Enter the quantity per unit");
            var quantity = Console.ReadLine();
            product.QuantityPerUnit = quantity;
            db.SaveChanges();
            logger.Info("Quantity changed.");

        }
    }
}
