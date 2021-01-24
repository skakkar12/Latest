using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CheckoutKatta;

namespace CheckoutKatta.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        Checkout checkout;

        [SetUp]
        public void BeforeTest()
        {
            var catalog = new ProductCatalog()
             .UpdateProductPrice("A", 10)
             .UpdateProductPrice("B", 15)
             .UpdateProductPrice("C", 40)
             .UpdateProductPrice("D", 55);
            var discounts = new Discounts()
                    .DiscountProduct("B", 3, 40);

            var promotions = new Promotions()
            .PromotionProduct("D", 3, 137.5);

            checkout = new Checkout(catalog, discounts, promotions);

        }

        [Test]
        public void can_find_price_of_a_single_item_A()
        {
            // ActCheckoutTests
            checkout.Scan("A");

            // Assert                                                            
            Assert.AreEqual(10, checkout.Total);

        }


        [Test]
        public void can_find_price_of_a_single_item_B()
        {
            // Act                                                               
            checkout.Scan("B");

            // Assert                                                            
            Assert.AreEqual(15, checkout.Total);

        }


        [Theory]
        [Test]
        [TestCase("A", 10)]
        [TestCase("B", 15)]
        [TestCase("C", 40)]
        [TestCase("D", 55)]
        public void can_find_price_of_a_single_item(string sku, int expected_total)
        {
            // Act                                                               
            checkout.Scan(sku);

            // Assert                                                            
            Assert.AreEqual(expected_total, checkout.Total);

        }


    }
}
    