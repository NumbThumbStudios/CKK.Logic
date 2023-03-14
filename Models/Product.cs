using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Product: Entity
    {
        // instance variables
        public decimal Price { get; set; }

        // getters and setters
        public int GetId() { return base.Id; }
        public void SetId(int id) { base.Id = id; }

        public string GetName() { return base.Name; }
        public void SetName(string name) { base.Name = name; }

        public decimal GetPrice() { return Price; }
        public void SetPrice(decimal price) { Price = price; }
    }
}
