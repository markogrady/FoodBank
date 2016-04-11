using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FoodBank.Core.Business.Product;
using FoodBank.Core.Dto.Product;

namespace FoodBank.Web.Controllers
{
    [Authorize]
    public class ProductController : BaseFoodController
    {
        private IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        // GET: Product
        public async Task<ActionResult> Index()
        {
            var model = await _productBusiness.GetProducts();
            return View(model);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _productBusiness.GetProduct(id);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new ProductCreateModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductCreateModel model)
        {
            await _productBusiness.Create(model);
            Success("Product Created.");
            return RedirectToAction("Index","Product");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductEditModel model)
        {
            await _productBusiness.Update(model);
            Success("Product Updated.");
            return RedirectToAction("Index", "Product");
        }

    }
}