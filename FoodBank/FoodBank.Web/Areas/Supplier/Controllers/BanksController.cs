using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodBank.Core.Business.Bank;
using FoodBank.Web.Controllers;

namespace FoodBank.Web.Areas.Supplier.Controllers
{
    public class BanksController : BaseFoodController
    {
        private IBankBusiness _bankBusiness;

        public BanksController(IBankBusiness bankBusiness)
        {
            _bankBusiness = bankBusiness;
        }

        // GET: Supplier/Banks
        public ActionResult Index()
        {
            var model = _bankBusiness.GetAllBanks();
            return View(model);
        }
        public ActionResult Detail(Guid id)
        {
            var model = _bankBusiness.GetBank(id);
            return View(model);
        }
    }
}