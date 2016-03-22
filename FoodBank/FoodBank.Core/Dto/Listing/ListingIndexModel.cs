using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.Listing
{
    public class ListingIndexModel
    {
        public ListingIndexModel()
        {
            ListingIndexItemModels = new List<ListingIndexItemModel>();
        }
        public List<ListingIndexItemModel> ListingIndexItemModels { get; set; }
    }

    public class ListingIndexItemModel
    {
        public Guid ListingId { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ListingName { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal QuantityAvailable { get; set; }
        public string BranchName { get; set; }
        public string CompanyReference { get; set; }
    }
}
