using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* The database did not like when I wanted to edit the ID*/
namespace NorthwindConsole.Models
{
    public class EditCatId 
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void EditId()
        {
            var db = new NorthwindContext();
            var query = db.Categories.OrderBy(p => p.CategoryId);

            Console.WriteLine("Select the category ID you want to edit:");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
            }
            int id = int.Parse(Console.ReadLine());
            logger.Info($"CategoryId {id} selected");
            Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);

            Console.WriteLine("Enter the new category ID:");
            var newID = int.Parse(Console.ReadLine());
            logger.Info($"Category Name {newID} entered");

            category.CategoryId = newID;
            db.SaveChanges();
            logger.Info($"Category Name {newID} updated");
        }
    }
}
