using CKK.Logic.Interfaces;
using System;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Customer : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ShoppingCartId { get; set; }




        /*// ----    INSTANCE VARIABLES    ---- //
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart Cart { get; set; }




        // ----    AUTO PROPERTIES/GETTERS & SETTERS    ---- //
        public int GetId() { return base.Id; }
        public void SetId(int id) { base.Id = id; }

        public string GetName() { return base.Name; }
        public void SetName(string name) { base.Name = name; }

        public string GetAddress() { return Address; }
        public void SetAddress(string address) { Address = address; }*/
    }
}
