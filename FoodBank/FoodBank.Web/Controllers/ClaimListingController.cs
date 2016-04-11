using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FoodBank.Core.Business.Basket;
using FoodBank.Core.Business.Listing;
using FoodBank.Core.Business.Order;
using FoodBank.Core.Dto.Basket;
using FoodBank.Core.Dto.Order;

namespace FoodBank.Web.Controllers
{
    public class ClaimListingController : BaseFoodController
    {
        private IBasketBusiness _basketBusiness;
        private IOrderBusiness _orderBusiness;
        private IListingBusiness _listingBusiness;

        public ClaimListingController(IListingBusiness listingBusiness, IOrderBusiness orderBusiness, IBasketBusiness basketBusiness)
        {
            _listingBusiness = listingBusiness;
            _orderBusiness = orderBusiness;
            _basketBusiness = basketBusiness;
        }

        // GET: ClaimListing
        public async Task<ActionResult> Index()
        {
            var model = await _listingBusiness.GetListings();
            return View(model);
        }

        public ActionResult AddToBasket(Guid id)
        {
            var model = _listingBusiness.GetAddBasketListing(id);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult AddToBasket(BasketAddModel model)
        {
            model.CompanyUserId = AuthenticatedUser.UserId;
            _basketBusiness.AddItem(model);
            Success("Listing Claimed");
            return RedirectToAction("Index", "ClaimListing");
        }

        // GET: Checkout
        public ActionResult Basket()
        {
            //Get Current Basket and list all items
            var model = _basketBusiness.GetBasket(AuthenticatedUser.UserId);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderCreateFromBasketModel model)
        {
            await _orderBusiness.CreateOrdersFromBasket(model);
            Success("Order(s) Created");
            return RedirectToAction("Index", "Orders");
        }
    }
}