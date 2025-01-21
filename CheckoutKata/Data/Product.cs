using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Data
{
	public class Product
	{
		/// <summary>
		/// Get Set the Store Keeping Item name
		/// </summary>
		public string SKU
		{
			get;set;
		}

		/// <summary>
		/// Get Set the Unit Price
		/// </summary>
		public int UnitPrice
		{
			get; set;
		}
	}
}
