using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Persistance.Interfaces;
using System.Text.Json;

namespace CKK.Persistance.Models
{
    public class FileStore : IStore, ISavable, ILoadable
    {
        // ----    INSTANCE VARIABLES    ---- //
        private List<StoreItem> items = new List<StoreItem>();
        public readonly string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
        public readonly string file_path_counter = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "IdCounter.dat";
        private int IdCounter = 0;
        public int GetIdCounter() { return IdCounter; }
        public void SetIdCounter(int count) { IdCounter = count; }




        // ----    CONSTRUCTOR    ---- //
        public FileStore()
        {
            CreatePath();
        }
        




        // ----    METHODS    ---- //
        public StoreItem AddStoreItem(Product prod, int quantity = 1)
        {
            StoreItem? my_item = null;

            if (quantity <= 0) { throw new InventoryItemStockTooLowException(); }

            var linq_find_item =
                from item in items
                where (item.GetProduct() == prod)
                select item;

            if (linq_find_item.Any())
            {
                linq_find_item.First().SetQuantity(linq_find_item.First().GetQuantity() + quantity);
                my_item = linq_find_item.First();
            }
            else
            {
                //prod.SetId(items.Count + 1);
                my_item = new StoreItem(prod, quantity);
                items.Add(my_item);
            }

            return my_item;
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity < 0) { throw new ArgumentOutOfRangeException(); }

            StoreItem my_item = null;

            var linq_find_item =
                from item in items
                where (item.GetProduct().GetId() == id)
                select item;

            if (linq_find_item.Any())
            {
                if (linq_find_item.First().GetQuantity() < quantity) { quantity = linq_find_item.First().GetQuantity(); }
                linq_find_item.First().SetQuantity(linq_find_item.First().GetQuantity() - quantity);
                my_item = linq_find_item.First();
            }
            else
            {
                throw new ProductDoesNotExistException();
            }

            return my_item;
        }

        public void DeleteStoreItem(int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetProduct().GetId().Equals(id))
                {
                    items.RemoveAt(i);
                    return;
                }
            }
        }

        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0) { throw new InvalidIdException(); }

            StoreItem my_item = null;

            var linq_find_item =
                from item in items
                where (item.GetProduct().GetId() == id)
                select item;

            if (linq_find_item.Any())
            {
                my_item = linq_find_item.First();
            }

            return my_item;
        }

        public List<StoreItem> GetStoreItems()
        {
            return items;
        }

        public void Load()
        {
            items.Clear();

            if(!File.Exists(FilePath)) { return; }

            try
            {
                StoreItem[]? items_from_file = JsonSerializer.Deserialize<StoreItem[]>(File.ReadAllText(FilePath)) ?? new StoreItem[0];
                foreach (var i in items_from_file)
                {
                    items.Add(i);
                }
            }
            catch
            {

            }

            if(!File.Exists(file_path_counter)) { File.Create(file_path_counter).Dispose(); }

            try
            {
                IdCounter = int.Parse(File.ReadAllText(file_path_counter));
            }
            catch
            {
                File.WriteAllText(file_path_counter, "0");
            }
        }

        public void Save()
        {
            string items_to_string = JsonSerializer.Serialize(items);
            File.WriteAllText(FilePath, items_to_string);

            File.WriteAllText(file_path_counter, IdCounter.ToString());
        }

        private void CreatePath()
        {
            string directory_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance";
            if (!Directory.Exists(directory_path))
            {
                Directory.CreateDirectory(directory_path);
            }
        }
    }
}
