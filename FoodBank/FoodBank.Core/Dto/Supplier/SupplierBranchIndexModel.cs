using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.Supplier
{
    public class SupplierBranchIndexModel
    {
        public SupplierBranchIndexModel()
        {
            SupplierBranchIndexItemModels = new List<SupplierBranchIndexItemModel>();
        }

        public List<SupplierBranchIndexItemModel> SupplierBranchIndexItemModels { get; set; }
    }

    public class SupplierBranchIndexItemModel
    {
        
    }
}
