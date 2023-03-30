using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class InventoryItem
    {
        private Product _product;
        public Product Product 
        {
            get { return _product; }
            set { _product = value; }
        }

        private int _quantity;
        public int Quantity 
        { 
            get
            {
                return _quantity;
            }

            set
            {
                if (value < 0) { throw new InventoryItemStockTooLowException(); }
                _quantity = value;
            }
        }
    }
}
