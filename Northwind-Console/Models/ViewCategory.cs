using System;


public class ViewCategory 
{
	public Display()
	{
        var db = new NorthwindContext();
        var query = db.Categories.OrderBy(p => p.CategoryName);

        Console.WriteLine($"{query.Count()} records returned");
        foreach (var item in query)
        {
            Console.WriteLine($"{item.CategoryName} - {item.Description}");
        }
    }
}
