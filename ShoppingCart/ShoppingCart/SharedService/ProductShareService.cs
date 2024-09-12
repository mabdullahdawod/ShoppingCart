using System;
using System.Collections.Generic;
using ShoppingCart.Modal;

namespace ShoppingCart.SharedService
{
    public class ProductShareService
    {
        public ProductShareService()
        {
            ShoppingCart = new List<Product>();
        }


        public int Cardcount { get; private set; } = 0;

        public event Action<int> OnChange;



        // For added products
        public List<Product> ShoppingCart { get; set; } = new List<Product>();

        public void AddProduct(Product item)
        {
            ShoppingCart.Add(item);
            OnChange?.Invoke(ShoppingCart.Count);
        }

        public void RemoveProduct(Product item)
        {
            ShoppingCart.Remove(item);
            OnChange?.Invoke(ShoppingCart.Count);
        }
        // ese hata dy errors remove kr chec karea
        public List<Product> GetProducts()
        {
            return ShoppingCart;
        }














    }
}



