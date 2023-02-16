namespace CKK.Logic.Models
{
    public class Product
    {
        // instance variables
        private int _id;
        private string _name;
        private decimal _price;

        // getters and setters
        public int GetId() { return _id; }
        public void SetId(int id) { _id = id; }

        public string GetName() { return _name; }
        public void SetName(string name) { _name = name; }

        public decimal GetPrice() { return _price; }
        public void SetPrice(decimal price) { _price = price; }
    }
}
