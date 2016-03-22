using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodBank.Web.Controllers;

namespace FoodBank.Web.Areas.FoodBank.Controllers
{
    public class DashboardController : BaseFoodController
    {
        // GET: FoodBank/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}