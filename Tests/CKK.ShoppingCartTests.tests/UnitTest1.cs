using CKK.Logic.Models;

namespace CKK.ShoppingCartTests.tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetTotal_Success()
        {
            try
            {
                // Assemble
                Customer cust = new Customer();
                ShoppingCart cart = new ShoppingCart(cust);
                decimal expected = 0;

                // Act
                cart.AddProduct(new Product());
                cart.AddProduct(new Product());
                cart.AddProduct(new Product());
                decimal actual = cart.GetTotal();

                // Assert
                Assert.Equal(expected, actual);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }
    }
}