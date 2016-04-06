using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string CustomerOrderReference { get; set; }
        

        public Guid SupplierId { get; set; }
        public virtual CompanyBranch Supplier { get; set; }


        public Guid? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual CompanyBranch Customer { get; set; }


        public OrderStatus OrderStatus { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<OrderItem> OrderItems  { get; set; }
    }
}
