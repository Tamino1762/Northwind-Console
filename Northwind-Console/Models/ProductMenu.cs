using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using System.Threading.Tasks;

namespace NorthwindConsole.Models
{
    //add new records to the products table
    //edit a specific record from the products table
    // display all records in the products table(product name only) user decides if they want to see all products, discontinued products, or active (not discontinued) products.  Discontinued products should be distinguished from active products.
    // display a specific product (all products should be displayed
/*The book has stuff on queries don't forget*/
//be sure to use Nlog
    public class ProductMenu
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private string choice;
        DisplayProducts displayProducts = new DisplayProducts();
        AddProduct addProduct = new AddProduct();

        public void Menu()
        {
            Console.WriteLine("1) Display Products");
            Console.WriteLine("2) Add a new Product");
            Console.WriteLine("3) Display Category and related products");
            Console.WriteLine("4) Display all Categories and their related products");
            Console.WriteLine("5) Edit the Product name");
            Console.WriteLine("6) Delete a Product");
            Console.WriteLine("\"q\" to quit");
            choice = Console.ReadLine();
            Console.Clear();
            logger.Info($"Option {choice} selected");

            switch (choice)
            {
                case ("1"):
                    displayProducts.Display();
                    break;
                case ("2"):
                    addProduct.Add();
                    break;
            }
        }
    }
}
