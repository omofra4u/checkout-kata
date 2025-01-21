namespace CheckoutKata.Business
{
	/// <summary>
	/// 
	/// </summary>
	public interface ISpecialOffer
	{
		/// <summary>
		/// 
		/// </summary>
		string SKU
		{
			get; 
		}

		/// <summary>
		/// 
		/// </summary>
		int Quantity
		{
			get;
		}

		/// <summary>
		/// 
		/// </summary>
		int OfferPrice
		{
			get;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="numberOfSKU"></param>
		/// <returns></returns>
		int GetApplicableDiscount( int numberOfSKU );
	}
}
