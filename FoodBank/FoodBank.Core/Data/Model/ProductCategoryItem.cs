using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class ProductCategoryItem
    {
        public Guid ProductCategoryItemId { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
