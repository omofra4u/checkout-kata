using CheckoutKata;
using CheckoutKata.Business;
using CheckoutKata.Exceptions;
using CheckoutKataTest.Data;

namespace CheckoutKataTest
{
	[TestClass]
	public class CheckoutTest
	{
		ICheckout _classUnderTest = null;

		[TestInitialize]
		public void TestInitialize()
		{
			var repository = new MockProductRepository();
			repository.InitializeProducts();
			_classUnderTest = new Checkout( repository, new List<ISpecialOffer>()
			{
				new SpecialOffer("A", 3, 130, 50),
				new SpecialOffer("B", 2, 45, 30)
			} );

		}

		[TestCleanup]
		public void TestCleanup()
		{
		}
		
		[TestMethod]
		public void Checkout_Scanner_Should_Return_Zero_If_No_Product_Is_Scanned()
		{
			// Act 
			var totalPrice = _classUnderTest.GetTotalPrice();

			// Assert
			Assert.AreEqual(0, totalPrice);
		}

		[TestMethod]
		[DataRow("W")]
		[DataRow( "Z" )]
		[DataRow( "H" )]
		[ExpectedException( typeof( ProductNotFoundException) )]
		public void Checkout_Scanner_Should_Throw_Product_Not_Found_Exception_If_Scanned_SKU_Is_Not_Found(string sku)
		{
			// Act 
			_classUnderTest.Scan(sku);
;
		}

		[TestMethod]
		[DataRow( "A", 50 )]
		[DataRow( "B", 30 )]
		[DataRow( "C", 20 )]
		[DataRow( "D", 15 )]
		public void Checkout_Scanner_Should_Return_Price_Of_Item_If_One_Product_Is_Scan(string sku, int unitPrice)
		{

			// Act 
			_classUnderTest.Scan( sku);
			var totalPrice = _classUnderTest.GetTotalPrice();

			// Assert
			Assert.AreEqual(unitPrice, totalPrice );
		}

		[TestMethod]
		[DataRow( "ABCD", 115 )]
		[DataRow( "ABD", 95 )]
		[DataRow( "ACD", 85 )]
		[DataRow( "BCD", 65 )]
		public void Checkout_Scanner_Should_Return_Total_Price_If_Different_Items_Are_Scanned( string skus, int unitPrice )
		{
			// Arrange 
			var productsToScan = skus.ToCharArray();

			// Act
			foreach( var item in productsToScan )
			{
				_classUnderTest.Scan( item.ToString() );
			} 
			
			var totalPrice = _classUnderTest.GetTotalPrice();

			// Assert
			Assert.AreEqual( unitPrice, totalPrice );
		}


		[TestMethod]
		[DataRow( "AAAAA", 230 )]
		[DataRow( "AAA", 130 )]
		[DataRow( "BB", 45 )]
		[DataRow( "BBBBB", 120 )]
		public void Checkout_Scanner_Should_Apply_Offer_To_Total_Price_On_Products_On_Offer( string skus, int unitPrice )
		{
			// Arrange 
			var productsToScan = skus.ToCharArray();

			// Act
			foreach( var item in productsToScan )
			{
				_classUnderTest.Scan( item.ToString() );
			}

			var totalPrice = _classUnderTest.GetTotalPrice();

			// Assert
			Assert.AreEqual( unitPrice, totalPrice );
		}

		[TestMethod]
		[DataRow( "AAAAB", 210 )]
		[DataRow( "AAABBBCCDDD", 290 )]
		[DataRow( "BB", 45 )]
		[DataRow( "BBAAAACDA",310 )]
		public void Checkout_Scanner_Should_Apply_Offer_To_Total_Price_On_Products_On_Or_Without_Offer( string skus, int unitPrice )
		{
			// Arrange 
			var productsToScan = skus.ToCharArray();

			// Act
			foreach( var item in productsToScan )
			{
				_classUnderTest.Scan( item.ToString() );
			}

			var totalPrice = _classUnderTest.GetTotalPrice();

			// Assert
			Assert.AreEqual( unitPrice, totalPrice );
		}
	}
}