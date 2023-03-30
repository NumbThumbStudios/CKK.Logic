using CKK.Logic.Interfaces;
using System;
using System.Diagnostics;

namespace CKK.Logic.Models
{
    public class Product: Entity
    {
        // ----    INSTANCE VARIABLES    ---- //
        //public decimal Price { get; set; }
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException(); }
                _price = value;
            }
        }




        // ----    AUTO PROPERTIES/GETTERS & SETTERS    ---- //
        public int GetId() { return base.Id; }
        public void SetId(int id) { base.Id = id; }

        public string GetName() { return base.Name; }
        public void SetName(string name) { base.Name = name; }

        public decimal GetPrice() { return _price; }
        /*public void SetPrice(decimal price) 
        { 
            try
            {
                if(price < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(price));
                }

                _price = price;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }*/
    }
}
