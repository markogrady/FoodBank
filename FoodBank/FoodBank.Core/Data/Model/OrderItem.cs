using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Data.Model
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public string SupplierItemReference { get; set; }
        public string CustomerItemReference { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? CollectionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        
        public Guid ListingId { get; set; }
        public virtual Listing Listing { get; set; }

    }
}
