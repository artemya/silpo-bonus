using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore.checkout
{
    public class Check 
    {
        private List<Product> products = new List<Product>();
        private List<Offer> offers = new List<Offer>();
        private int points = 0;
        public int GetTotalCost() 
        {
            int totalCost = 0;
            foreach(Product product in this.products)
            {
                totalCost += product.price;
            }
            return totalCost;
        }
        internal void AddProduct(Product product) 
        {
            products.Add(product);
        }
        public int GetTotalPoints() 
        {
            return GetTotalCost() + points;
        }
        public void AddPoints(int points)
        {
            this.points += points;
        }

        public int GetCostByCategory(Category category) 
        {
            return products.Where(product => product.category == category)
                    .Select(product => product.price)
                    .Aggregate(0, (a, b) => a + b);
        }

        internal void UseOffer(Offer offer)
        {
            offers.Add(offer);
        }

        internal void CheckAndApplyOffers()
        {
            foreach(var offer in offers)
            {
                offer.apply(this);
            }
        }
    }
}