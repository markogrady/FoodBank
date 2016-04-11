using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodBank.Core.Business.Basket;
using FoodBank.Core.Business.Order;
using FoodBank.Core.Dto.Basket;
using FoodBank.Core.Dto.Order;

namespace FoodBank.Web.Controllers
{
    [Authorize]
    public class CheckoutController : BaseFoodController
    {
        private IBasketBusiness _basketBusiness;
        private IOrderBusiness _orderBusiness;

        public CheckoutController(IBasketBusiness basketBusiness, IOrderBusiness orderBusiness)
        {
            _basketBusiness = basketBusiness;
            _orderBusiness = orderBusiness;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            //Get Current Basket and list all items
            var model = _basketBusiness.GetBasket(AuthenticatedUser.UserId);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderCreateFromBasketModel model)
        {
            _orderBusiness.CreateOrdersFromBasket(model);
            Success("Order(s) Created");
            return RedirectToAction("Index", "Orders");
        }
    }
}