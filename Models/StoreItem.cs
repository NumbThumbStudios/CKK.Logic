using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class StoreItem: InventoryItem
    {
        // ----    AUTO PROPERTIES/GETTERS & SETTERS    ---- //
        public Product GetProduct() { return base.Prod; }
        public void SetProduct(Product product) { base.Prod = product; }

        public int GetQuantity() { return base.Quantity; }
        public void SetQuantity(int quantity) { base.Quantity = quantity; }




        // ----    CONSTRUCTORS    ---- //
        public StoreItem(Product product, int quantity)
        {
            SetProduct(product);
            SetQuantity(quantity);
        }
    }
}
