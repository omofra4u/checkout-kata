using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Exceptions
{
	public class ProductNotFoundException : Exception
	{
        public ProductNotFoundException(string sku) : base(sku)
        {
            
        }
    }
}
