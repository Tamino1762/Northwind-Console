using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindConsole.Models
{
    public class DisplayInactive
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public void DisplayNotActive()
        {
            var db = new NorthwindContext();
            var query = db.Products.Where(p => p.Discontinued).OrderBy(p => p.ProductName);

            Console.WriteLine($"{query.Count()} records returned");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.ProductName} || Discontinued: {item.Discontinued = true}");
            }
            logger.Info("Discontinued products displayed.");
        }
    }
}
