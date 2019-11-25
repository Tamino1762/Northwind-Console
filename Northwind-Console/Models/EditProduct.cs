using System;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

namespace NorthwindConsole.Models
{
    
    public class EditProduct
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        EditProductName editProductName = new EditProductName();
        EditProductCategory editProductCategory = new EditProductCategory();
        EditProductSupplier editProductSupplier = new EditProductSupplier();
            Product product = new Product();
        string choice;

        public void Edit()
        {
            var db = new NorthwindContext();
            var query = db.Categories.OrderBy(c => c.CategoryId);
            var sQuery = db.Suppliers.OrderBy(s => s.SupplierId);
            var pQuery = db.Products.OrderBy(p => p.ProductID);

            //edit menu
            Console.WriteLine("Select what you would like to change");
            Console.WriteLine("1) Category");
            Console.WriteLine("2) Supplier");
            Console.WriteLine("3) Product Name");
            Console.WriteLine("4) Quantity Per Unit ");
            Console.WriteLine("5) Price Per Unit");
            Console.WriteLine("6) Units in Stock");
            Console.WriteLine("7) Units on Order");
            Console.WriteLine("8) Reorder Level");
            choice = Console.ReadLine();

            switch (choice)
            {
                case ("1"):
                // edit category
                editProductCategory.EditCategory();
                break;
                case ("2"):
                    //edit supplier
                    editProductSupplier.EditSupplier();
                    break;
                case ("3"):
                    //edit name
                    editProductName.EditName();
                    break;
                case ("4"):
                    //edit quantity
                    Console.WriteLine("Enter the quantity per unit");
                    product.QuantityPerUnit = Console.ReadLine();
                    db.SaveChanges();
                    logger.Info("Quantity changed.");
                    break;
                case ("5"):
                    // edit price per unit
                    Console.WriteLine("Enter the price per unit");
                    product.UnitPrice = decimal.Parse(Console.ReadLine());
                    db.SaveChanges();
                    logger.Info("Price per unit changed.");
                    break;
                case ("6"):
                    //edit units in stock
                    Console.WriteLine("Enter the units in stock");
                    product.UnitsInStock = short.Parse(Console.ReadLine());
                    db.SaveChanges();
                    logger.Info("Units in stock changed.");
                    break;
                case ("7"):
                    //edit units on order
                    Console.WriteLine("Enter the units on order");
                    product.UnitsOnOrder = short.Parse(Console.ReadLine());
                    db.SaveChanges();
                    logger.Info("Units on order changed.");
                    break;
                case ("8"):
                    //edit reorder level
                    Console.WriteLine("Enter the reorder level");
                    product.ReorderLevel = short.Parse(Console.ReadLine());
                    db.SaveChanges();
                    logger.Info("Reorder level changed.");
                    break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        logger.Error("Invalid Choice");
                        break;
                    
            }

            db.SaveChanges();
        }
    }
}
