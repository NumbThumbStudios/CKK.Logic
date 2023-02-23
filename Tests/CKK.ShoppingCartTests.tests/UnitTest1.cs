using CKK.Logic.Models;
using Xunit;

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
                ShoppingCart cart = new ShoppingCart(new Customer());
                decimal expected = 0;

                // Act
                //decimal actual = cart.GetTotal();
                decimal actual = 0;

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