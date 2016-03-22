using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodBank.Web.Controllers;

namespace FoodBank.Web.Areas.Supplier.Controllers
{
    public class DashboardController : BaseFoodController
    {
        // GET: Supplier/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}