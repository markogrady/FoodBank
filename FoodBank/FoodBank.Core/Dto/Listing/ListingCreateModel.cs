using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FoodBank.Core.Dto.Listing
{
    public class ListingCreateModel
    {
        public string ListingName { get; set; }
        public string CompanyReference { get; set; }   
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? UseByDate { get; set; }
        public Guid CompanyBranchId  { get; set; }
        public List<SelectListItem> CompanyBranches { get; set; }
    }
}
