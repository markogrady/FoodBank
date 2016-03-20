using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FoodBank.Core.Data;

namespace FoodBank.Core.Business.DropDown
{
    public interface IDropDownBusiness
    {
        List<SelectListItem> GetBranches(Guid supplierId);
    }

    public class DropDownBusiness : IDropDownBusiness
    {
        private IAppDbContext _appDbContext;

        public DropDownBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<SelectListItem> GetBranches(Guid supplierId)
        {
            var model = new List<SelectListItem>();
            var branches = _appDbContext.SupplierBranches.Select(o => new
            {
                o.SupplierId,
                Text = o.SupplierBranchName,
                Value = o.SupplierBranchId
            }).Where(o => o.SupplierId == supplierId);

            foreach (var branch in branches.ToList())
            {
                model.Add(new SelectListItem()
                {
                    Text = branch.Text,
                    Value = branch.Value.ToString()
                });
            }

            return model;
        }
    }
}