using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodBank.Web.Controllers
{
    public class DashboardController : BaseFoodController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}