using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodBank.Web.Controllers
{
    public class SettingController : BaseFoodController
    {
        // GET: Setting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Notification()
        {
            return View();
        }
    }
}