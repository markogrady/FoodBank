using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.Product
{
    public class ProductIndexModel
    {
        public ProductIndexModel()
        {
            ProductIndexItemModels = new List<ProductIndexItemModel>();
        }

        public List<ProductIndexItemModel> ProductIndexItemModels { get; set; }
    }

    public class ProductIndexItemModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public string ProductTypeName { get; set; }
    }
}
