using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutKata.Data;
using CheckoutKata.Exceptions;

namespace CheckoutKata
{
	public class Checkout : ICheckout
	{
		private List<Product> scannedProducts = new List<Product>();
		private IProductRepository productRepository;

		public Checkout(IProductRepository productRepository)
        {
			this.productRepository = productRepository;
        }
        
		public int GetTotalPrice()
		{
			return scannedProducts.Sum( p => p.UnitPrice );
		}

		public void Scan( string sku )
		{
			var product = productRepository.GetBySKU( sku );
			if( product == null )
			{
				throw new ProductNotFoundException( sku );
			}
			scannedProducts.Add(product);
		}
	}
}
