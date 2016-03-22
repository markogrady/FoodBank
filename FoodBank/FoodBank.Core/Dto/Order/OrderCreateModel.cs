using System;
using System.Collections.Generic;

namespace FoodBank.Core.Dto.Order
{
    public class OrderCreateModel
    {
        public Guid BankBranchId { get; set; }
        public List<OrderItemCreateModel> OrderItems { get; set; }
        public string BankOrderReference { get; set; }
        public Guid SupplierBranchId { get; set; }
    }

    public class OrderItemCreateModel
    {
        public Guid ListingId { get; set; }
        public decimal Quantity { get; set; }
        public string SupplierReference { get; set; }
        public string BankReference { get; set; }
    }
}