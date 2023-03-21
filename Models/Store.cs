using System.Collections.Generic;
using System.Linq;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Store: Entity, IStore
    {
        // ----    INSTANCE VARIABLES    ---- //
        private List<StoreItem> items = new List<StoreItem>();




        // ----    AUTO PROPERTIES/GETTERS & SETTERS    ---- //
        public int GetId() { return base.Id; }
        public void SetId(int id) { base.Id = id; }

        public string GetName() { return base.Name; }
        public void SetName(string name) { base.Name = name; }




        // ----    METHODS    ---- //
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
