using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class Basket
    {
        public Basket()
        {
            BasketItems = new List<BasketItem>();
        }
        public Guid BasketId { get; set; }
        public Guid CompanyUserId { get; set; }

        public DateTime CreationDate { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }

    public class BasketItem
    {
        public Guid BasketItemId { get; set; }
        public decimal Quantity { get; set; }

        public Guid ListingId { get; set; }
       
        public virtual Listing Listing { get; set; }
        public Guid BasketId { get; set; }
        public virtual Basket Basket { get; set; }

    }
}
