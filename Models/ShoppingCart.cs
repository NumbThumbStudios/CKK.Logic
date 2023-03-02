using System.Collections.Generic;
using System.Linq;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        // instance variables
        private Customer _customer;
        private List<ShoppingCartItem> products;




        // constructors
        public ShoppingCart(Customer cust)
        {
            _customer = cust;
            products = new List<ShoppingCartItem>();
        }




        // methods
        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity = 1)
        {
            ShoppingCartItem my_item = null;

            if(quantity <= 0) { return my_item; }

            var linq_find_item =
                from item in products
                where (item.GetProduct() == prod)
                select item;

            if(linq_find_item.Any())
            {
                linq_find_item.First().SetQuantity(linq_find_item.First().GetQuantity() + quantity);
                my_item = linq_find_item.First();
            }
            else
            {
                my_item = new ShoppingCartItem(prod, quantity);
                products.Add(my_item);
            }


            return my_item;
        }

        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            ShoppingCartItem my_item = null;

            var linq_find_item = 
                from item in products
                where (item.GetProduct().GetId() == id)
                select item;

            if(linq_find_item.Any()) 
            {
                int new_quantity = linq_find_item.First().GetQuantity() - quantity;

                if(new_quantity <= 0)
                {
                    linq_find_item.First().SetQuantity(0);
                    my_item = linq_find_item.First();
                    products.Remove(linq_find_item.First());
                }
                else
                {
                    linq_find_item.First().SetQuantity(new_quantity);
                    my_item = linq_find_item.First();
                }
            }

            return my_item;
        }

        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (var item in products)
            {
                total += item.GetTotal();
            }

            return total;
        }

        public ShoppingCartItem GetProductById(int id)
        {
            ShoppingCartItem my_item = null;

            var linq_find_item =
                from item in products
                where (item.GetProduct().GetId().Equals(id))
                select item;

            if(linq_find_item.Any())
            {
                my_item = linq_find_item.First();
            }

            return my_item;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return products;
        }
    }
}
