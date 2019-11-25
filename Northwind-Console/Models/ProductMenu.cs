using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using System.Threading.Tasks;

namespace NorthwindConsole.Models
{

    //edit a specific record from the products table
    // display all records in the products table(product name only) user decides if they want to see all products, discontinued products, or active (not discontinued) products.  Discontinued products should be distinguished from active products.
    // display a specific product (all products should be displayed
/**** don't forget to fix the category thing to delete products before a category can be deleted*******/
/*The book has stuff on queries don't forget*/
//be sure to use Nlog
    public class ProductMenu
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private string choice;
        DisplayAllProducts displayAllProducts = new DisplayAllProducts();
        ActiveProducts activeProducts= new ActiveProducts();
        DisplayInactive displayInactive = new DisplayInactive();
        AddProduct addProduct = new AddProduct();
        EditProduct editProduct = new EditProduct();

        public void Menu()
        {
            Console.WriteLine("1) Display all Products"); //add see active and discontinued products
            Console.WriteLine("2) Display active Products");
            Console.WriteLine("3) Display discontinued Products");
            Console.WriteLine("4) Add a new Product");
            Console.WriteLine("5) Edit a Product");
            Console.WriteLine("6) Delete a Product");
            Console.WriteLine("\"q\" to quit");
            choice = Console.ReadLine();
            Console.Clear();
            logger.Info($"Option {choice} selected");

            switch (choice)
            {
                case ("1"):
                    displayAllProducts.Display();
                    break;
                case ("2"):
                    activeProducts.DisplayActive();
                    break;
                case ("3"):
                    displayInactive.DisplayNotActive();
                    break;
                case ("4"):
                    addProduct.Add();
                    break;
                case ("5"):
                    editProduct.Edit();
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    logger.Error("Invalid Entry");
                    break;
            }
        }
    }
}
