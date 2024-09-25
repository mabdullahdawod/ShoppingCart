using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Modal
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ProductImg { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductCategory { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }   
    }
}
