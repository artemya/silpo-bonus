using System;
using Xunit;
using SilpoBonusCore.checkout;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {
        private Product milk_7;
        private Product bred_3;
        private CheckoutService checkoutService;

        public CheckoutServiceTest()
        {
            checkoutService = new CheckoutService();
            milk_7 = new Product(7, "Milk", Category.MILK);
            bred_3 = new Product(3, "Bred");
            checkoutService.OpenCheck();
        }

        [Fact]
        void CloseCheck_WithOneProduct()
        {
            checkoutService.AddProduct(milk_7);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 7);
        }

        [Fact]
        void CloseChec_kWithTwoProduct()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);
            Check check = checkoutService.CloseCheck();
            Assert.Equal(check.GetTotalCost(), 10);
        }

        [Fact]
        void AddProduct_WhenCheckIsClosedOpensNewCheck() 
        {
            checkoutService.AddProduct(milk_7);
            Check milkCheck = checkoutService.CloseCheck();
            Assert.Equal(milkCheck.GetTotalCost(), 7);

            checkoutService.AddProduct(bred_3);
            Check bredCheck = checkoutService.CloseCheck();
            Assert.Equal(bredCheck.GetTotalCost(), 3);

        }
        [Fact]
        void CloseCheck_CalcTotalPoints() {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);
            Check check = checkoutService.CloseCheck();
            Assert.Equal(check.GetTotalPoints(), 10);
        }

        [Fact]
        void UseOffer_AddOfferPoints() {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);

            checkoutService.UseOffer(new AnyGoodsOffer(6, 2));
            Check check = checkoutService.CloseCheck();
            
            Assert.Equal(check.GetTotalPoints(), 12);
        }

        [Fact]
        void UseOffer_WhenCostLessThanRequired_DoNothing() {
            checkoutService.AddProduct(bred_3);

            checkoutService.UseOffer(new AnyGoodsOffer(6, 2));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 3);
        }

        [Fact]
        void UseOffer_FactorByCategory() {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);

            checkoutService.UseOffer(new FactorByCategoryOffer(Category.MILK, 2));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 31);
        }

    }
}
