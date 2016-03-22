using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.Supplier
{
    public class SupplierIndexModel
    {
        public SupplierIndexModel()
        {
            SupplierIndexItemModels = new List<SupplierIndexItemModel>();
        }

        public List<SupplierIndexItemModel> SupplierIndexItemModels { get; set; }
    }

    public class SupplierIndexItemModel
    {
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string LogoUrl { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
    }
}
