﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CafebytesModels.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        [Required, StringLength(50), Display(Name = "Product Name")]
        public string ProductName { get; set; } = default!;
        [Required, Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:0.00}")]


        public string? Description { get; set; }


        public string? CategoryName { get; set; }


        public decimal Price { get; set; }
        [Required, StringLength(150)]
        public string Picture { get; set; } = default!;


        public decimal SellPrice { get; set; }


        public bool IsAvailable { get; set; }

        public bool CanDelete { get; set; }
    }
}
