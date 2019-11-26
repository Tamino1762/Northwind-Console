using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindConsole.Models
{
    public class DeleteProduct
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Delete()
        {
            var db = new NorthwindContext();
            var pQuery = db.Products.OrderBy(p => p.ProductID);

            Console.WriteLine("Select the product ID you want to delete:");
            foreach (var item in pQuery)
            {
                Console.WriteLine($"{item.ProductID}) {item.ProductName}");
            }

            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            logger.Info($"Product ID {id} selected");
            Product product = db.Products.FirstOrDefault(p => p.ProductID == id);

            db.Products.Remove(product);
            db.SaveChanges();
            logger.Info($"Product ID {id} deleted");
        }
    }
}
