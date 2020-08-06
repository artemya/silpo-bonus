using System;
using System.Collections.Generic;

namespace SilpoBonusCore.checkout
{
    public class Check 
    {
        private List<Product> products = new List<Product>();
        
        public int getTotalCost() 
        {
            int totalCost = 0;
            foreach(Product product in this.products)
            {
                totalCost += product.price;
            }
            return totalCost;
        }
        public int getTotalPoints() 
        {
            return getTotalCost();
        }
        internal void AddProduct(Product product) 
        {
            products.Add(product);
        }
    }
}