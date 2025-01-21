using CheckoutKata;
using CheckoutKata.Data;

namespace CheckoutKataTest.Data
{
	/// <summary>
	/// 
	/// </summary>
	internal class MockProductRepository : IProductRepository
	{
		IList<Product> _products = new List<Product>();

		/// <summary>
		/// 
		/// </summary>
		public IEnumerable<Product> Products => _products;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public Product GetBySKU( string sku )
		{
			return _products.FirstOrDefault( product => product.SKU.Equals(sku, StringComparison.OrdinalIgnoreCase) );
		}

		/// <summary>
		/// 
		/// </summary>
		internal void InitializeProducts()
		{
			_products.Add( new Product() { SKU = "A", UnitPrice = 50 } );
			_products.Add( new Product() { SKU = "B", UnitPrice = 30 } );
			_products.Add( new Product() { SKU = "C", UnitPrice = 20 } );
			_products.Add( new Product() { SKU = "D", UnitPrice = 15 } );
		}
	}
}
