using CKK.DB.Interfaces;
using CKK.Logic.Models;

namespace CKK.Online.Models
{
    public class ShopModel
    {
        #region FIELDS AND PROPERTIES
        public Order Order { get; set; }
        public IUnitOfWork UOW { get; set; }
        #endregion


        #region CONTSTRUCTORS
        public ShopModel(IUnitOfWork uow)
        {
            UOW = uow;
            Order = uow.Orders.GetById(1);
            if(Order == null)
            {
                Order newOrder = new Order() { OrderId = 1, OrderNumber = "1", CustomerId = 1, ShoppingCartId = 100 };
                Order = newOrder;
                uow.Orders.Add(newOrder);
            }
        }
        #endregion
    }
}
