using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

namespace NorthwindConsole.Models
{
    public class EditProductName
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public void EditName()
        {
         var db = new NorthwindContext();
         var pQuery = db.Products.OrderBy(p => p.ProductID);
         //select product
         Console.WriteLine("Select the Product ID you want to edit:");
         foreach (var item in pQuery)
         {
             Console.WriteLine($"{item.ProductID}) {item.ProductName}");
         }
         int productId = int.Parse(Console.ReadLine());
         Product prod = db.Products.FirstOrDefault(p => p.ProductID == productId);
         //Console.Clear();
         logger.Info($"ProductId {productId} selected");
         //edit name
         Console.WriteLine("Enter the name of the product");
         var name = Console.ReadLine();
         prod.ProductName = name;
         db.SaveChanges();
         logger.Info("Product Name changed.");
        }
    }
}
