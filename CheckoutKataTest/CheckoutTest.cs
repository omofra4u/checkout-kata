using CheckoutKata;
using CheckoutKata.Exceptions;
using CheckoutKataTest.Data;

namespace CheckoutKataTest
{
	[TestClass]
	public class CheckoutTest
	{
		ICheckout _classUnderTest;

		[TestInitialize]
		public void TestInitialize()
		{
			var repository = new MockProductRepository();
			repository.InitializeProducts();
			_classUnderTest = new Checkout( repository );

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
	}
}