namespace CheckoutKata.Business
{
	/// <summary>
	/// 
	/// </summary>
	public class SpecialOffer : ISpecialOffer
	{
		private int _discount;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sku">The name of the product</param>
		/// <param name="qty">The number of quantity the user needs to purchase to get discount</param>
		/// <param name="offerPrice">Multi priced discount</param>
		/// <param name="unitPrice">Original price of the SKU</param>
		public SpecialOffer(string sku, int qty, int offerPrice, int unitPrice)
		{
			SKU = sku;
			Quantity = qty;
			OfferPrice = offerPrice;

			// Do all applicable calculation at start up, thus speeding up the call to get discount later on
			var originalPriceOfDiscountedQuantity = unitPrice * Quantity;
			_discount = originalPriceOfDiscountedQuantity - OfferPrice;

		}

		/// <summary>
		/// Get the SKU
		/// </summary>
		public string SKU
		{
			get;
		}

		/// <summary>
		/// Get the multi buy quantity
		/// </summary>
		public int Quantity
		{	
			get;
		}

		/// <summary>
		/// Get the multi price discount
		/// </summary>
		public int OfferPrice
		{
			get;
		}

		/// <summary>
		/// Get the discount applicable to the number of item purchased
		/// </summary>
		/// <param name="numberOfSKU">Number of items purchased</param>
		/// <returns>Applicable discount</returns>
		public int GetApplicableDiscount( int numberOfSKU)
		{
			int specialCount = numberOfSKU / Quantity;
			
			return specialCount * _discount;
		}
	}
}
