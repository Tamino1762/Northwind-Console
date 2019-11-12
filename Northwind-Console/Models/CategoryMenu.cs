using System;
 using NLog;

    public class CategoryMenu
    {
        private string choice;
        ViewCategory view = new ViewCategory();

	    public Menu()
	    {
            Console.WriteLine("1) Display Categories");
            Console.WriteLine("2) Add Category");
            Console.WriteLine("3) Display Category and related products");
            Console.WriteLine("4) Display all Categories and their related products");
            Console.WriteLine("\"q\" to quit");
            choice = Console.ReadLine();
            Console.Clear();
            logger.Info($"Option {choice} selected");

            switch (choice)
            {
                case ("1"):
                    view.Display();
                    break;
            }
        }
    }

