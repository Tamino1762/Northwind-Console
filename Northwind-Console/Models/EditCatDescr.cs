using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindConsole.Models
{
    class EditCatDescr
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Edit()
        {
            var db = new NorthwindContext();
            var query = db.Categories.OrderBy(p => p.CategoryId);

            Console.WriteLine("Select the category ID you want to edit:");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
            }
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            logger.Info($"CategoryId {id} selected");
            Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);

            Console.WriteLine("Enter the new category description:");
            var descr = Console.ReadLine();
            logger.Info($"Category Description {descr} entered");

            category.Description = descr;
            db.SaveChanges();
            logger.Info($"Category Description {descr} updated");

        }
    }
}
