using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthwindConsole.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "YO - Enter the name!")]// with custom message
        public string CategoryName { get; set; }

        //[StringLength(500)]//allows only 500 chars
        public string Description { get; set; }

        // For Product ID
        public virtual List<Product> Products { get; set; } // one to many category -> products
        // (virtual = Relationship -- Doesn't load unless we want it)
    }
}
