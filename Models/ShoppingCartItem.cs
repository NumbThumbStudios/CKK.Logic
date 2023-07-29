using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System;

namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCartItem: InventoryItem
    {
        public Product Product { get; set; }
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        private int quantity { get; set; }
        public int Quantity
        {
            get => quantity;
            set
            {
                if(value >= 0)
                {
                    quantity = value;
                }
                else
                {
                    throw new InventoryItemStockTooLowException();
                }
            }
        }
        public decimal GetTotal() { return Product.Price * Quantity; }




        /*// ----    AUTO PROPERTIES/GETTERS & SETTERS    ---- //
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
        }*/
    }
}
