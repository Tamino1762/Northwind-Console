using System;


public class DeleteCategory
{
	public Delete()
	{
        var db = new NorthwindContext();
        var query = db.Categories.OrderBy(p => p.CategoryId);

        Console.WriteLine("Select the category ID you want to delete:");
        foreach (var item in query)
        {
            Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
        }
        int id = int.Parse(Console.ReadLine());
        Console.Clear();
        logger.Info($"CategoryId {id} selected");
        Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);

        db.Categories.Remove(category);
        db.SaveChanges();
        logger.Info($"Category Id {id} deleted");
    }
}
