using System;
using System.Collections.Generic;

namespace FoodBank.Core.Dto.Order
{
    public class OrderCreateModel
    {
        public Guid CustomerBranchId { get; set; }
        public List<OrderItemCreateModel> OrderItems { get; set; }
        public string CustomerOrderReference { get; set; }
        public Guid SupplierBranchId { get; set; }
    }

    public class OrderItemCreateModel
    {
        public Guid ListingId { get; set; }
        public decimal Quantity { get; set; }
        public string CustomerItemReference { get; set; }
    }
}