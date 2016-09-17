using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public  class ProductCategory
    {
        public ProductCategory()
        {
            ProductCategoryItems = new List<ProductCategoryItem>();
        }

        public Guid ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }

        public virtual ICollection<ProductCategoryItem> ProductCategoryItems { get; set; }
    }
}
