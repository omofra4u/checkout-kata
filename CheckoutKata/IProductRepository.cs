using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutKata.Data;

namespace CheckoutKata
{
	/// <summary>
	/// 
	/// </summary>
	public interface IProductRepository
	{
		/// <summary>
		/// 
		/// </summary>
		IEnumerable<Product> Products
		{
			get;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		Product GetBySKU(string sku);
	}
}
