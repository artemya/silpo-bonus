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
            check.CheckAndApplyOffers();
            Check closedCheck = check;
            check = null;
            return closedCheck;
        }
        public void UseOffer(Offer offer) 
        {
            check.UseOffer(offer);
        }
    }
}