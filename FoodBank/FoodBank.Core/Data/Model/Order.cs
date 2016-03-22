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
        public string SupplierOrderReference { get; set; }
        public string BankOrderReference { get; set; }
        public Guid BankBranchId { get; set; }
        public virtual BankBranch BankBranch { get; set; }

        public Guid SupplierBranchId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public virtual SupplierBranch SupplierBranch { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<OrderItem> OrderItems  { get; set; }
    }
}
