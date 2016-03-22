using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.Company
{
    public class CompanyBranchIndexModel
    {
        public CompanyBranchIndexModel()
        {
            CompanyBranchIndexItemModels = new List<CompanyBranchIndexItemModel>();
        }

        public List<CompanyBranchIndexItemModel> CompanyBranchIndexItemModels { get; set; }
    }

    public class CompanyBranchIndexItemModel
    {
        
    }
}
