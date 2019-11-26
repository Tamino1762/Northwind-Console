using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindConsole.Models
{
    public class DisplaySpecificProduct
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void DisplaySpecific()
        {
            var db = new NorthwindContext();
            var pQuery = db.Products.OrderBy(p => p.ProductID);
            //select product
            Console.WriteLine("Select the Product ID you want to view:");
            foreach (var item in pQuery)
            {
                Console.WriteLine($"{item.ProductID}) {item.ProductName}");
            }
            int productId = int.Parse(Console.ReadLine());
            logger.Info($"Product Id {productId} selected");
            Product product = db.Products.FirstOrDefault(p => p.ProductID == productId);
            Console.WriteLine($"Product: ID: " +
                              $"{product.ProductID} Name: {product.ProductName}\nCategory: {product.CategoryId}\nSupplier: {product.SupplierId}\nQuantity per unit: {product.QuantityPerUnit}\nUnit Price ${product.UnitPrice}\nUnits in Stock: {product.UnitsInStock}\nUnits on Order: {product.UnitsOnOrder}\nReorder Level: {product.ReorderLevel}\nDiscontinued: {product.Discontinued}");
            Console.WriteLine("_______________________________________________________________");
        }
    }
}
