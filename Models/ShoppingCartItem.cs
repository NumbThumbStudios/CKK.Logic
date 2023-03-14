using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class ShoppingCartItem: InventoryItem
    {
        // getters and setters
        public Product GetProduct() { return base.Prod; }
        public void SetProduct(Product product) { base.Prod = product; }

        public int GetQuantity() { return base.Quantity; }
        public void SetQuantity(int quantity) { base.Quantity = quantity; }

        // constructors
        public ShoppingCartItem(Product product, int quantity)
        {
            SetProduct(product);
            SetQuantity(quantity);
        }

        // methods
        public decimal GetTotal()
        {
            return base.Prod.GetPrice() * GetQuantity();
        }
    }
}
