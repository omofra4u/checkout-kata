using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutKata.Data;

namespace CheckoutKata
{
	public interface IProductRepository
	{
		IEnumerable<Product> Products
		{
			get;
		}

		Product GetBySKU(string sku);
	}
}
