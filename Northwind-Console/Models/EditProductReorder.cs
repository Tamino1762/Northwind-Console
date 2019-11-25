using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

namespace NorthwindConsole.Models
{
    class EditProductReorder
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void EditReorder()
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
            //edit reorder level
            Console.WriteLine("Enter the reorder level");
            var reorder = short.Parse(Console.ReadLine());
            product.ReorderLevel = reorder;
            db.SaveChanges();
            logger.Info($"Reorder level changed to {reorder}.");
        }
    }
}
