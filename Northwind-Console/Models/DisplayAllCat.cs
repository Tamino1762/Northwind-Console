using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DisplayAllCat
{
	public Display()
	{
        var db = new NorthwindContext();
        var query = db.Categories.Include("Products").OrderBy(p => p.CategoryId);
        foreach (var item in query)
        {
            Console.WriteLine($"{item.CategoryName}");
            foreach (Product p in item.Products)
            {
                Console.WriteLine($"\t{p.ProductName}");
            }
        }
    }
}
