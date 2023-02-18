﻿namespace CKK.Logic.Models
{
    public class StoreItem
    {
        // instance variables
        private Product _product;
        private int _quantity;

        // getters and setters
        public Product GetProduct() { return _product; }
        public void SetProduct(Product product) { _product = product; }

        public int GetQuantity() { return _quantity; }
        public void SetQuantity(int quantity) { _quantity = quantity; }

        // constructors
        public StoreItem(Product product, int quantity)
        {
            SetProduct(product);
            SetQuantity(quantity);
        }
    }
}