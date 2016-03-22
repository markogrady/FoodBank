using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FoodBank.Core.Business.Supplier;
using FoodBank.Web.Controllers;

namespace FoodBank.Web.Areas.Supplier.Controllers
{
    public class SupplierController : BaseFoodController
    {
        private ISupplierBusiness _supplierBusiness;

        public SupplierController(ISupplierBusiness supplierBusiness)
        {
            _supplierBusiness = supplierBusiness;
        }

        // GET: Supplier/Supplier
        public async  Task<ActionResult> Index()
        {
            var model = await _supplierBusiness.GetSupplier(AuthenticatedUser.CompanyFirmId);
            return View(model);
        }

       

        public async Task<ActionResult> Branch(Guid id)
        {
            var model = await _supplierBusiness.GetSupplierBranch(id);
            return View(model);
        }

       
    }
}