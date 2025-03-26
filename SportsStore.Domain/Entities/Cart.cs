using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Domain.Entities
	{

    public class Cart
        {
        private List<CartItem> items = new List<CartItem>();
        public void AddItem(Product product, int quantity)
            {
            CartItem cartItem = items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);

            if (cartItem != null)
                {
                cartItem.Quantity += quantity;
                }
            else
                {
                items.Add(new CartItem { Product = product, Quantity = quantity });

                }
            }

        public void RemoveItem(Product product)
            { 
            items.RemoveAll(p => p.Product.ProductId == product.ProductId);
            }

        public decimal ComputeTotalAmount()
            {
            return items.Sum(p => p.Product.Price * p.Quantity);

            }

        public void ClearCart() { items.Clear(); }

        public IEnumerable<CartItem> GetCartItems()
            {
            return items;
            }

        public class CartItem
            {
            public Product Product { get; set; }
            public int Quantity { get; set; }
            }
        }
	}