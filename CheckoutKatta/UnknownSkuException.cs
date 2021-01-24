using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKatta
{
    public class UnknownSkuException : Exception
    {
        public UnknownSkuException(string sku) : base($"Unknown SKU = {sku}")
        {
        }
    }
}
