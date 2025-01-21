namespace CheckoutKata
{
	/// <summary>
	/// 
	/// </summary>
	public interface ICheckout
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		void Scan( string item );

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		int GetTotalPrice();
	}
}
