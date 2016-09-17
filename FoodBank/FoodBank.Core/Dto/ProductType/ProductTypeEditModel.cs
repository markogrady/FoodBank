using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.ProductType
{
    public class ProductTypeEditModel
    {
        public ProductTypeEditModel()
        {
            ProductTypeAttributeEditModels = new List<ProductTypeAttributeEditModel>();
        }
        public Guid ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public string JsonSchema { get; set; }

        public List<ProductTypeAttributeEditModel> ProductTypeAttributeEditModels { get; set; }
    }

    public class ProductTypeAttributeEditModel
    {
        public Guid AttributeId { get; set; }
        public string AttributeName { get; set; }
    }
}
