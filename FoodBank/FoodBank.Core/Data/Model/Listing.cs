using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Data.Model
{
    public class Listing
    {
        public Listing()
        {
            OrderItems = new List<OrderItem>();
        }
        public Guid ListingId { get; set; }
        public string CompanyReference { get; set; }
        public string ListingName { get; set; }
        public string Description { get; set; } 
        public decimal Quantity { get; set; }
        public DateTime? UseByDate { get; set; }
        public ListingStatus ListingStatus { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CompanyBranchId { get; set; }
        public virtual CompanyBranch CompanyBranch { get; set; }

        public virtual ICollection<OrderItem> OrderItems{ get; set; }

    }
}