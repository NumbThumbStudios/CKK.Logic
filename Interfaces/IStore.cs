﻿using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public interface IStore
    {
        StoreItem AddStoreItem(Product prod, int quantity = 1);
        StoreItem RemoveStoreItem(int id, int quantity);
        void DeleteStoreItem(int id);
        StoreItem FindStoreItemById(int id);
        List<StoreItem> GetStoreItems();
    }
}
