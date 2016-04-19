using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FoodBank.Core.Business.Order;
using FoodBank.Web.Controllers;

namespace FoodBank.Web.Controllers
{
    public class OrdersController : BaseFoodController
    {
        private IOrderBusiness _orderBusiness;

        public OrdersController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        // GET: Supplier/Orders
        public async Task<ActionResult> Index()
        {
            var model = await _orderBusiness.GetCompanyOrders(AuthenticatedUser.CompanyFirmId);
            return View(model);
        }

        public async Task<ActionResult> IndexBranch(Guid id)
        {
            var model = await _orderBusiness.GetCompanyBranchOrders(id);
            return View("Index",model);
        }

        public ActionResult Edit(Guid id)
        {
            var model = _orderBusiness.GetOrderById(id);
        }
    }
}