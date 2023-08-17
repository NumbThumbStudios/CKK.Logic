using CKK.DB.Interfaces;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Online.Models;
using Microsoft.AspNetCore.Mvc;

namespace CKK.Online.Controllers
{
    public class ShopController : Controller
    {
        #region FIELDS AND PROPERTIES
        private readonly IUnitOfWork UOW;
        #endregion


        #region CONTRUCTORS
        public ShopController(IUnitOfWork uow)
        {
            UOW = uow;
        }
        #endregion


        #region METHODS
        [HttpGet]
        [Route("/Shop/ShoppingCart")]
        public IActionResult Index()
        {
            var model = new ShopModel(UOW);
            UOW.ShoppingCarts.ClearCart(model.Order.ShoppingCartId);
            return View("ShoppingCart", model);
        }

        [HttpGet]
        [Route("/Shop/Products")]
        public IActionResult Products()
        {
            var model = new ShopModel(UOW);
            UOW.ShoppingCarts.ClearCart(model.Order.ShoppingCartId);
            return View("Products", model);
        }

        public IActionResult CheckOutCustomer([FromQuery] int orderId)
        {
            string statusMessage = "";

            // Get order info
            var order = UOW.Orders.GetById(orderId);
            var items = UOW.ShoppingCarts.GetProducts(order.ShoppingCartId);

            // Update quantities of products in inventory
            foreach (var item in items)
            {
                Product updated_item = UOW.Products.GetById(item.ProductId);
                updated_item.Quantity -= item.Quantity;

                UOW.Products.Update(updated_item);
            }

            statusMessage += $"Order: {order.ShoppingCartId} - ";

            // For the assignment we just delete or clear
            UOW.ShoppingCarts.ClearCart(order.ShoppingCartId);

            statusMessage += "Order Placed Successfully!";

            var model = new CheckOutModel { StatusMessage = statusMessage.Trim('\0') };

            return View("Checkout", model);
        }

        [HttpGet]
        [Route("Shop/ShoppingCart/Add/{productId}")]
        public IActionResult Add([FromRoute]int productId, [FromQuery]int quantity)
        {
            var order = UOW.Orders.GetById(1);
            var test = UOW.ShoppingCarts.AddToCart(order.ShoppingCartId, productId, quantity);
            var total = UOW.ShoppingCarts.GetTotal(order.ShoppingCartId).ToString("c");

            return Ok(total);
        }
        #endregion

        
    }
}
