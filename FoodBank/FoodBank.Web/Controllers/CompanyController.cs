using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FoodBank.Core.Business.Company;
using FoodBank.Web.Controllers;

namespace FoodBank.Web.Controllers
{
    public class CompanyController : BaseFoodController
    {
        private ICompanyBusiness _companyBusiness;

        public CompanyController(ICompanyBusiness companyBusiness)
        {
            _companyBusiness = companyBusiness;
        }

        // GET: Supplier/Supplier
        public async  Task<ActionResult> Index()
        {
            var model = await _companyBusiness.GetCompany(AuthenticatedUser.CompanyFirmId);
            return View(model);
        }

       

        public async Task<ActionResult> Branch(Guid id)
        {
            var model = await _companyBusiness.GetCompanyBranch(id);
            return View(model);
        }


        public ActionResult Detail(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit()
        {
            throw new NotImplementedException();
        }
    }
}