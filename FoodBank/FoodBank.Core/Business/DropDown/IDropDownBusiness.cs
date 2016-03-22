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
    }
}