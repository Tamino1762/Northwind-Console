using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;


namespace NorthwindConsole.Models
{
    class EditProductSupplier
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void EditSupplier()
        {
            var db = new NorthwindContext();
            var query = db.Categories.OrderBy(c => c.CategoryId);
            var pQuery = db.Products.OrderBy(p => p.ProductID);
            var sQuery = db.Suppliers.OrderBy(s => s.SupplierId);
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
            Console.WriteLine("Select the supplier ID to change the product to:");
            foreach (var item in sQuery)
            {
                Console.WriteLine($"{item.SupplierId}) {item.CompanyName}");
            }

            product.SupplierId = int.Parse(Console.ReadLine());
            logger.Info($"SupplierId {product.SupplierId} selected");
            db.SaveChanges();
            logger.Info($"Supplier changed to {product.SupplierId}.");
        }
    }
}
