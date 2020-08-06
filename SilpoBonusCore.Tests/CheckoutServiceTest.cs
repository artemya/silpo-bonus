using System;
using Xunit;

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
    }
}
