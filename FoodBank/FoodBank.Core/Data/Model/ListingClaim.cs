using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Data.Model
{
    public class ListingClaim
    {
        public Guid ListingClaimId { get; set; }
        public string Reference { get; set; }
        public decimal Quantity { get; set; }

        public DateTime CreationDate { get; set; }
        public ClaimStatus ClaimStatus { get; set; }

        public Guid BankBranchId { get; set; }
        public virtual BankBranch BankBranch { get; set; }
        public Guid ListingId { get; set; }
        public virtual Listing Listing { get; set; }

    }
}
