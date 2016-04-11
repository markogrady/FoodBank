using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.Basket
{
    public class BasketAddModel
    {
        public Guid CompanyUserId { get; set; }
        public Guid ListingId { get; set; }
        public decimal Quantity { get; set; }
    }
}
