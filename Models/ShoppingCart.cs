namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        // instance variables
        private Customer _customer;
        private ShoppingCartItem _product1 = new ShoppingCartItem(null, 0);
        private ShoppingCartItem _product2 = new ShoppingCartItem(null, 0);
        private ShoppingCartItem _product3 = new ShoppingCartItem(null, 0);




        // constructors
        public ShoppingCart(Customer cust)
        {
            _customer = cust;
        }




        // methods
        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if(quantity > 0)
            {
                if (_product1 == null)
                {
                    _product1 = new ShoppingCartItem(prod, quantity);
                    return _product1;
                }
                else
                if (_product2 == null)
                {
                    _product2 = new ShoppingCartItem(prod, quantity);
                    return _product2;
                }
                else
                if (_product3 == null)
                {
                    _product3 = new ShoppingCartItem(prod, quantity);
                    return _product3;
                }

                else

                if(_product1 != null)
                {
                    if(_product1.GetProduct() == prod)
                    {
                        _product1.SetQuantity(_product1.GetQuantity() + quantity);
                        return _product1;
                    }
                }
                else
                if(_product2 != null)
                {
                    if (_product2.GetProduct() == prod)
                    {
                        _product2.SetQuantity(_product2.GetQuantity() + quantity);
                        return _product2;
                    }
                }
                else
                if(_product3 != null)
                {
                    if (_product3.GetProduct() == prod)
                    {
                        _product3.SetQuantity(_product3.GetQuantity() + quantity);
                        return _product3;
                    }
                }
            }

            return null;
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            ShoppingCartItem item = null;

            if (quantity > 0)
            {
                if(_product1.GetProduct() == prod)
                {
                    _product1.SetQuantity(_product1.GetQuantity() - quantity);
                    if(_product1.GetQuantity() <= 0)
                    {
                        _product1.SetProduct(null);
                    }

                    return _product1;
                }
                else
                if (_product2.GetProduct() == prod)
                {
                    _product2.SetQuantity(_product2.GetQuantity() - quantity);
                    if (_product2.GetQuantity() <= 0)
                    {
                        _product2.SetProduct(null);
                    }

                    return _product2;
                }
                else
                if (_product3.GetProduct() == prod)
                {
                    _product3.SetQuantity(_product3.GetQuantity() - quantity);
                    if (_product3.GetQuantity() <= 0)
                    {
                        _product3.SetProduct(null);
                    }

                    return _product3;
                }
            }

            return item;
        }

        public decimal GetTotal()
        {
            /*decimal total = 0m;*/

            // Null reference exception error???? Why do I check if _product1 is null or not then???
            /*if (_product1 != null && _product1.GetProduct() != null)
            {
                total += _product1.GetTotal();
            }

            if (_product2 != null && _product2.GetProduct() != null)
            {
                total += _product2.GetTotal();
            }

            if (_product3 != null && _product3.GetProduct() != null)
            {
                total += _product3.GetTotal();
            }*/

            /*return total;*/

            return 0m;
        }

        public ShoppingCartItem GetProduct(int prodNum)
        {
            ShoppingCartItem item = null;

            switch(prodNum)
            {
                case 1:
                    item = _product1;
                    break;

                case 2:
                    item = _product2;
                    break;

                case 3:
                    item = _product3;
                    break;
            }

            return item;
        }

        public ShoppingCartItem GetProductById(int id)
        {
            ShoppingCartItem item = null;

            if (_product1.GetProduct().GetId() == id) { item = _product1; }
            if (_product2.GetProduct().GetId() == id) { item = _product2; }
            if (_product3.GetProduct().GetId() == id) { item = _product3; }

            return item;
        }
    }
}
