using System;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Linq;
using NLog;
using NorthwindConsole.Models;


    public class AddProduct
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        Product product = new Product();

        public void Add()
	    {
            //select category to add product to
            var db = new NorthwindContext();
            var query = db.Categories.OrderBy(p => p.CategoryId);
            var sQuery = db.Suppliers.OrderBy(s => s.SupplierId);

            Console.WriteLine("Select the category ID you want to add a product to:");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
            }
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            logger.Info($"CategoryId {id} selected");
            Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            product.CategoryId = category.CategoryId;

        //choose a supplier
        Console.WriteLine("Select the supplier ID the product is from:");
        foreach (var item in sQuery)
        {
            Console.WriteLine($"{item.SupplierId}) {item.CompanyName}");
        }
        int supplierID = int.Parse(Console.ReadLine());
        Console.Clear();
        logger.Info($"SupplierId {supplierID} selected");
        Supplier supplier = db.Suppliers.FirstOrDefault(s => s.SupplierId == supplierID);
        product.SupplierId = supplier.SupplierId;

        //add product to selected category
        //s.supplier id = p.supplier id
        Console.WriteLine("Enter the name of the product");
            product.ProductName = Console.ReadLine();

            Console.WriteLine("Enter the quantity per unit");
            product.QuantityPerUnit = Console.ReadLine();

            Console.WriteLine("Enter the price per unit");
            product.UnitPrice = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the units in stock");
            product.UnitsInStock = short.Parse(Console.ReadLine());

            Console.WriteLine("Enter the units on order");
            product.UnitsOnOrder = short.Parse(Console.ReadLine());

            Console.WriteLine("Enter the reorder level");
            product.ReorderLevel = short.Parse(Console.ReadLine());

            db.Products.Add(product);
            db.SaveChanges();
            logger.Info($"{product} added.");
        }
    }
