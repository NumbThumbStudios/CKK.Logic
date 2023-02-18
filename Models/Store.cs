namespace CKK.Logic.Models
{
    public class Store
    {
        // instance variables
        private int _id;
        private string _name;
        private Product _product1;
        private Product _product2;
        private Product _product3;

        // getters and setters
        public int GetId() { return _id; }
        public void SetId(int id) { _id = id; }

        public string GetName() { return _name; }
        public void SetName(string name) { _name = name; }

        // methods
        public void AddStoreItem(Product prod)
        {
            if(_product1 == null) { _product1 = prod; }
            else
            if(_product2 == null) { _product2 = prod; }
            else
            if(_product3 == null) { _product3 = prod; }
        }

        public void RemoveStoreItem(int productNum)
        {
            switch(productNum)
            {
                case 1:
                    _product1 = null;
                    break;

                case 2:
                    _product2 = null;
                    break;

                case 3:
                    _product3 = null;
                    break;
            }
        }

        public Product GetStoreItem(int productNum)
        {
            switch(productNum)
            {
                case 1:
                    return _product1;

                case 2:
                    return _product2;

                case 3:
                    return _product3;
            }

            return null;
        }

        public Product FindStoreItemById(int id)
        {
            if(_product1 != null && _product1.GetId() == id)
            {
                return _product1;
            }

            if(_product2 != null && _product2.GetId() == id)
            {
                return _product2;
            }

            if(_product3 != null && _product3.GetId() == id)
            {
                return _product3;
            }

            return null;
        }
    }
}
