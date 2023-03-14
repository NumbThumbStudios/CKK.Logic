using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Customer : Entity
    {
        // instance variables
        public string Address { get; set; }

        // getters and setters
        public int GetId() { return base.Id; }
        public void SetId(int id) { base.Id = id; }

        public string GetName() { return base.Name; }
        public void SetName(string name) { base.Name = name; }

        public string GetAddress() { return Address; }
        public void SetAddress(string address) { Address = address; }
    }
}
