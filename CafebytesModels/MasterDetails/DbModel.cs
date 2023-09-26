using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CafebytesModels.Auth;

namespace CafebytesModels.MasterDetails
{
    
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required, StringLength(50), Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = default!;
        [Required, StringLength(150)]
        public string Address { get; set; } = default!;
        [Required, StringLength(50)]
        public string Email { get; set; } = default!;
    }
   

   

    public class Product
    {
        public int ProductID { get; set; }


        [Required, StringLength(50), Display(Name = "Product Name")]
        public string ProductName { get; set; } = default!;
        

        public string? Description { get; set; } = default!;


        public string? CategoryName { get; set; }


        [Required, Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Price { get; set; }
        

        public decimal SellPrice { get; set; }


        public string Picture { get; set; } = default!;

        public bool IsAvailable { get; set; }

        public static implicit operator Product(Order v)
        {
            throw new NotImplementedException();
        }
    }

    public class Order
    {

        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public string ProductName { get; set; } = default!;

        public decimal Price { get; set; }

        public string? OrderNumber { get; set; }

        public int Quantity { get; set; }

    }
}
