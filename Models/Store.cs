using System.Collections.Generic;
using System.Linq;

namespace CKK.Logic.Models
{
    public class Store
    {
        // instance variables
        private int _id;
        private string _name;
        private List<StoreItem> items = new List<StoreItem>();




        // getters and setters
        public int GetId() { return _id; }
        public void SetId(int id) { _id = id; }

        public string GetName() { return _name; }
        public void SetName(string name) { _name = name; }

        // methods
        public StoreItem AddStoreItem(Product prod, int quantity = 1)
        {
            StoreItem my_item = null;

            if(quantity <= 0) { return my_item; }

            var linq_find_item =
                from item in items
                where (item.GetProduct() == prod)
                select item;

            if(linq_find_item.Any())
            {
                linq_find_item.First().SetQuantity(linq_find_item.First().GetQuantity() + quantity);
                my_item = linq_find_item.First();
            }
            else
            {
                my_item = new StoreItem(prod, quantity);
                items.Add(my_item);
            }

            return my_item;
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            StoreItem my_item = null;

            var linq_find_item =
                from item in items
                where (item.GetProduct().GetId() == id)
                select item;

            if(linq_find_item.Any())
            {
                if(linq_find_item.First().GetQuantity() < quantity) { quantity = linq_find_item.First().GetQuantity(); }
                linq_find_item.First().SetQuantity(linq_find_item.First().GetQuantity() - quantity);
                my_item = linq_find_item.First();
            }

            return my_item;
        }

        public StoreItem FindStoreItemById(int id)
        {
            StoreItem my_item = null;

            var linq_find_item = 
                from item in items
                where (item.GetProduct().GetId() == id)
                select item;

            if(linq_find_item.Any())
            {
                my_item = linq_find_item.First();
            }

            return my_item;
        }

        public List<StoreItem> GetStoreItems()
        {
            return items;
        }
    }
}
