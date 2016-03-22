using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.Company
{
    public class CompanyIndexModel
    {
        public CompanyIndexModel()
        {
            CompanyIndexItemModels = new List<CompanyIndexItemModel>();
        }

        public List<CompanyIndexItemModel> CompanyIndexItemModels { get; set; }
    }

    public class CompanyIndexItemModel
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LogoUrl { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
    }
}
