using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class StoreItem: InventoryItem
    {
        // instance variables
        //private Product _product;
        //private int _quantity;

        // getters and setters
        public Product GetProduct() { return base.Prod; }
        public void SetProduct(Product product) { base.Prod = product; }

        public int GetQuantity() { return base.Quantity; }
        public void SetQuantity(int quantity) { base.Quantity = quantity; }

        // constructors
        public StoreItem(Product product, int quantity)
        {
            SetProduct(product);
            SetQuantity(quantity);
        }
    }
}
