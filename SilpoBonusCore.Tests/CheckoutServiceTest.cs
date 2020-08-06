using System;
using Xunit;
using SilpoBonusCore.checkout;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {
        private Product milk_7;
        private Product bread_3;
        private CheckoutService checkoutService;

        
        void SetUp() {
            checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            milk_7 = new Product(7, "Milk");
            bread_3 = new Product(3, "Bred");
        }
        [Fact]
        void CloseCheckWithOneProduct()
        {
            SetUp();
            checkoutService.AddProduct(milk_7);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.getTotalCost(), 7);
        }

        [Fact]
        void CloseCheckWithTwoProduct()
        {
            SetUp();
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);
            Check check = checkoutService.CloseCheck();
            Assert.Equal(check.getTotalCost(), 10);
        }

        [Fact]
        void AddProductWhenCheckIsClosedOpensNewCheck() 
        {
            SetUp();
            checkoutService.AddProduct(milk_7);
            Check milkCheck = checkoutService.CloseCheck();
            Assert.Equal(milkCheck.getTotalCost(), 7);

            checkoutService.AddProduct(bread_3);
            Check bredCheck = checkoutService.CloseCheck();
            Assert.Equal(bredCheck.getTotalCost(), 3);

        }
        [Fact]
        void CloseCheckCalcTotalPoints() {
            SetUp();
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);
            Check Check = checkoutService.CloseCheck();
            Assert.Equal(Check.getTotalPoints(), 10);
        }
        
    }
}
