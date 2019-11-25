using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindConsole.Models
{
    public class DisplayProducts
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Display()
        {
            var db = new NorthwindContext();
            var query = db.Products.OrderBy(p => p.ProductName);

            Console.WriteLine($"{query.Count()} records returned");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.ProductName}");
            }
        }
        
    }
}
