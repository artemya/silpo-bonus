using System;
using Xunit;
using SilpoBonusCore.checkout;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {
        [Fact]
        public void CloseCheckWithOneProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(new Product(7, "Milk"));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.getTotalCost(), 7);
        }

        [Fact]
        public void CloseCheckWithTwoProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(new Product(7, "Milk"));
            checkoutService.AddProduct(new Product(3, "Bred"));
            Check check = checkoutService.CloseCheck();
            Assert.Equal(check.getTotalCost(), 10);
        }

        [Fact]
        public void AddProductWhenCheckIsClosedOpensNewCheck() 
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(new Product(7, "Milk"));
            Check milkCheck = checkoutService.CloseCheck();
            Assert.Equal(milkCheck.getTotalCost(), 7);

            checkoutService.AddProduct(new Product(3, "Bread"));
            Check bredCheck = checkoutService.CloseCheck();
            Assert.Equal(bredCheck.getTotalCost(), 3);

        }
    }
}
