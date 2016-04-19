using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

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
        public Guid CompanyBranchId { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string TownCity { get; set; }
        public string CompanyBranchName { get; set; }
        public County County { get; set; }
        public string ContactName { get; set; }
        public string ContactEmailAddress { get; set; }
        public string PostCode { get; set; }
    }
}
