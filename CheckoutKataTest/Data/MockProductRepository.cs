using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutKata;
using CheckoutKata.Data;

namespace CheckoutKataTest.Data
{
	/// <summary>
	/// 
	/// </summary>
	internal class MockProductRepository : IProductRepository
	{
		IList<Product> products = new List<Product>();

		/// <summary>
		/// 
		/// </summary>
		public IEnumerable<Product> Products => products;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public Product GetBySKU( string sku )
		{
			return products.FirstOrDefault( product => product.SKU.Equals(sku, StringComparison.OrdinalIgnoreCase) );
		}

		internal void InitializeProducts()
		{
			products.Add( new Product() { SKU = "A", UnitPrice = 50 } );
			products.Add( new Product() { SKU = "B", UnitPrice = 30 } );
			products.Add( new Product() { SKU = "C", UnitPrice = 20 } );
			products.Add( new Product() { SKU = "D", UnitPrice = 15 } );
		}
	}
}
