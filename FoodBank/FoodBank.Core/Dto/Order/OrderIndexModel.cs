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
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyBranchName { get; set; }
        public string CompanyOrderReference { get; set; }
        
        public Guid BankBranchId { get; set; }
        public string BankCompanyName { get; set; }
        public int NumberOfItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string BankBranchName { get; set; }
    }
}
