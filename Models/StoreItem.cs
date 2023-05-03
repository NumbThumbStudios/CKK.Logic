using CKK.Logic.Interfaces;
using System;

namespace CKK.Logic.Models
{
    [Serializable]
    public class StoreItem: InventoryItem
    {
        // ----    AUTO PROPERTIES/GETTERS & SETTERS    ---- //
        public Product GetProduct() { return Product; }
        public void SetProduct(Product product) { Product = product; }

        public int GetQuantity() { return Quantity; }
        public void SetQuantity(int quantity) { Quantity = quantity; }




        // ----    CONSTRUCTORS    ---- //
        public StoreItem(Product product, int quantity)
        {
            SetProduct(product);
            SetQuantity(quantity);
        }
    }
}
