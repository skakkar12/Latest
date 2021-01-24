using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKatta
{
    public class Promotion
    {

        public Promotion(string sku, int numberOfItems, double percent)
        {
            Sku = sku;
            NumberofItems = numberOfItems;
            Percent = percent;
        }

        public readonly string Sku;
        public readonly int NumberofItems;
        public readonly double Percent;
    }

    public class Promotions
    {
        private List<Promotion> promotions = new List<Promotion>();
        private List<Discount> discounts = new List<Discount>();

        public Promotions PromotionProduct(string sku, int numberOfItems, double percent)
        {
            this.promotions.RemoveAll(x => x.Sku == sku);

            this.promotions.Add(new Promotion(sku, numberOfItems, percent));
            return this;
        }


        public double GetPromotionPrice(string sku, ref int numberOfItemsToCalculatePriceFor)
        {
            var promotion = this.promotions.Where(x => x.Sku == sku).FirstOrDefault();
            if (promotion == null) return 0; // no discounted price for this product

            var promotionPrice = (numberOfItemsToCalculatePriceFor / promotion.NumberofItems) * promotion.Percent;

            // number of items to still calculate price for
            numberOfItemsToCalculatePriceFor =Convert.ToInt32( numberOfItemsToCalculatePriceFor % promotion.Percent);

            //return Convert.ToInt32(promotionPrice);

            return promotionPrice;
        }
    }
}