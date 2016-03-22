using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Order
{
    public class OrderIndexModel
    {
        public OrderIndexModel()
        {
            OrderIndexItemModels = new List<OrderIndexItemModel>();
        }
        public List<OrderIndexItemModel> OrderIndexItemModels { get; set; }
    }

    public class OrderIndexItemModel
    {
        public Guid OrderId { get; set; }
        public DateTime CreationDate  { get; set; }
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierBranchName { get; set; }
        public string SupplierOrderReference { get; set; }
        public string BankOrderReference { get; set; }
        public Guid BankBranchId { get; set; }
        public string BankCompanyName { get; set; }
        public int NumberOfItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string BankBranchName { get; set; }
    }
}
