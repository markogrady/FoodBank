using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FoodBank.Core.Data;

namespace FoodBank.Core.Business.DropDown
{
    public interface IDropDownBusiness
    {
        List<SelectListItem> GetBranches(Guid CompanyId);
        List<SelectListItem> GetProducts();
    }

    public class DropDownBusiness : IDropDownBusiness
    {
        private IAppDbContext _appDbContext;

        public DropDownBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<SelectListItem> GetBranches(Guid CompanyId)
        {
            var model = new List<SelectListItem>();
            var branches = _appDbContext.CompanyBranches.Select(o => new
            {
                o.CompanyId,
                Text = o.CompanyBranchName,
                Value = o.CompanyBranchId
            }).Where(o => o.CompanyId == CompanyId);

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

        public List<SelectListItem> GetProducts()
        {
            var model = new List<SelectListItem>();
            var products = _appDbContext.Products.Select(o => new
            {
               
                Text = o.ProductName,
                Value = o.ProductId
            });

            foreach (var product in products.ToList())
            {
                model.Add(new SelectListItem()
                {
                    Text = product.Text,
                    Value = product.Value.ToString()
                });
            }

            return model;
        }
    }
}