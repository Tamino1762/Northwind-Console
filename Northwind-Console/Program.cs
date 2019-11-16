using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

namespace NorthwindConsole
{
    class MainClass
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            
            logger.Info("Program started");
            try
            {
                CategoryMenu categoryMenu = new CategoryMenu();
                string choice;
                do
                {
                    categoryMenu.Menu();

                } while (choice.ToLower() != "q");
            }
            /*catch (DbEntityValidationException e)
            {
                //specific things here
            }*/
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
        }
    }
}
