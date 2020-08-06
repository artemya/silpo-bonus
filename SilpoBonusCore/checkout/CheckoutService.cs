using System.Collections.Generic;

namespace SilpoBonusCore.checkout
{
    public class CheckoutService {
        private Check check;
        public void OpenCheck() {        
            check = new Check(); 
        }    
        public void AddProduct(Product product) {
            if(check == null)
            {
                OpenCheck();
            }
            check.AddProduct(product);
        }
        public Check CloseCheck() 
        {
            Check closedCheck = check;
            check = null;
            return closedCheck;
        }
        public void UseOffer(AnyGoodsOffer offer) 
        {
            if (offer is FactorByCategoryOffer)
            {
                FactorByCategoryOffer fOffer = (FactorByCategoryOffer)offer;
                int points = check.GetCostByCategory(fOffer.category);
                // check.AddPoints(14);
                check.AddPoints(offer.points * (fOffer.factor - 1));
            }
            if (offer.totalCost <= check.GetTotalCost())
            {
                check.AddPoints(offer.points);
            }
            // if (offer in)
        }
    }
}