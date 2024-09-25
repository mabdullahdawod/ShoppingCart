using System;
using System.Collections.Generic;
using ShoppingCart.Modal;
using ShoppingCartShared.DTO;

namespace ShoppingCart.SharedService
{
    public class ProductShareService
    {
        public ProductShareService()
        {
            ShoppingCart = new List<ProductDTO>();
        }

        public int Cardcount { get; private set; } = 0;

        public event Action<int> OnChange;

        public List<ProductDTO> ShoppingCart { get; set; } = new List<ProductDTO>();

        public void AddProduct(ProductDTO item)
        {
            ShoppingCart.Add(item);
            OnChange?.Invoke(ShoppingCart.Count);
        }

        public void RemoveProduct(ProductDTO item)
        {
            ShoppingCart.Remove(item);
            OnChange?.Invoke(ShoppingCart.Count);
        }
        // ese hata dy errors remove kr chec karea
        public List<ProductDTO> GetProducts()
        {
            return ShoppingCart;
        }

        public void ClearCart(ProductDTO product)
        {
            int itemsRemoved = ShoppingCart.RemoveAll(s => s.ProductId == product.ProductId);
            OnChange?.Invoke(ShoppingCart.Count);
        }

    }
}



