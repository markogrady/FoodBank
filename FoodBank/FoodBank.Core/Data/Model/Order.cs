using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Data.Model
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public Guid OrderId { get; set; }
        public string CompanyOrderReference { get; set; }
        public string CustomerOrderReference { get; set; }
        

        public Guid CompanyBranchId { get; set; }
        public virtual CompanyBranch CompanyBranch { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<OrderItem> OrderItems  { get; set; }
    }
}
