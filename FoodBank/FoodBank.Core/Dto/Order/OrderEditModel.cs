using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Order
{
    public class OrderEditModel
    {
        public OrderEditModel()
        {
            OrderItems = new List<OrderItemEditModel>();
        }

        public Guid OrderId { get; set; }
        public string SupplierOrderReference { get; set; }
        public string CustomerOrderReference { get; set; }


        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierBranchName { get; set; }
        public string SupplierAddress1 { get; set; }
        public string SupplierAddress2 { get; set; }
        public string SupplierAddress3 { get; set; }
        public string SupplierTownCity { get; set; }
        public County SupplierCounty { get; set; }
        public string SupplierPostCode { get; set; }

        public string SupplierContactName { get; set; }
        public string SupplierContactPhoneNumber { get; set; }
        public string SupplierContactEmailAddress { get; set; }


        public Guid? CustomerId { get; set; }

        public string CustomerName { get; set; }
        public string CustomerBranchName { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerAddress3 { get; set; }
        public string CustomerTownCity { get; set; }
        public County CustomerCounty { get; set; }
        public string CustomerPostCode { get; set; }

        public string CustomerContactName { get; set; }
        public string CustomerContactPhoneNumber { get; set; }
        public string CustomerContactEmailAddress { get; set; }


        public OrderStatus OrderStatus { get; set; }
        public DateTime CreationDate { get; set; }
        public List<OrderItemEditModel> OrderItems { get; set; }
    }
}
