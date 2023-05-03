using CKK.Logic.Interfaces;
using System;

namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCartItem: InventoryItem
    {
        // ----    AUTO PROPERTIES/GETTERS & SETTERS    ---- //
        public Product GetProduct() { return Product; }
        public void SetProduct(Product product) { Product = product; }

        public int GetQuantity() { return Quantity; }
        public void SetQuantity(int quantity) { Quantity = quantity; }




        // ----    CONSTRUCTORS    ---- //
        public ShoppingCartItem(Product product, int quantity)
        {
            SetProduct(product);
            SetQuantity(quantity);
        }




        // ----    METHODS    ---- //
        public decimal GetTotal()
        {
            return base.Product.GetPrice() * GetQuantity();
        }
    }
}
