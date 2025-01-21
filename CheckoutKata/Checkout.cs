using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutKata.Business;
using CheckoutKata.Data;
using CheckoutKata.Exceptions;

namespace CheckoutKata
{
	/// <summary>
	/// 
	/// </summary>
	public class Checkout : ICheckout
	{
		private List<Product> _scannedProducts = new List<Product>();
		private IProductRepository _productRepository;
		private IList<ISpecialOffer> _specialOffers;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="productRepository"></param>
		/// <param name="specialOffers"></param>
		public Checkout(IProductRepository productRepository, IList<ISpecialOffer> specialOffers)
        {
			_productRepository = productRepository;
			_specialOffers = specialOffers;
			//Guard against clients passing null list becuse there is no special offer
			if (_specialOffers == null)
			{
				_specialOffers = new List<ISpecialOffer>();
			}
        }

		/// <summary>
		/// Summed the price of all summed items, loop through special offers and apply applicable discount on total price
		/// </summary>
		/// <returns>The total price including special offer discount of all scanned SKU item</returns>
		public int GetTotalPrice()
		{
			//var count = _scannedProducts.All(x => x.SKU == )
			var totalPrice = _scannedProducts.Sum( p => p.UnitPrice );


			foreach(var offer in _specialOffers)
			{
				var count = _scannedProducts.Count(x => x.SKU == offer.SKU);

				totalPrice -= offer.GetApplicableDiscount( count );
			}

			return totalPrice;
		}

		/// <summary>
		/// Go to the product repository and get scanned product and add it to the list of scanned products
		/// </summary>
		/// <param name="sku">The scanned store keeping unit</param>
		/// <exception cref="ProductNotFoundException">Throws if the product is not found</exception>
		public void Scan( string sku )
		{
			var product = _productRepository.GetBySKU( sku );
			if( product == null )
			{
				throw new ProductNotFoundException( sku );
			}
			_scannedProducts.Add( product );
		}
	}
}
