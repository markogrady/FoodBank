using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class ProductType
    {
        public ProductType()
        {
            Products = new List<Product>();
            ProductTypeAttributes = new List<ProductTypeAttribute>();
        }

        public Guid ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public string JsonSchema { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductTypeAttribute> ProductTypeAttributes { get; set; }
    }
}
