using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using FoodBank.Core.Business.DropDown;
using FoodBank.Core.Business.Listing;
using FoodBank.Core.Dto.Listing;

namespace FoodBank.Web.Controllers
{
    [Authorize]
    public class ListingsController : BaseFoodController
    {
        private readonly IListingBusiness _listingBusiness;
        private IDropDownBusiness _dropDownBusiness;

        public ListingsController(IListingBusiness listingBusiness, IDropDownBusiness dropDownBusiness)
        {
            _listingBusiness = listingBusiness;
            _dropDownBusiness = dropDownBusiness;
        }

        // GET: Supplier/Listings
        public async Task<ActionResult> Index(Guid? branchId)
        {
            var model = new ListingIndexModel();
            if (!branchId.HasValue)
            {
                model = await _listingBusiness.GetListingsByCompany(AuthenticatedUser.CompanyFirmId);
            }
            else
            {
                model = await _listingBusiness.GetListingsByCompanyBranch(branchId.Value);
            }
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new ListingCreateModel();
            model.CompanyBranchId = AuthenticatedUser.AuthCompanyModel.CompanyBranchId;
            model.CompanyBranches = _dropDownBusiness.GetBranches(AuthenticatedUser.CompanyFirmId);
            model.Products = _dropDownBusiness.GetProducts();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ListingCreateModel model)
        {
            var id = await _listingBusiness.Create(model);
            Success("Listing Created");
            return RedirectToAction("Edit","Listings", new {id = id});
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _listingBusiness.GetListing(id);
            return View(model);
        }
    }
}