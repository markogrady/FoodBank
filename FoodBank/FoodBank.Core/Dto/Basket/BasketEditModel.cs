using System;
using System.Collections.Generic;

namespace FoodBank.Core.Dto.Basket
{
    public class BasketEditModel
    {
        public BasketEditModel()
        {
            BasketItemModels = new List<BasketItemModel>();
        }
        public List<BasketItemModel> BasketItemModels { get; set; }
    }

    public class BasketItemModel
    {
        public Guid BasketItemId { get; set; }
        public string ProductName { get; set; }
        public string SupplierBranch { get; set; }
        public decimal Quantity { get; set; }
    }
}