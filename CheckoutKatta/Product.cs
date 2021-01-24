using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKatta
{
    public class Product
    {
        public Product(string sku, int price)
        {
            this.Price = price;
            this.Sku = sku;
        }

        public readonly string Sku;
        public readonly int Price;
    }
}
