using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace NorthwindConsole.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
