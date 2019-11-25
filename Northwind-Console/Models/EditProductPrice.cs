using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

namespace NorthwindConsole.Models
{
    public class EditProductPrice
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void EditPrice()
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

            Console.WriteLine("Enter the price per unit");
            var price = decimal.Parse(Console.ReadLine());
            product.UnitPrice = price;
            db.SaveChanges();
            logger.Info($"Price per unit changed to {price}.");
        }
    }
}
