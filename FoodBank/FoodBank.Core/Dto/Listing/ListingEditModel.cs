using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Listing
{
    public class ListingEditModel
    {
        public Guid ListingId { get; set; }

        public string CompanyReference { get; set; }
        public string ListingName { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }

        public DateTime? UseByDate { get; set; }

        public ListingStatus ListingStatus { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
