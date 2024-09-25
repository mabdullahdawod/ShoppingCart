using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartShared.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ProductImgUrl { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductCategory { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        public IFormFile File { get; set; } 

    }
}
