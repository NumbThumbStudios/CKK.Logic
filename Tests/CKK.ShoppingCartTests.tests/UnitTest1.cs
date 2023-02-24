using CKK.Logic.Models;
using Xunit;

namespace CKK.ShoppingCartTests.tests
{
    public class UnitTest1
    {
        // Add Product...
        [Fact]
        public void AddProduct_Success()
        {
            try
            {
                // Assemble
                ShoppingCart cart = new ShoppingCart(new Customer());
                Product prod = new Product();
                Product expected = prod;

                // Act
                Product actual = cart.AddProduct(prod).GetProduct();

                // Assert
                Assert.Equal(expected, actual);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Remove Product...
        [Fact]
        public void RemoveProduct_Success()
        {
            try
            {
                // Assemble...
                ShoppingCart cart = new ShoppingCart(new Customer());
                Product prod = new Product();
                Product expected = null;


                // Act...
                cart.AddProduct(prod);
                Product actual = cart.RemoveProduct(prod, 1).GetProduct();

                // Assert...
                Assert.Equal(expected, actual);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Get Shopping Cart Total...
        [Fact]
        public void GetTotal_Success()
        {
            try
            {
                // Assemble
                ShoppingCart cart = new ShoppingCart(new Customer());
                decimal expected = 69.24m;

                // Act
                Product prod = new Product();
                prod.SetPrice(69.24m);
                cart.AddProduct(prod);
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