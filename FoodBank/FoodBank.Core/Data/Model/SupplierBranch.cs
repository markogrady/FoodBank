using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Data.Model
{
    public class SupplierBranch
    {
        public SupplierBranch()
        {
            Listings = new List<Listing>();
            SupplierUsers = new List<SupplierUser>();
            Orders = new List<Order>();
        }

        public Guid SupplierBranchId { get; set; }
        public string SupplierBranchName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string TownCity { get; set; }
        public County County { get; set; }
        public string PostCode { get; set; }

        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmailAddress { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<SupplierUser> SupplierUsers { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
