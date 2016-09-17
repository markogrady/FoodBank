using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.ProductType
{
    public class ProductTypeIndexModel
    {
        public ProductTypeIndexModel()
        {
            ProductTypeIndexItemModels = new List<ProductTypeIndexItemModel>();
        }
        public List<ProductTypeIndexItemModel> ProductTypeIndexItemModels { get; set; }
    }

    public class ProductTypeIndexItemModel
    {
        public Guid ProductTypeId { get; set; } 
        public string ProductTypeName { get; set; }
    }
}
