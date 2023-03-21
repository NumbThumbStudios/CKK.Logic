using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Product: Entity
    {
        // ----    INSTANCE VARIABLES    ---- //
        public decimal Price { get; set; }




        // ----    AUTO PROPERTIES/GETTERS & SETTERS    ---- //
        public int GetId() { return base.Id; }
        public void SetId(int id) { base.Id = id; }

        public string GetName() { return base.Name; }
        public void SetName(string name) { base.Name = name; }

        public decimal GetPrice() { return Price; }
        public void SetPrice(decimal price) { Price = price; }
    }
}
