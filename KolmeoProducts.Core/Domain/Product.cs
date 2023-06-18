using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolmeoProducts.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }                
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The Price field must be a positive value.")]
        public decimal Price { get; set; }
    }
}
