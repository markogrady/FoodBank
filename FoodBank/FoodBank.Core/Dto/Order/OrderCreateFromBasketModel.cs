using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.Order
{
    public class OrderCreateFromBasketModel
    {
        public Guid BasketId { get; set; }
        public Guid SupplierBranchId { get; set; }
        public Guid? CustomerBranchId { get; set; }
        public string CustomerOrderReference { get; set; }
    }
}
