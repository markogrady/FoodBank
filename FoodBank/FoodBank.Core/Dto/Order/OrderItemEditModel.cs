using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Order
{
    public class OrderItemEditModel
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public string SupplierItemReference { get; set; }
        public string CustomerItemReference { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? CollectionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }

        public Guid ListingId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public ConditionType ConditionType { get; set; }
        public DateTime? UseByDate { get; set; }
        public decimal? TotalLinePrice { get; set; }
        public decimal? Price { get; set; }
    }
}
