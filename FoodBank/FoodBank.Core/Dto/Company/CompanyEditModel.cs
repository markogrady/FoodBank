using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Company
{
    public class CompanyEditModel
    {
        public CompanyEditModel()
        {
            CompanyBranchEditModels = new List<CompanyBranchEditModel>();
        }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LogoUrl { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string TownCity { get; set; }
        public County County { get; set; }
        public string PostCode { get; set; }

        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmailAddress { get; set; }



        public List<CompanyBranchEditModel> CompanyBranchEditModels { get; set; }
    }
}
